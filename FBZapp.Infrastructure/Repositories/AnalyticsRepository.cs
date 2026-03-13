using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using FBZapp.Application.Interfaces;


namespace FBZapp.Infrastructure.Repositories
{
    public class AnalyticsRepository : IAnalyticsRepository
    {
        private readonly string _connectionString;
        private const int ComicTitleMaxLength = 450;

        public AnalyticsRepository()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["FBZappDB"]
                .ConnectionString;
        }

        public void LogSearch(int? userId, string queryText)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(
                    @"INSERT INTO SearchLogs (UserId, QueryText, SearchDate)
                      VALUES (@UserId, @QueryText, @SearchDate)", conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", (object)userId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@QueryText", (object)queryText ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SearchDate", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void LogSearchResults(string queryText, List<string> comicTitles)
        {
            if (comicTitles == null || comicTitles.Count == 0)
                return;

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(
                    @"INSERT INTO SearchResultLogs (QueryText, ComicTitle, SearchDate)
                      VALUES (@QueryText, @ComicTitle, @SearchDate)", conn))
                {
                    cmd.Parameters.Add("@QueryText", SqlDbType.NVarChar, 255).Value =
                        (object)queryText ?? DBNull.Value;

                    cmd.Parameters.Add("@ComicTitle", SqlDbType.NVarChar, ComicTitleMaxLength);
                    cmd.Parameters.Add("@SearchDate", SqlDbType.DateTime);

                    foreach (var rawTitle in comicTitles)
                    {
                        var safeTitle = NormalizeComicTitle(rawTitle);

                        if (string.IsNullOrWhiteSpace(safeTitle))
                            continue;

                        cmd.Parameters["@ComicTitle"].Value = safeTitle;
                        cmd.Parameters["@SearchDate"].Value = DateTime.Now;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<KeyValuePair<string, int>> GetTopSearchQueries()
        {
            var results = new List<KeyValuePair<string, int>>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(
                    @"SELECT TOP 10 QueryText, COUNT(*) AS Total
                      FROM SearchLogs
                      WHERE QueryText IS NOT NULL AND QueryText <> ''
                      GROUP BY QueryText
                      ORDER BY COUNT(*) DESC", conn))
                {
                    cmd.CommandTimeout = 30;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new KeyValuePair<string, int>(
                                reader["QueryText"].ToString(),
                                Convert.ToInt32(reader["Total"])));
                        }
                    }
                }
            }

            return results;
        }

        public List<KeyValuePair<string, int>> GetTopReturnedComics()
        {
            var results = new List<KeyValuePair<string, int>>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(
                    @"SELECT TOP 10 ComicTitle, COUNT(*) AS Total
                      FROM SearchResultLogs
                      WHERE ComicTitle IS NOT NULL AND ComicTitle <> ''
                      GROUP BY ComicTitle
                      ORDER BY COUNT(*) DESC", conn))
                {
                    cmd.CommandTimeout = 30;

                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(new KeyValuePair<string, int>(
                                    reader["ComicTitle"].ToString(),
                                    Convert.ToInt32(reader["Total"])));
                            }
                        }
                    }
                    catch (SqlException)
                    {
                        return results;
                    }
                }
            }

            return results;
        }

        public List<KeyValuePair<string, int>> GetComicsReturnedMoreThan100Times()
        {
            var results = new List<KeyValuePair<string, int>>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(
                    @"SELECT ComicTitle, COUNT(*) AS Total
                      FROM SearchResultLogs
                      WHERE ComicTitle IS NOT NULL AND ComicTitle <> ''
                      GROUP BY ComicTitle
                      HAVING COUNT(*) > 100
                      ORDER BY COUNT(*) DESC", conn))
                {
                    cmd.CommandTimeout = 30;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new KeyValuePair<string, int>(
                                reader["ComicTitle"].ToString(),
                                Convert.ToInt32(reader["Total"])));
                        }
                    }
                }
            }

            return results;
        }

        private string NormalizeComicTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return string.Empty;

            title = title.Trim();

            if (title.Length > ComicTitleMaxLength)
                title = title.Substring(0, ComicTitleMaxLength);

            return title;
        }
    }
}
