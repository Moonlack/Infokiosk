using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Infokiosk.Models;
using Markdig;

namespace Infokiosk.Controllers
{
    public class HomeController : Controller
    {
        public InfoContext db = new InfoContext();

        //Отображение главной страницы пользователя
        public ActionResult Index()
        {
            return View();
        }

        //Отображение страницы "Олимпийские достижения"
        public ActionResult OlympicGames()
        {
            var games = db.Events.Where(x => x.Category.Name.Contains("Олимпийские игры")).Include(x => x.Category).Include(x => x.Images).OrderBy(x => x.Name).ToList();
            return View(games);
        }

        //Отображение страницы "Общая информация"
        public ActionResult About()
        {
            return View();
        }

        //Отображение страница "Экспонаты"
        public ActionResult Exhibits()
        {
            var exhibits = db.Exhibits.Include(x => x.Images).OrderBy(x => x.Name).Where(x => x.Category != "Медаль Олимпийских игр").ToList();
            return View(exhibits);
        }

        //Отображение страницы с описанием экспоната
        public ActionResult ExhibitDescription(int id)
        {
            var exhibit = db.Exhibits.Include(x => x.Images).FirstOrDefault(x => x.Id == id);
            ViewData["Description"] = Markdown.ToHtml(this.GetDescription(exhibit.Description));
            return View(exhibit);
        }

        //Отображение страницы с медалями Олимпийских игр
        public ActionResult Medals()
        {
            var exhibits = db.Exhibits.Include(x => x.Images).OrderBy(x => x.Name).Where(x => x.Category != null).ToList();
            return View(exhibits);
        }

        //Отображение страницы с описанием спортивного события
        public ActionResult EventDescription(int id)
        {
            var ev = db.Events.FirstOrDefault(x => x.Id == id);
            var ach = db.Achievements.Where(x => x.EventId == id)
                     .Include(x => x.Athlete)
                     .Include(x => x.Event)
                     .Include(x => x.Prize).ToList();
            var AthletesOfEvents = db.Events
            .SelectMany(m => m.EventAthletes.Select(mc => mc.Athlete)).Include(x=>x.Images)
            .ToList();
            var model = new EventViewModel
            {
                Event = ev,
                Achievements = ach,
                Athletes = AthletesOfEvents
            };

            ViewData["Description"] = Markdown.ToHtml(this.GetDescription(ev.Description));
            return View(model);
        }

        //Отображение страницы с видами спорта
        public ActionResult KindsOfSports()
        {
            var kindOfSports = db.KindsOfSports.OrderBy(x => x.Name).ToList();
            return View(kindOfSports);
        }

        //Отображение страницы с описанием вида спорта
        public ActionResult KindOfSportDescription(int id)
        {
            var kindOfSport = db.KindsOfSports.Include(x => x.Images).FirstOrDefault(x => x.Id == id);
            ViewData["Description"] = Markdown.ToHtml(this.GetDescription(kindOfSport.Description));
            return View(kindOfSport);
        }

        //Отображение страница со спортивными объектами
        public ActionResult SportsFacilities()
        {
            var model = db.SportsFacilities.OrderBy(x => x.Name).Include(x => x.Images).Include(x => x.Category).ToList();
            return View(model);
        }

        //Отображение страницы с описанием спортивного объекта
        public ActionResult SportsFacilityDescription(int id)
        {
            var sf = db.SportsFacilities.Include(x => x.Images).FirstOrDefault(x => x.Id == id);
            ViewData["Description"] = Markdown.ToHtml(this.GetDescription(sf.Description));
            return View(sf);
        }

        //Отображение страниц с описанием спортсмена
        public ActionResult AthleteDescription(int id)
        {
            var model = db.Athletes.Include(x => x.Images).FirstOrDefault(x => x.Id == id);
            ViewData["Description"] = Markdown.ToHtml(this.GetDescription(model.Description));
            return View(model);
        }

        //Получение текста описания из файла
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}