using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using FBZapp.Application.Interfaces;
using FBZapp.Domain.Entities;
namespace FBZapp.Infrastructure.Repositories
{
    public class SavedSearchRepository : ISavedSearchRepository
    {
        private readonly string _connectionString;

        public SavedSearchRepository()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["FBZappDB"]
                .ConnectionString;
        }

        public void SaveComic(SavedComic savedComic)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var cmd = new SqlCommand(
                    "INSERT INTO SavedComics (UserId, ComicTitle, SavedDate) VALUES (@UserId, @ComicTitle, @SavedDate)",
                    conn);

                cmd.Parameters.AddWithValue("@UserId", savedComic.UserId);
                cmd.Parameters.AddWithValue("@ComicTitle", savedComic.ComicTitle);
                cmd.Parameters.AddWithValue("@SavedDate", savedComic.SavedDate);

                cmd.ExecuteNonQuery();
            }
        }

        public void SaveSearch(SavedSearch savedSearch)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var cmd = new SqlCommand(
                    "INSERT INTO SavedSearches (UserId, QueryText, Genre, SortOption, SavedDate) VALUES (@UserId, @QueryText, @Genre, @SortOption, @SavedDate)",
                    conn);

                cmd.Parameters.AddWithValue("@UserId", savedSearch.UserId);
                cmd.Parameters.AddWithValue("@QueryText", (object)savedSearch.QueryText ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Genre", (object)savedSearch.Genre ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SortOption", (object)savedSearch.SortOption ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SavedDate", savedSearch.SavedDate);

                cmd.ExecuteNonQuery();
            }
        }

        public List<SavedComic> GetSavedComicsByUserId(int userId)
        {
            var results = new List<SavedComic>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var cmd = new SqlCommand(
                    "SELECT * FROM SavedComics WHERE UserId = @UserId ORDER BY SavedDate DESC",
                    conn);

                cmd.Parameters.AddWithValue("@UserId", userId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new SavedComic
                        {
                            Id = (int)reader["Id"],
                            UserId = (int)reader["UserId"],
                            ComicTitle = reader["ComicTitle"].ToString(),
                            SavedDate = (DateTime)reader["SavedDate"]
                        });
                    }
                }
            }

            return results;
        }

        public List<SavedSearch> GetSavedSearchesByUserId(int userId)
        {
            var results = new List<SavedSearch>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var cmd = new SqlCommand(
                    "SELECT * FROM SavedSearches WHERE UserId = @UserId ORDER BY SavedDate DESC",
                    conn);

                cmd.Parameters.AddWithValue("@UserId", userId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new SavedSearch
                        {
                            Id = (int)reader["Id"],
                            UserId = (int)reader["UserId"],
                            QueryText = reader["QueryText"].ToString(),
                            Genre = reader["Genre"].ToString(),
                            SortOption = reader["SortOption"].ToString(),
                            SavedDate = (DateTime)reader["SavedDate"]
                        });
                    }
                }
            }

            return results;
        }
    }
}