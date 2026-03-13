using System;
using System.IO;
using System.Web.Mvc;
using FBZapp.Domain.Entities;
using FBZapp.Infrastructure.Repositories;
using FBZapp.Mvc.Models;

namespace FBZapp.Mvc.Controllers
{
    public class DatasetController : Controller
    {
        [HttpGet]
        public ActionResult Upload()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            if (Session["Role"] == null || Session["Role"].ToString() != "Staff")
                return RedirectToAction("Index", "Home");

            return View(new DatasetUploadViewModel());
        }

        [HttpPost]
        public ActionResult Upload(DatasetUploadViewModel model)
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            if (Session["Role"] == null || Session["Role"].ToString() != "Staff")
                return RedirectToAction("Index", "Home");

            var logRepo = new DatasetImportLogRepository();

            if (model.CsvFile == null || model.CsvFile.ContentLength == 0)
            {
                ViewBag.Message = "Please select a CSV file.";
                return View(model);
            }

            var extension = Path.GetExtension(model.CsvFile.FileName);
            if (extension == null || extension.ToLower() != ".csv")
            {
                ViewBag.Message = "Only CSV files are allowed.";
                return View(model);
            }

            var tempPath = Server.MapPath("~/App_Data/temp_upload.csv");
            var targetPath = Server.MapPath("~/App_Data/titles.csv");
            var backupPath = Server.MapPath("~/App_Data/titles_backup.csv");

            try
            {
                model.CsvFile.SaveAs(tempPath);

                // Validate structure before replacing live file
                var loader = new FBZapp.Infrastructure.Data.CsvDataLoader(tempPath);
                var testLoad = loader.LoadComics();

                if (testLoad == null || testLoad.Count == 0)
                {
                    throw new Exception("Uploaded CSV structure is invalid or contains no usable comic data.");
                }

                if (System.IO.File.Exists(targetPath))
                {
                    System.IO.File.Copy(targetPath, backupPath, true);
                }

                System.IO.File.Copy(tempPath, targetPath, true);
                System.IO.File.Delete(tempPath);

                logRepo.AddLog(new DatasetImportLog
                {
                    FileName = model.CsvFile.FileName,
                    ImportDate = DateTime.Now,
                    Status = "Success",
                    Notes = "Dataset validated and replaced successfully."
                });

                ViewBag.Message = "Dataset uploaded and validated successfully.";
            }
            catch (Exception ex)
            {
                if (System.IO.File.Exists(tempPath))
                {
                    System.IO.File.Delete(tempPath);
                }

                logRepo.AddLog(new DatasetImportLog
                {
                    FileName = model.CsvFile.FileName,
                    ImportDate = DateTime.Now,
                    Status = "Failed",
                    Notes = ex.Message
                });

                ViewBag.Message = "Dataset upload failed: invalid CSV structure.";
            }

            return View(new DatasetUploadViewModel());
        }

        public ActionResult Logs()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            if (Session["Role"] == null || Session["Role"].ToString() != "Staff")
                return RedirectToAction("Index", "Home");

            var repo = new DatasetImportLogRepository();
            var logs = repo.GetAllLogs();

            return View(logs);
        }
    }
}