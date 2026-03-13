using System.Web;

namespace FBZapp.Mvc.Models
{
    public class DatasetUploadViewModel
    {
        public HttpPostedFileBase CsvFile { get; set; }
    }
}