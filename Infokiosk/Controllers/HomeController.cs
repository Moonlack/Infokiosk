using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using Infokiosk.Models;

namespace Infokiosk.Controllers
{
    public class HomeController : Controller
    {
        private InfoContext db = new InfoContext();

        public ActionResult Index()
        {
            return View();
        }

      public ActionResult OlympicGames()
        {
            var games = db.Events.Include(x => x.Achievements).ToList();

            return View(games);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Exhibits()
        {
            var exhibits = db.Exhibits.Where(x=>x.Category==null).ToList();
            return View(exhibits);
        }

        public ActionResult Medals()
        {
            var exhibits = db.Exhibits.Where(x => x.Category != null).ToList();
            return View(exhibits);
        }

        public ActionResult Description(int id)
        {
            var model = new EventViewModel
            {
                Event = db.Events.FirstOrDefault(x => x.Id == id),
                Achievements = db.Achievements.Where(x => x.EventId == id)
                    .Include(x => x.Athlete)
                    .Include(x => x.Event)
                    .Include(x => x.Prize)
                    .ToList(),
                Athletes = db.Athletes.Where(x => x.Achievements.FirstOrDefault().EventId == id).ToList()
            };

            return View("DescriptionEvent", model);
        }
    }
}