using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using Infokiosk.Models;
using Markdig;

namespace Infokiosk.Controllers
{
    public class HomeController : Controller
    {
        public InfoContext db = new InfoContext();

        public ActionResult Index()
        {
            return View();
        }

        //Вывод блаблабла
        public ActionResult OlympicGames()
        {
            var games = db.Events.Where(x => x.Category.Name.Contains("Олимпийские игры")).Include(x => x.Achievements).Include(x => x.Category).Include(x => x.Images).OrderBy(x => x.Name).ToList();
            return View(games);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Exhibits()
        {
            var exhibits = db.Exhibits.Include(x => x.Images).OrderBy(x => x.Name).Where(x => x.Category == null).ToList();
            return View(exhibits);
        }

        public ActionResult ExhibitDescription(int id)
        {
            var exhibit = db.Exhibits.Include(x => x.Images).FirstOrDefault(x => x.Id == id);
            ViewData["Description"] = Markdown.ToHtml(this.GetDescription(exhibit.Description));
            return View(exhibit);
        }

        public ActionResult Medals()
        {
            var exhibits = db.Exhibits.Include(x => x.Images).OrderBy(x => x.Name).Where(x => x.Category != null).ToList();
            return View(exhibits);
        }

        public ActionResult EventDescription(int id)
        {
            var model = new EventViewModel
            {
                Event = db.Events.FirstOrDefault(x => x.Id == id),
                Achievements = db.Achievements.Where(x => x.EventId == id)
                     .Include(x => x.Athlete)
                     .Include(x => x.Event)
                     .Include(x => x.Prize).ToList(),
                Athletes = db.Athletes.OrderBy(x => x.Initials).Where(x => x.Achievements.FirstOrDefault().EventId == id).Include(x => x.Images).ToList()
            };
            ViewData["Description"] = Markdown.ToHtml(this.GetDescription(model.Event.Description));
            return View(model);
        }
        public ActionResult KindsOfSports()
        {
            var kindOfSports = db.KindsOfSports.OrderBy(x => x.Name).ToList();
            return View(kindOfSports);
        }

        public ActionResult KindOfSportDescription(int id)
        {
            var kindOfSport = db.KindsOfSports.FirstOrDefault(x => x.Id == id);
            ViewData["Description"] = Markdown.ToHtml(this.GetDescription(kindOfSport.Description));
            return View(kindOfSport);
        }

        public ActionResult SportsFacilities()
        {
            var model = db.SportsFacilities.OrderBy(x => x.Name).Include(x => x.Images).Include(x => x.Category).ToList();
            return View(model);
        }

        public ActionResult SportsFacilityDescription(int id)
        {
            var sf = db.SportsFacilities.Include(x => x.Images).FirstOrDefault(x => x.Id == id);
            ViewData["Description"] = Markdown.ToHtml(this.GetDescription(sf.Description));
            return View(sf);
        }

        public ActionResult AthleteDescription(int id)
        {
            var model = db.Athletes.Include(x => x.Images).FirstOrDefault(x => x.Id == id);
            ViewData["Description"] = Markdown.ToHtml(this.GetDescription(model.Description));
            return View(model);
        }

        public string GetDescription(string path)
        {
            try
            {
                using (var sr = new StreamReader(Server.MapPath("~/" + path), System.Text.Encoding.Default))
                { return sr.ReadToEnd(); };

            }
            catch (Exception)
            {
                return "Возникла ошибка при загрузке файла. Проверьте наличие файла";
            }

        }
    }
}