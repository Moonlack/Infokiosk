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

        //Отображение страница для администрирования экспонатов
        public ActionResult Index()
        {
            return RedirectToAction("Exhibits");
        }

        #region Events
        //Отображение страница для администрирования событий
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

        //Добавление события
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

        //Удаление выбранного события
        [HttpGet]
        public ActionResult DeleteEvent(int id)
        {
            try
            {
                var x = db.Events.Find(id);
                var img = db.Images.Where(i => i.Event.Id == id);
                db.Images.RemoveRange(img);
                db.Events.Remove(x);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("Events");
        }

        //Изменение выбранного события
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

        //Загрузка изображений для выбранного события
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

        //Добавление категории события
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

        //Удаление выбранной категории события
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

        //Отображение страница для администрирования экспонатов
        public ActionResult Exhibits()
        {
            var model = db.Exhibits.OrderBy(x => x.Name).ToList();
            return View(model);
        }

        //Добавление экспоната
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

        //Удаление выбранного экспоната
        [HttpGet]
        public ActionResult DeleteExhibit(int id)
        {
            try
            {
                var x = db.Exhibits.Find(id);
                var img = db.Images.Where(i => i.Exhibit.Id == id);
                db.Images.RemoveRange(img);
                db.Exhibits.Remove(x);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("Exhibits");
        }

        //Изменение выбранного экспоната
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

        //Загрузка изображений для выбранного экспоната
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

        //Отображение страница для администрирования спортсменов
        public ActionResult Athletes()
        {
            var model = db.Athletes.OrderBy(x => x.Initials).ToList();
            return View(model);
        }

        //Добавление спортсмена
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

        //Удаление выбранного спортсмена
        [HttpGet]
        public ActionResult DeleteAthlete(int id)
        {
            try
            {
                var x = db.Athletes.Find(id);
                var img = db.Images.Where(i => i.Athlete.Id == id);
                db.Images.RemoveRange(img);
                db.Athletes.Remove(x);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("Athletes");
        }

        //Изменение выбранного спортсмена
        [HttpPost]
        public ActionResult ChangeAthlete(int id, string initials, HttpPostedFileBase description)
        {
            try
            {
                var x = db.Athletes.First(y => y.Id == id);
                if (initials != "") x.Initials = initials;
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

        //Загрузка изображений для выбранного спортсмена
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

        //Отображение страница для администрирования достижений
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

        //Добавление достижения
        [HttpPost]
        public ActionResult AddAchievement(int athleteId, int eventId, string kindOfSport, int prizeId)
        {
            try
            {
                var ev = db.Events.First(x => x.Id == eventId);
                var athl = db.Athletes.Where(c => c.Id == athleteId).SingleOrDefault();

                if (athl != null && ev != null)
                {
                    var ea = db.EventAthletes.Where(c => c.AthleteId == athleteId && c.EventId == eventId).SingleOrDefault();
                    if (ea == null)
                    {
                        var eventAthletes = new EventAthletes
                        {
                            Event = ev,
                            Athlete = athl
                        };
                        db.EventAthletes.Add(eventAthletes);
                        db.SaveChanges();
                    }
                }
                db.Achievements.Add(new Achievement { AthleteId = athleteId, EventId = eventId, KindOfSport = kindOfSport, PrizeId = prizeId });
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("Achievements");
        }

        //Удаление выбранного достижения
        [HttpGet]
        public ActionResult DeleteAchievement(int id)
        {
            try
            {
                var a = db.Achievements.Find(id);
                var count = db.Achievements.Count(x => x.AthleteId == a.AthleteId && x.EventId == a.EventId);
                if (count == 1)
                {
                    var eventAthlete = db.EventAthletes
                        .Where(mc => mc.Event.Id == a.EventId && mc.Athlete.Id == a.AthleteId)
                        .SingleOrDefault();
                    if (eventAthlete != null)
                    {
                        db.EventAthletes.Remove(eventAthlete);
                        db.SaveChanges();
                    }
                }
                db.Achievements.Remove(a);
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

        //Отображение страница для администрирования спортивных объектов
        public ActionResult SportsFacilities()
        {
            var model = new AdminSportsFacilitiesViewModel
            {
                SportsFacilities = db.SportsFacilities.ToList(),
                Categories = db.SportsFacilityCategories.ToList()
            };
            return View(model);
        }

        //Добавление спортивного объекта
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

        //Удаление выбранного спортивного объекта
        [HttpGet]
        public ActionResult DeleteSportsFacility(int id)
        {
            try
            {
                var x = db.SportsFacilities.Find(id);
                var img = db.Images.Where(i => i.SportsFacility.Id == id);
                db.Images.RemoveRange(img);
                db.SportsFacilities.Remove(x);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("SportsFacilities");
        }

        //Изменение выбранного спортивного объекта
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

        //Загрузка изображений для выбранного спортивного объекта
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

        //Отображение страница для администрирования видов спорта
        public ActionResult KindsOfSports()
        {
            var model = db.KindsOfSports.OrderBy(x => x.Name).ToList();
            return View(model);
        }

        //Добавление вид спорта
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

        //Удаление выбранного вида спорта
        [HttpGet]
        public ActionResult DeleteKindOfSport(int id)
        {
            try
            {
                var x = db.KindsOfSports.Find(id);
                var img = db.Images.Where(i => i.KindOfSport.Id == id);
                db.Images.RemoveRange(img);
                db.KindsOfSports.Remove(x);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return View("Fail");
            }
            return RedirectToAction("KindsOfSports");
        }

        //Изменение выбранного вида спорта
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

        //Загрузка изображений для выбранного вида спорта
        [HttpPost]
        public ActionResult UploadImagesKindOfSport(int id, IEnumerable<HttpPostedFileBase> uploads)
        {
            List<Image> files = new List<Image>();
            foreach (var file in uploads)
            {
                if (file != null)
                {
                    string fn = Guid.NewGuid().ToString() + ".jpg";
                    string path = Server.MapPath("~/Content/Media/KindsOfSports/" + fn);
                    file.SaveAs(path);
                    files.Add(new Image { Filename = "/Content/Media/KindsOfSports/" + fn });
                }
            }

            db.KindsOfSports.Include(x => x.Images).First(x => x.Id == id).Images.AddRange(files);
            db.SaveChanges();
            return RedirectToAction("KindsOfSports");

        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}