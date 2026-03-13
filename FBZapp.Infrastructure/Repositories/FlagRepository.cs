using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using FBZapp.Application.Interfaces;
using FBZapp.Domain.Entities;

namespace FBZapp.Infrastructure.Repositories
{
    public class FlagRepository : IFlagRepository
    {
        private readonly string _connectionString;

        public FlagRepository()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["FBZappDB"]
                .ConnectionString;
        }

        public void AddFlag(FlaggedRecord record)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var cmd = new SqlCommand(
                    "INSERT INTO FlaggedRecords (ComicTitle, FlagReason, FlaggedByUserId, FlaggedDate) VALUES (@ComicTitle, @FlagReason, @FlaggedByUserId, @FlaggedDate)",
                    conn);

                cmd.Parameters.AddWithValue("@ComicTitle", record.ComicTitle);
                cmd.Parameters.AddWithValue("@FlagReason", (object)record.FlagReason ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FlaggedByUserId", record.FlaggedByUserId);
                cmd.Parameters.AddWithValue("@FlaggedDate", record.FlaggedDate);

                cmd.ExecuteNonQuery();
            }
        }

        public List<FlaggedRecord> GetAllFlags()
        {
            var results = new List<FlaggedRecord>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var cmd = new SqlCommand(
                    "SELECT * FROM FlaggedRecords ORDER BY FlaggedDate DESC",
                    conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new FlaggedRecord
                        {
                            Id = (int)reader["Id"],
                            ComicTitle = reader["ComicTitle"].ToString(),
                            FlagReason = reader["FlagReason"].ToString(),
                            FlaggedByUserId = (int)reader["FlaggedByUserId"],
                            FlaggedDate = (DateTime)reader["FlaggedDate"]
                        });
                    }
                }
            }

            return results;
        }
    }
}