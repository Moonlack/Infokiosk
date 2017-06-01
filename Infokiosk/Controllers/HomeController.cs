using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using Infokiosk.Models;

namespace Infokiosk.Controllers
{
    public class HomeController : Controller
    {
        public InfoContext db = new InfoContext();

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
            return View();
        }

        public ActionResult Exhibits()
        {
            var exhibits = db.Exhibits.Where(x => x.Category == null).ToList();
            return View(exhibits);
        }

        public ActionResult ExhibitDescription(int id)
        {
            var exhibit = db.Exhibits.FirstOrDefault(x => x.Id == id);
            return View(exhibit);
        }

        public ActionResult Medals()
        {
            var exhibits = db.Exhibits.Where(x => x.Category != null).ToList();
            return View(exhibits);
        }

        public ActionResult EventDescription(int id)
        {
           var model = new EventViewModel
            {
                Event = db.Events.FirstOrDefault(x => x.Id == id),
                //Files = Directory.GetFiles(db.Events.FirstOrDefault(x => x.Id == id).Description).ToList(),
                Achievements = db.Achievements.Where(x => x.EventId == id)
                    .Include(x => x.Athlete)
                    .Include(x => x.Event)
                    .Include(x => x.Prize)
                    .ToList(),
                Athletes = db.Athletes.Where(x => x.Achievements.FirstOrDefault().EventId == id).ToList()
            };

            return View(model);
        }
        public ActionResult KindsOfSports()
        {
            var kindOfSports = db.KindsOfSports.ToList();
            return View(kindOfSports);
        }

        public ActionResult KindOfSportDescription(int id)
        {
            var kindOfSport = db.KindsOfSports.FirstOrDefault(x => x.Id == id);
            return View(kindOfSport);
        }

        public ActionResult SportsFacilities()
        {
            var model = db.SportsFacilityCategories.Include(x => x.SportsFacilities).ToList();
            return View(model);
        }

        public ActionResult SportsFacilityDescription(int id)
        {
            var sf = db.SportsFacilities.FirstOrDefault(x => x.Id == id);
            //var img = Directory.EnumerateFiles(Server.MapPath(sf.Images)).ToArray();
            //for(int i=0;i<img.Count();i++)
            //{
            //    img[i] =@"\"+img[i].Remove(0, img[i].IndexOf("Content"));
            //}
            //var model = new SportsFacilityViewModel { SportsFacility = sf,Images= img.ToList() };
            return View(sf);
        }

        public ActionResult AthleteDescription(int id)
        {
            var model = db.Athletes.FirstOrDefault(x => x.Id == id);
            return View(model);
        }

    }
}