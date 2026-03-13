using System.Collections.Generic;
using FBZapp.Domain.Entities;

namespace FBZapp.Application.Interfaces
{
    public interface IDatasetImportLogRepository
    {
        void AddLog(DatasetImportLog log);
        List<DatasetImportLog> GetAllLogs();
    }
}
