using System;

namespace FBZapp.Domain.Entities
{
    public class DatasetImportLog
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime ImportDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }
}

