using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Infokiosk.Models
{
    public class InfoDbInitializer : CreateDatabaseIfNotExists<InfoContext>
    //: DropCreateDatabaseAlways<InfoContext>
    {
        protected override void Seed(InfoContext db)
        {
            var pr1 = new Prize { Name = "Золотая медаль" };
            var pr2 = new Prize { Name = "Серебряная медаль" };
            var pr3 = new Prize { Name = "Бронзовая медаль" };
            var pr4 = new Prize { Name = "Знаменосец" };

            var athl1 = new Athlete { Initials = "Вадим Махнев" };
            var athl2 = new Athlete { Initials = "Александр Романьков" };
            var athl3 = new Athlete { Initials = "Алексей Аблмасов" };
            var athl4 = new Athlete { Initials = "Артур Литвинчук" };
            var athl5 = new Athlete { Initials = "Роман Петрушенко" };
            var athl6 = new Athlete { Initials = "Андрей Арямнов" };

            var ev2 = new Event { Name = "Лондон 2012", Category = "Summer Olympic Games", Images = @"/Content/Media/OlympicGames/London 2012" };
            var ev1 = (new Event { Name = "Пекин 2008", Category = "Summer Olympic Games", Images = @"/Content/Media/OlympicGames/Beijing 2008" });
            var ev3 = (new Event { Name = "Атланта 1996", Category = "Summer Olympic Games", Images = @"/Content/Media/OlympicGames/Atlanta 1996" });
            var ev4 = (new Event { Name = "Сидней 2000", Category = "Summer Olympic Games", Images = @"/Content/Media/OlympicGames/Sydney 2000" });
            var ev5 = (new Event { Name = "Афины 2004", Category = "Summer Olympic Games", Images = @"/Content/Media/OlympicGames/Afiny 2004" });

            var ev6 = (new Event { Name = "Нагано 1998", Category = "Winter Olympic Games", Images = @"/Content/Media/OlympicGames/Nagano 1998" });
            var ev7 = (new Event { Name = "Лиллехаммер 1994", Category = "Winter Olympic Games", Images = @"/Content/Media/OlympicGames/Lillehammer 1994" });
            var ev8 = (new Event { Name = "Турин 2006", Category = "Winter Olympic Games", Images = @"/Content/Media/OlympicGames/Torino 2006" });
            var ev9 = (new Event { Name = "Ванкувер 2010", Category = "Winter Olympic Games", Images = @"/Content/Media/OlympicGames/Vancouver 2010" });
            var ev10 = (new Event { Name = "Солт-Лейк-сити 2002", Category = "Winter Olympic Games", Images = @"/Content/Media/OlympicGames/Salt-Lake-Sity 2002" });

            var ach1 = new Achievement { Athlete = athl1, Event = ev1, Prize = pr1, KindOfSport = "Гребля на байдарках и каноэ, байдарка-четверка" };
            var ach2 = new Achievement { Athlete = athl1, Event = ev1, Prize = pr3, KindOfSport = "Гребля на байдарках и каноэ, байдарка-двойка" };
            var ach3 = new Achievement { Athlete = athl3, Event = ev1, Prize = pr1, KindOfSport = "Гребля на байдарках и каноэ, байдарка-четверка" };
            var ach4 = new Achievement { Athlete = athl4, Event = ev1, Prize = pr1, KindOfSport = "Гребля на байдарках и каноэ, байдарка-четверка" };
            var ach5 = new Achievement { Athlete = athl5, Event = ev1, Prize = pr1, KindOfSport = "Гребля на байдарках и каноэ, байдарка-четверка" };
            var ach6 = new Achievement { Athlete = athl5, Event = ev1, Prize = pr3, KindOfSport = "Гребля на байдарках и каноэ, байдарка-двойка" };
            var ach7 = new Achievement { Athlete = athl2, Event = ev1, Prize = pr4 };
            var ach8 = new Achievement { Athlete = athl6, Event = ev1, Prize = pr1, KindOfSport = "Тяжелая атлетика, до 105 кг" };

            var ex1 = new Exhibit { Name = "Комплект спортинвной формы и кубок Д. Домрачевой", Description = "" };
            var ex2 = new Exhibit { Name = "Олимпийская форма игр в Пекине, 2008 г.", Description = "" };
            var ex3 = new Exhibit { Name = "Ракетки М. Мирного и В. Азаренко", Description = "" };
            var ex4 = new Exhibit { Name = "Кубок А. Медведя", Description = "" };
            var ex5 = new Exhibit { Name = "Краги Р. Салея", Description = "" };
            var ex6 = new Exhibit { Name = "Медали и сертификаты паралимпийцев", Description = "" };
            var ex7 = new Exhibit { Name = "Награды А. Гришина", Description = "" };
            var ex8 = new Exhibit { Name = "Медаль М.Лобач", Description = "" };
            var ex9 = new Exhibit { Name = "Олимпийский факел игр в Пекине, 2008 г.", Description = "" };

            var ex10 = new Exhibit { Name = "Медаль зимних Олимпийских игр в Лиллехамере 1994 г.", Description = "", Category = "Медаль Олимпийских игр" };
            var ex11 = new Exhibit { Name = "Медаль зимних Олимпийских игр в Турине 2006 г.", Description = "", Category = "Медаль Олимпийских игр" };
            var ex12 = new Exhibit { Name = "Медаль зимних Олимпийских игр в Ванкувере 2010 г.", Description = "", Category = "Медаль Олимпийских игр" };
            var ex13 = new Exhibit { Name = "Медаль зимних Олимпийских игр в Солт-Лейк-Сити 2002 г.", Description = "", Category = "Медаль Олимпийских игр" };
            var ex14 = new Exhibit { Name = "Медаль зимних Олимпийских игр в Нагано 1998 г.", Description = "", Category = "Медаль Олимпийских игр" };
            var ex15 = new Exhibit { Name = "Медаль летних Олимпийских игр в Атланте 1996 г.", Description = "", Category = "Медаль Олимпийских игр" };
            var ex16 = new Exhibit { Name = "Медаль летних Олимпийских игр в Сиднее 2000 г.", Description = "", Category = "Медаль Олимпийских игр" };
            var ex17 = new Exhibit { Name = "Медаль летних Олимпийских игр в Афинах 2004 г.", Description = "", Category = "Медаль Олимпийских игр" };
            var ex18 = new Exhibit { Name = "Медаль летних Олимпийских игр в Пекине 2008 г.", Description = "", Category = "Медаль Олимпийских игр" };
            var ex19 = new Exhibit { Name = "Медаль летних Олимпийских игр в Лондоне 2010 г.", Description = "", Category = "Медаль Олимпийских игр" };

            var ks1 = new KindOfSport { Name = "Хоккей с шайбой" };
            var ks2 = new KindOfSport { Name = "Биатлон" };
            var ks3 = new KindOfSport { Name = "Теннис" };
            var ks4 = new KindOfSport { Name = "Гребля" };
            var ks5 = new KindOfSport { Name = "Легкая атлетика" };
            var ks6 = new KindOfSport { Name = "Плавание" };
            var ks7 = new KindOfSport { Name = "Тяжелая атлетика" };
            var ks8 = new KindOfSport { Name = "Фристайл" };
            var ks9 = new KindOfSport { Name = "Бокс" };
            var ks10 = new KindOfSport { Name = "Гимнастика" };
            var ks11 = new KindOfSport { Name = "Борьба" };
            var ks12 = new KindOfSport { Name = "Футбол" };
            var ks13 = new KindOfSport { Name = "Фехтование" };
            var ks14 = new KindOfSport { Name = "Настольный тенис" };


            var c1 = new SportsFacilityCategory { Name = "Многофункциональные культурно-спортивные комплексы" };
            var c2 = new SportsFacilityCategory { Name = "Гребные каналы" };
            var c3 = new SportsFacilityCategory { Name = "Ледовые дворцы" };
            var c4 = new SportsFacilityCategory { Name = "Другие спортивные сооружения" };

            //var sf1 = new SportsFacility { Name = "МКСК Минск-арена", Category = c1 };
            //var sf2 = new SportsFacility { Name = "МКСК Бобруйск-арена", Category = c1 };
            //var sf3 = new SportsFacility { Name = "Ледовый дворец спорта в Барановичах", Category = c3};
            //var sf4 = new SportsFacility { Name = "Ледовый дворец спорта в Гродно", Category = c3 };
            //var sf5 = new SportsFacility { Name = "Ледовая арена в Пружанах", Category = c3};
            //var sf6 = new SportsFacility { Name = "Гребной канал в Бресте", Category = c2 };
            //var sf7 = new SportsFacility { Name = "РЦОП по гребным видам спорта в Заславле", Category = c2};
            //var sf8 = new SportsFacility { Name = "РЦОП по теннису в Минске", Category = c4 };
            //var sf9 = new SportsFacility { Name = "Олимпийский спортивный комлекс \"Стайки\"", Category = c4 };
            //var sf10 = new SportsFacility { Name ="", Category = ,Images = ""};
            //var sf10 = new SportsFacility { Name = "", Category = , Images = "" };
            //var sf10 = new SportsFacility { Name = "", Category = , Images = "" };
            //var sf10 = new SportsFacility { Name = "", Category = , Images = "" };
            //var sf10 = new SportsFacility { Name = "", Category = , Images = "" };
            //var sf10 = new SportsFacility { Name = "", Category = , Images = "" };
            //var sf10 = new SportsFacility { Name = "", Category = , Images = "" };
            //var sf10 = new SportsFacility { Name = "", Category = , Images = "" };
            //var sf10 = new SportsFacility { Name = "", Category = , Images = "" };
            //var sf10 = new SportsFacility { Name = "", Category = , Images = "" };
            //var sf20 = new SportsFacility { Name = "", Category = , Images = "" };

            db.SportsFacilityCategories.AddRange(new List<SportsFacilityCategory> { c1, c2, c3, c4 });
            //db.SportsFacilities.AddRange(new List<SportsFacility> { sf1, sf2, sf3, sf4, sf5, sf6, sf7, sf8, sf9 });

            db.Prizes.AddRange(new List<Prize> { pr1, pr2, pr3, pr4 });
            db.Athletes.AddRange(new List<Athlete> { athl1, athl2, athl3, athl4, athl5, athl6 });
            db.Events.AddRange(new List<Event> { ev1, ev2, ev3, ev4, ev5, ev6, ev7, ev8, ev9, ev10 });
            db.Achievements.AddRange(new List<Achievement> { ach1, ach2, ach3, ach4, ach5, ach6, ach7, ach8 });
            db.Exhibits.AddRange(new List<Exhibit>
            {
                ex1,
                ex2,
                ex3,
                ex4,
                ex5,
                ex6,
                ex7,
                ex8,
                ex9,
                ex10,
                ex11,
                ex12,
                ex13,
                ex14,
                ex15,
                ex16,
                ex17,
                ex18,
                ex19
            });
            db.KindsOfSports.AddRange(new List<KindOfSport> { ks1, ks2, ks3, ks4, ks5, ks6, ks7, ks8, ks9, ks10, ks11, ks12, ks13, ks14 });

            db.SaveChanges();
        }
    }
}