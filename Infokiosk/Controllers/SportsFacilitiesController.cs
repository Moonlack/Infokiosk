using Infokiosk.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Infokiosk.Controllers
{
    public class SportsFacilitiesController : Controller
    {
        public InfoContext db = new InfoContext();
        // GET: SportsFacilities
        public ActionResult SportsFacilities()
        {
            var model = new AdminSportsFacilitiesViewModel
            {
                SportsFacilities = db.SportsFacilities.ToList(),
                SportsFacility = new SportsFacility(),
                Categories = db.SportsFacilityCategories.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddSportsFacility(SportsFacility sportsFacility)
        {
            try
            {
                db.SportsFacilities.Add(sportsFacility);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Admin/Fail");
            }
            return Redirect("Index");
        }

        [HttpPost]
        public ActionResult UploadImages(int id)
        {
            List<Image> files = new List<Image>();
            bool isSavedSuccessfully = true;
            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        var path = Path.Combine(Server.MapPath("~/Content/Media/SportsFacilities"));
                        string pathString = Path.Combine(path.ToString());
                        var fileName1 = Path.GetFileName(file.FileName);
                        bool isExists = Directory.Exists(pathString);
                        if (!isExists) Directory.CreateDirectory(pathString);
                        var uploadpath = string.Format("{0}\\{1}", pathString, file.FileName);
                        file.SaveAs(uploadpath);
                        files.Add(new Image {Filename = uploadpath});
                    }
                }
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
            }
            if (isSavedSuccessfully)
            {
                return Json(new
                {
                    Message = fName
                });
            }
            else
            {
                return Json(new
                {
                    Message = "Error in saving file"
                });

            }
            //db.Images.AddRange(paths);
            db.SportsFacilities.First(x => x.Id == id).Images.AddRange(files);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}