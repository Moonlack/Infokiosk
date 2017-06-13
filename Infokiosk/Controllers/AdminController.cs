using Infokiosk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;

namespace Infokiosk.Controllers
{
    public class AdminController : Controller
    {
        public InfoContext db = new InfoContext();

        public ActionResult Index()
        {
            return RedirectToAction("Exhibits");
        }

        #region Events

        public ActionResult Events()
        {
            var model = new AdminEventsViewModel
            {
                Events = db.Events.OrderBy(x => x.Name).ToList(),
                Categories = db.EventCategories.OrderBy(x => x.Name).ToList(),
                Category = new EventCategory()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEvent(string name, int category, HttpPostedFileBase description)
        {
            try
            {
                var ev = new Event { Name = name, CategoryId = category };
                if (description != null)
                {
                    // сохраняем файл в папку Files в проекте
                    string fn = description.FileName;
                    string path = Server.MapPath("~/Content/Media/Events/" + fn);
                    description.SaveAs(path);
                    ev.Description = "/Content/Media/Events/" + fn;
                }
                db.Events.Add(ev);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("Events");
        }

        [HttpGet]
        public ActionResult DeleteEvent(int id)
        {
            try
            {
                var x = db.Events.Find(id);
                db.Events.Remove(x);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("Events");
        }

        [HttpPost]
        public ActionResult ChangeEvent(int id, string name, int category, HttpPostedFileBase description)
        {
            try
            {
                var x = db.Events.First(y => y.Id == id);
                if (name != "") x.Name = name;
                if (category != 0) x.CategoryId = category;
                if (description != null)
                {
                    string fn = description.FileName;
                    string path = Server.MapPath("~/Content/Media/Events/" + fn);
                    description.SaveAs(path);
                    x.Description = "/Content/Media/Events/" + fn;
                }
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("Events");
        }

        [HttpPost]
        public ActionResult UploadImagesEvents(int id, IEnumerable<HttpPostedFileBase> uploads)
        {
            List<Image> files = new List<Image>();
            foreach (var file in uploads)
            {
                if (file != null)
                {
                    string fn = Guid.NewGuid().ToString() + ".jpg";
                    string path = Server.MapPath("~/Content/Media/Events/" + fn);
                    file.SaveAs(path);
                    files.Add(new Image { Filename = "/Content/Media/Events/" + fn });
                }
            }

            db.Events.Include(x => x.Images).First(x => x.Id == id).Images.AddRange(files);
            db.SaveChanges();
            return RedirectToAction("Events");
        }

        [HttpPost]
        public ActionResult AddEventCategory(EventCategory ev)
        {
            try
            {
                db.EventCategories.Add(ev);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("Events");
        }

        [HttpGet]
        public ActionResult DeleteEventCategory(int id)
        {
            try
            {
                var x = db.EventCategories.Find(id);
                db.EventCategories.Remove(x);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("Events");
        }

        #endregion

        #region Exhibits

        public ActionResult Exhibits()
        {
            var model = db.Exhibits.OrderBy(x => x.Name).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddExhibit(string name, string category, HttpPostedFileBase description)
        {
            try
            {
                var exhibit = new Exhibit { Name = name, Category = category };
                if (description != null)
                {
                    // сохраняем файл в папку Files в проекте
                    string fn = description.FileName;
                    string path = Server.MapPath("~/Content/Media/Exhibits/" + fn);
                    description.SaveAs(path);
                    exhibit.Description = "/Content/Media/Exhibits/" + fn;
                }
                db.Exhibits.Add(exhibit);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("Exhibits");
        }

        [HttpGet]
        public ActionResult DeleteExhibit(int id)
        {
            try
            {
                var x = db.Exhibits.Find(id);
                db.Exhibits.Remove(x);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("Exhibits");
        }

        [HttpPost]
        public ActionResult ChangeExhibit(int id, string name, string category, HttpPostedFileBase description)
        {
            try
            {
                var x = db.Exhibits.First(y => y.Id == id);
                if (name != "") x.Name = name;
                if (category == "") { x.Category = null; }
                else x.Category = category;
                if (description != null)
                {
                    string fn = description.FileName;
                    string path = Server.MapPath("~/Content/Media/Exhibits/" + fn);
                    description.SaveAs(path);
                    x.Description = "/Content/Media/Exhibits/" + fn;
                }
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("Exhibits");
        }

        [HttpPost]
        public ActionResult UploadImagesExhibit(int id, IEnumerable<HttpPostedFileBase> uploads)
        {
            List<Image> files = new List<Image>();
            foreach (var file in uploads)
            {
                if (file != null)
                {
                    string fn = Guid.NewGuid().ToString() + ".jpg";
                    string path = Server.MapPath("~/Content/Media/Exhibits/" + fn);
                    file.SaveAs(path);
                    files.Add(new Image { Filename = "/Content/Media/Exhibits/" + fn });
                }
            }

            db.Exhibits.Include(x => x.Images).First(x => x.Id == id).Images.AddRange(files);
            db.SaveChanges();
            return RedirectToAction("Exhibits");
        }
        #endregion

        #region Athletes

        public ActionResult Athletes()
        {
            var model = db.Athletes.OrderBy(x => x.Initials).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddAthlete(string initials, HttpPostedFileBase description)
        {

            try
            {
                var athlete = new Athlete { Initials = initials };
                if (description != null)
                {
                    // сохраняем файл в папку Files в проекте
                    string fn = description.FileName;
                    string path = Server.MapPath("~/Content/Media/Athletes/" + fn);
                    description.SaveAs(path);
                    athlete.Description = "/Content/Media/Athletes/" + fn;
                }
                db.Athletes.Add(athlete);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("Athletes");
        }

        [HttpGet]
        public ActionResult DeleteAthlete(int id)
        {
            try
            {
                var x = db.Athletes.Find(id);
                db.Athletes.Remove(x);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("Athletes");
        }

        [HttpPost]
        public ActionResult ChangeAthlete(int id, string initials, HttpPostedFileBase description)
        {
            try
            {
                var x = db.Athletes.First(y => y.Id == id);
                if (initials != null) x.Initials = initials;
                if (description != null)
                {
                    string fn = description.FileName;
                    string path = Server.MapPath("~/Content/Media/Athletes/" + fn);
                    description.SaveAs(path);
                    x.Description = "/Content/Media/Athletes/" + fn;
                }
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("Athletes");
        }

        [HttpPost]
        public ActionResult UploadImagesAthlete(int id, IEnumerable<HttpPostedFileBase> uploads)
        {
            List<Image> files = new List<Image>();
            foreach (var file in uploads)
            {
                if (file != null)
                {
                    // сохраняем файл в папку Files в проекте
                    string fn = Guid.NewGuid().ToString() + ".jpg";
                    string path = Server.MapPath("~/Content/Media/Athletes/" + fn);
                    file.SaveAs(path);
                    files.Add(new Image { Filename = "/Content/Media/Athletes/" + fn });
                }
            }

            db.Athletes.Include(x => x.Images).First(x => x.Id == id).Images.AddRange(files);
            db.SaveChanges();
            return RedirectToAction("Athletes");
        }
        #endregion

        #region Achievements
        public ActionResult Achievements()
        {
            var model = new AdminAchievementsViewModel
            {
                Athletes = db.Athletes.OrderBy(x => x.Initials).ToList(),
                Prizes = db.Prizes.OrderBy(x => x.Id).ToList(),
                Events = db.Events.OrderBy(x => x.Name).ToList(),
                Achievements = db.Achievements.OrderBy(x => x.Athlete.Initials).ToList(),
                Achievement = new Achievement()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddAchievement(Achievement achievement)
        {
            try
            {
                db.Achievements.Add(achievement);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("Achievements");
        }

        [HttpGet]
        public ActionResult DeleteAchievement(int id)
        {
            try
            {
                var x = db.Achievements.Find(id);
                db.Achievements.Remove(x);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("Achievements");
        }

        #endregion

        #region SportsFacilities
        public ActionResult SportsFacilities()
        {
            var model = new AdminSportsFacilitiesViewModel
            {
                SportsFacilities = db.SportsFacilities.ToList(),
                Categories = db.SportsFacilityCategories.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddSportsFacility(int category, string name, HttpPostedFileBase description)
        {
            try
            {
                var sportsFaclity = new SportsFacility { Name = name, CategoryId = category };
                if (description != null)
                {
                    string fn = description.FileName;
                    string path = Server.MapPath("~/Content/Media/SportsFacilities/" + fn);
                    description.SaveAs(path);
                    sportsFaclity.Description = "/Content/Media/SportsFacilities/" + fn;
                }
                db.SportsFacilities.Add(sportsFaclity);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("SportsFacilities");
        }

        [HttpGet]
        public ActionResult DeleteSportsFacility(int id)
        {
            try
            {
                var x = db.SportsFacilities.Find(id);
                db.SportsFacilities.Remove(x);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("SportsFacilities");
        }

        [HttpPost]
        public ActionResult ChangeSportsFacility(int id, int category, string name, HttpPostedFileBase description)
        {
            try
            {
                var x = db.SportsFacilities.First(y => y.Id == id);
                if (name != "") x.Name = name;
                if (category != 0) { x.Category = null; }
                if (description != null)
                {
                    string fn = description.FileName;
                    string path = Server.MapPath("~/Content/Media/SportsFacilities/" + fn);
                    description.SaveAs(path);
                    x.Description = "/Content/Media/SportsFacilities/" + fn;
                }
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("SportsFacilities");
        }

        [HttpPost]
        public ActionResult UploadImagesSportsFacility(int id, IEnumerable<HttpPostedFileBase> uploads)
        {
            List<Image> files = new List<Image>();
            foreach (var file in uploads)
            {
                if (file != null)
                {
                    // сохраняем файл в папку Files в проекте
                    string fn = Guid.NewGuid().ToString() + ".jpg";
                    string path = Server.MapPath("~/Content/Media/SportsFacilities/" + fn);
                    file.SaveAs(path);
                    files.Add(new Image { Filename = "/Content/Media/SportsFacilities/" + fn });
                }
            }
            db.SportsFacilities.Include(x => x.Images).First(x => x.Id == id).Images.AddRange(files);
            db.SaveChanges();
            return RedirectToAction("SportsFacilities");
        }

        #endregion

        #region KindsOfSports

        public ActionResult KindsOfSports()
        {
            var model = db.KindsOfSports.OrderBy(x => x.Name).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddKindOfSport(string name, HttpPostedFileBase description)
        {
            try
            {
                var kindOfSport = new KindOfSport { Name = name };
                if (description != null)
                {
                    string fn = description.FileName;
                    string path = Server.MapPath("~/Content/Media/KindsOfSports/" + fn);
                    description.SaveAs(path);
                    kindOfSport.Description = "/Content/Media/KindsOfSports/" + fn;
                }
                db.KindsOfSports.Add(kindOfSport);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("KindsOfSports");
        }

        [HttpGet]
        public ActionResult DeleteKindOfSport(int id)
        {
            try
            {
                var x = db.KindsOfSports.Find(id);
                db.KindsOfSports.Remove(x);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("KindsOfSports");
        }

        [HttpPost]
        public ActionResult ChangeKindOfSport(int id, string name, HttpPostedFileBase description)
        {
            try
            {
                var x = db.KindsOfSports.First(y => y.Id == id);
                if (name != "") x.Name = name;
                if (description != null)
                {
                    string fn = description.FileName;
                    string path = Server.MapPath("~/Content/Media/KindsOfSports/" + fn);
                    description.SaveAs(path);
                    x.Description = "/Content/Media/KindsOfSports/" + fn;
                }
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("KindsOfSports");
        }

        [HttpPost]
        public ActionResult UploadImagesKindOfSport(int id, IEnumerable<HttpPostedFileBase> uploads)
        {
            List<Image> files = new List<Image>();
            foreach (var file in uploads)
            {
                if (file != null)
                {
                    string fn = Guid.NewGuid().ToString() + ".jpg";
                    string path = Server.MapPath("~/Content/Media/SportsFacilities/" + fn);
                    file.SaveAs(path);
                    files.Add(new Image { Filename = "/Content/Media/SportsFacilities/" + fn });
                }
            }

            db.KindsOfSports.Include(x => x.Images).First(x => x.Id == id).Images.AddRange(files);
            db.SaveChanges();
            return RedirectToAction("KindsOfSports");
        }

        #endregion

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
                        files.Add(new Image { Filename = uploadpath });
                    }
                }
            }
            catch (Exception)
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