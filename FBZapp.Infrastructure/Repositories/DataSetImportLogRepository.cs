using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using FBZapp.Application.Interfaces;
using FBZapp.Domain.Entities;

namespace FBZapp.Infrastructure.Repositories
{
    public class DatasetImportLogRepository : IDatasetImportLogRepository
    {
        private readonly string _connectionString;

        public DatasetImportLogRepository()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["FBZappDB"]
                .ConnectionString;
        }

        public void AddLog(DatasetImportLog log)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var cmd = new SqlCommand(
                    "INSERT INTO DatasetImportLogs (FileName, ImportDate, Status, Notes) VALUES (@FileName, @ImportDate, @Status, @Notes)",
                    conn);

                cmd.Parameters.AddWithValue("@FileName", log.FileName);
                cmd.Parameters.AddWithValue("@ImportDate", log.ImportDate);
                cmd.Parameters.AddWithValue("@Status", log.Status);
                cmd.Parameters.AddWithValue("@Notes", (object)log.Notes ?? DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public List<DatasetImportLog> GetAllLogs()
        {
            var results = new List<DatasetImportLog>();

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var cmd = new SqlCommand(
                    "SELECT * FROM DatasetImportLogs ORDER BY ImportDate DESC",
                    conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new DatasetImportLog
                        {
                            Id = (int)reader["Id"],
                            FileName = reader["FileName"].ToString(),
                            ImportDate = (DateTime)reader["ImportDate"],
                            Status = reader["Status"].ToString(),
                            Notes = reader["Notes"].ToString()
                        });
                    }
                }
            }

            return results;
        }
    }
}
