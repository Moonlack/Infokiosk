using Infokiosk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                Event = new Event(),
                Categories = db.EventCategories.OrderBy(x => x.Name).ToList(),
                Category = new EventCategory()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEvent(Event ev)
        {
            try
            {
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
        public ActionResult ChangeEvent(Event ev)
        {
            try
            {
                var x = db.Events.Find(ev.Id);
                if (ev.Name != null) x.Name = ev.Name;
                if (ev.Category != null) x.Category = ev.Category;
                if (ev.Description != null) x.Description = ev.Description;
                if (ev.Images != null) x.Images = ev.Images;
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
                    string path = Server.MapPath("~/Content/Media/SportsFacilities/" + fn);
                    file.SaveAs(path);
                    files.Add(new Image { Filename = "/Content/Media/SportsFacilities/" + fn });
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
            var model = new AdminExhibitsViewModel { Exhibits = db.Exhibits.ToList(), Exhibit = new Exhibit() };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddExhibit(Exhibit exhibit)
        {
            try
            {
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
        public ActionResult ChangeExhibit(Exhibit exhibit)
        {
            try
            {
                var x = db.Exhibits.Find(exhibit.Id);
                if (exhibit.Name != null) x.Name = exhibit.Name;
                if (exhibit.Category != null) x.Category = exhibit.Category;
                if (exhibit.Description != null) x.Description = exhibit.Description;
                if (exhibit.Images != null) x.Images = exhibit.Images;
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
            var model = new AdminAthletesViewModel { Athletes = db.Athletes.ToList(), Athlete = new Athlete() };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddAthlete(Athlete athlete)
        {
            try
            {
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
        public ActionResult ChangeAthlete(Athlete athlete)
        {
            try
            {
                var x = db.Athletes.Find(athlete.Id);
                if (athlete.Initials != null) x.Initials = athlete.Initials;
                if (athlete.Images != null) x.Images = athlete.Images;
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
            //bool isSavedSuccessfully = true;
            //string fName = "";
            //try
            //{
            //    foreach (string fileName in Request.Files)
            //    {
            //        HttpPostedFileBase file = Request.Files[fileName];
            //        fName = file.FileName;
            //        if (file != null && file.ContentLength > 0)
            //        {
            //            var path = Path.Combine(Server.MapPath("~/Content/Media/Athletes"));
            //            string pathString = Path.Combine(path.ToString());
            //            var fileName1 = Path.GetFileName(file.FileName);
            //            bool isExists = Directory.Exists(pathString);
            //            if (!isExists) Directory.CreateDirectory(pathString);
            //            var uploadpath = string.Format("{0}\\{1}", pathString, file.FileName);
            //            file.SaveAs(uploadpath);
            //            files.Add(new Image { Filename = uploadpath });
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    isSavedSuccessfully = false;
            //}
            //if (isSavedSuccessfully)
            //{
            //    return Json(new
            //    {
            //        Message = fName
            //    });
            //}
            //else
            //{
            //    return Json(new
            //    {
            //        Message = "Error in saving file"
            //    });

            //}
            //db.Images.AddRange(paths);
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

        [HttpPost]
        public ActionResult ChangeAchievement(Achievement Achievement)
        {
            //public int AthleteId { get; set; }
            //public Athlete Athlete { get; set; }

            //public int EventId { get; set; }
            //public Event Event { get; set; }

            //public string KindOfSport { get; set; }

            //public int PrizeId { get; set; }
            //public Prize Prize { get; set; }

            //try
            //{
            //    var x = db.Achievements.Find(Achievement.Id);
            //    if (Achievement.Name != null) x.Name = Achievement.Name;
            //    if (Achievement.Category != null) x.Category = Achievement.Category;
            //    if (Achievement.KindOfSport != null) x.KindOfSport = Achievement.KindOfSport;
            //    if (Achievement.Images != null) x.Images = Achievement.Images;
            //    db.SaveChanges();
            //}
            //catch (Exception)
            //{
            return View("Achievements");
            //}
            //return View("Succes");
        }
        #endregion

        #region SportsFacilities
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
        public ActionResult AddSportsFacility(SportsFacility sportsFaclity)
        {
            try
            {
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
        public ActionResult ChangeSportsFacility(SportsFacility SportsFacility)
        {
            //public int AthleteId { get; set; }
            //public Athlete Athlete { get; set; }

            //public int EventId { get; set; }
            //public Event Event { get; set; }

            //public string KindOfSport { get; set; }

            //public int PrizeId { get; set; }
            //public Prize Prize { get; set; }

            //try
            //{
            //    var x = db.SportsFacilities.Find(SportsFacility.Id);
            //    if (SportsFacility.Name != null) x.Name = SportsFacility.Name;
            //    if (SportsFacility.Category != null) x.Category = SportsFacility.Category;
            //    if (SportsFacility.KindOfSport != null) x.KindOfSport = SportsFacility.KindOfSport;
            //    if (SportsFacility.Images != null) x.Images = SportsFacility.Images;
            //    db.SaveChanges();
            //}
            //catch (Exception)
            //{
            return View("Fail");
            //}
            //return View("Succes");
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
            var model = new AdminKindsOfSportsViewModel { KindsOfSports = db.KindsOfSports.OrderBy(x => x.Name).ToList(), KindOfSport = new KindOfSport() };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddKindOfSport(KindOfSport kindOfSport)
        {
            try
            {
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
        public ActionResult ChangeKindOfSport(KindOfSport kindOfSport)
        {
            try
            {
                var x = db.Events.Find(kindOfSport.Id);
                if (kindOfSport.Name != null) x.Name = kindOfSport.Name;
                if (kindOfSport.Description != null) x.Description = kindOfSport.Description;
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