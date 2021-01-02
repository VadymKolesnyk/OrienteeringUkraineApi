using OrienteeringUkraine.Domain.Entities;
using OrienteeringUkraine.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrienteeringUkraine.Data.Seeding.Extensions
{
    public static class OrienteeringUkraineContextExtensions
    {
        public static void Seed(this OrienteeringUkraineContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!context.Regions.Any())
            {
                context.Regions.AddRange(
                    new Region { Name = "АР Крым" },
                    new Region { Name = "Винницкая" },
                    new Region { Name = "Волынская" },
                    new Region { Name = "Днепропетровская" },
                    new Region { Name = "Донецкая" },
                    new Region { Name = "Житомирская" },
                    new Region { Name = "Закарпатская" },
                    new Region { Name = "Запорожская" },
                    new Region { Name = "Ивано-Франковская" },
                    new Region { Name = "Город Киев" },
                    new Region { Name = "Киевская" },
                    new Region { Name = "Кировоградская" },
                    new Region { Name = "Луганская" },
                    new Region { Name = "Львовская" },
                    new Region { Name = "Николаевская" },
                    new Region { Name = "Одесская" },
                    new Region { Name = "Полтавская" },
                    new Region { Name = "Ровенская" },
                    new Region { Name = "Город Севастополоть" },
                    new Region { Name = "Сумская" },
                    new Region { Name = "Тернопольская" },
                    new Region { Name = "Харьковская" },
                    new Region { Name = "Херсонская" },
                    new Region { Name = "Хмельницкая" },
                    new Region { Name = "Черкасская" },
                    new Region { Name = "Черниговская" },
                    new Region { Name = "Черновицкая" }
                    );
                context.SaveChanges();
            }
            Role admin, moderator, organizer, sportsmen;
            if (!context.Roles.Any())
            {
                admin = new Role { Name = "admin" };
                moderator = new Role { Name = "moderator" };
                organizer = new Role { Name = "organizer" };
                sportsmen = new Role { Name = "sportsmen" };
                context.Roles.AddRange(admin, moderator, organizer, sportsmen);
                context.SaveChanges();
            }
            else
            {
                admin = context.Roles.First(r => r.Name == "admin");
                moderator = context.Roles.First(r => r.Name == "moderator" );
                organizer = context.Roles.First(r => r.Name == "organizer" );
                sportsmen = context.Roles.First(r => r.Name == "sportsmen" );
            }
            if (!context.Clubs.Any())
            {
                context.Clubs.AddRange(
                    new Club { Name = "Orientir"},
                    new Club { Name = "FOXHUNTERS"},
                    new Club { Name = "Sever"},
                    new Club { Name = "Master"},
                    new Club { Name = "NORD"},
                    new Club { Name = "Kompas"},
                    new Club { Name = "WindAndSand"},
                    new Club { Name = "Olimp"},
                    new Club { Name = "Olimpycs"},
                    new Club { Name = "Odessa Team"},
                    new Club { Name = "Cherkasy Team"},
                    new Club { Name = "Runners"},
                    new Club { Name = "Good players"},
                    new Club { Name = "Just Run It"},
                    new Club { Name = "The best"},
                    new Club { Name = "Vadim`s Command"},
                    new Club { Name = "Volyn"},
                    new Club { Name = "Voshod"},
                    new Club { Name = "Vodorgay"},
                    new Club { Name = "DududuDudin"},
                    new Club { Name = "Balas Team"},
                    new Club { Name = "Lazy Cows"},
                    new Club { Name = "Designers Club"},
                    new Club { Name = "Everest"},
                    new Club { Name = "Forest"},
                    new Club { Name = "Dnpiprovski porohy"},
                    new Club { Name = "Yuli voliy"},
                    new Club { Name = "Roshen sweets"},
                    new Club { Name = "We are from Sever"},
                    new Club { Name = "Kyslyi - Sladkyi"},
                    new Club { Name = "Hot-dogs"},
                    new Club { Name = "Dream Team"},
                    new Club { Name = "Geeey Club"},
                    new Club { Name = "Crazy Beavers"},
                    new Club { Name = "FP KPI"},
                    new Club { Name = "Coders"},
                    new Club { Name = "Armane"},
                    new Club { Name = "Ded inside"},
                    new Club { Name = "Gucci flip flap"},
                    new Club { Name = "Cadence"},
                    new Club { Name = "Rythm"},
                    new Club { Name = "Pulse"},
                    new Club { Name = "Blood preasure"},
                    new Club { Name = "Your team"},
                    new Club { Name = "Lesnaya"},
                    new Club { Name = "Pineapples"},
                    new Club { Name = "Fast Snakes"},
                    new Club { Name = "Finish"},
                    new Club { Name = "Start"},
                    new Club { Name = "Faster"},
                    new Club { Name = "Solid"},
                    new Club { Name = "Corona-virus"}
                    );
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                int i = 1;
                List<User> users = new()
                {
                    new User
                    {
                        Login = "admin",
                        Name = "Super",
                        Surname = "Admin",
                        BirthDate = new DateTime(2000, 1, 1),
                        Role = admin,
                        RegionId = 1,
                    },
                    new User
                    {
                        Login = "moderator1",
                        Name = "Вадим",
                        Surname = "Колесник",
                        BirthDate = new DateTime(2001, 2, 19),
                        Role = moderator,
                        RegionId = 17,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "moderator2",
                        Name = "Екатерина",
                        Surname = "Кубышка",
                        BirthDate = new DateTime(2000, 9, 23),
                        Role = moderator,
                        RegionId = 17,
                        ClubId = 3,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "moderator3",
                        Name = "Сергей",
                        Surname = "Переяславский",
                        BirthDate = new DateTime(2000, 11, 22),
                        Role = organizer,
                        RegionId = 11,
                        ClubId = 2,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "moderator4",
                        Name = "Александр",
                        Surname = "Дзюбчик",
                        BirthDate = new DateTime(2001, 3, 24),
                        Role = moderator,
                        RegionId = 3,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "organizer1",
                        Name = "Биба",
                        Surname = "Бобович",
                        BirthDate = new DateTime(2005, 2, 20),
                        Role = organizer,
                        RegionId = 17,
                        ClubId = 4
                    },
                    new User
                    {
                        Login = "organizer2",
                        Name = "Максим",
                        Surname = "Гапонюк",
                        BirthDate = new DateTime(2000, 12, 4),
                        Role = organizer,
                        RegionId = 3,
                        ClubId = 3,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Гибон",
                        Surname = "Пожилой",
                        BirthDate = new DateTime(1900, 2, 2),
                        Role = sportsmen,
                        RegionId = 3,
                        ClubId = 1
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Тарас",
                        Surname = "Рачук",
                        BirthDate = new DateTime(1998, 7, 28),
                        Role = sportsmen,
                        RegionId = 25,
                        ClubId = 1,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Сергей",
                        Surname = "Поникаров",
                        BirthDate = new DateTime(1982, 2, 23),
                        Role = sportsmen,
                        RegionId = 25,
                        ClubId = 4,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Надежда",
                        Surname = "Сердюк",
                        BirthDate = new DateTime(1953, 6, 25),
                        Role = sportsmen,
                        RegionId = 10,
                        ClubId = 4,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Олег",
                        Surname = "Скляр",
                        BirthDate = new DateTime(1985, 5, 25),
                        Role = sportsmen,
                        RegionId = 5,
                        ClubId = 1,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Елена",
                        Surname = "Стрыжак",
                        BirthDate = new DateTime(1963, 10, 7),
                        Role = sportsmen,
                        RegionId = 17,
                        ClubId = 4,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Галина",
                        Surname = "Строчук",
                        BirthDate = new DateTime(1977, 7, 26),
                        Role = sportsmen,
                        RegionId = 18,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Сергей",
                        Surname = "Тарасенко",
                        BirthDate = new DateTime(1972, 4, 28),
                        Role = sportsmen,
                        RegionId = 22,
                        ClubId = 1,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Наталия",
                        Surname = "Уманец",
                        BirthDate = new DateTime(1978, 1, 19),
                        Role = sportsmen,
                        RegionId = 25,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Александр",
                        Surname = "Уфимцев",
                        BirthDate = new DateTime(1957, 10, 29),
                        Role = sportsmen,
                        RegionId = 5,
                        ClubId = 1,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Андрей",
                        Surname = "Алёшин",
                        Role = sportsmen,
                        RegionId = 7,
                        ClubId = 5,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Владимир",
                        Surname = "Бондаренко",
                        BirthDate = new DateTime(1959, 7, 28),
                        Role = sportsmen,
                        RegionId = 5,
                        ClubId = 5,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Владислав",
                        Surname = "Вовк",
                        BirthDate = new DateTime(1968, 11, 21),
                        Role = sportsmen,
                        RegionId = 5,
                        ClubId = 6,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Артур",
                        Surname = "Ганилов",
                        BirthDate = new DateTime(1968, 5, 12),
                        Role = sportsmen,
                        RegionId = 6,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Виталий",
                        Surname = "Кличко",
                        BirthDate = new DateTime(1999, 9, 21),
                        Role = sportsmen,
                        RegionId = 17,
                        ClubId = 5,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Евгений",
                        Surname = "Гевел",
                        BirthDate = new DateTime(1956, 4, 2),
                        Role = sportsmen,
                        RegionId = 4,
                        ClubId = 6,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Мария",
                        Surname = "Гудак",
                        Role = sportsmen,
                        RegionId = 26,
                        ClubId = 4,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Руслан",
                        Surname = "Шимчук",
                        BirthDate = new DateTime(1968, 7, 22),
                        Role = sportsmen,
                        RegionId = 20,
                        ClubId = 7,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Евгений",
                        Surname = "Чёрный",
                        BirthDate = new DateTime(2001, 2, 12),
                        Role = sportsmen,
                        RegionId = 5,
                        ClubId = 4,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Руслан",
                        Surname = "Шимчук",
                        BirthDate = new DateTime(2008, 12, 2),
                        Role = sportsmen,
                        RegionId = 21,
                        ClubId = 6,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Анастасия",
                        Surname = "Костюк",
                        BirthDate = new DateTime(2002, 2, 16),
                        Role = sportsmen,
                        RegionId = 1,
                        ClubId = 7,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Юлия",
                        Surname = "Азарова",
                        BirthDate = new DateTime(1999, 11, 6),
                        Role = sportsmen,
                        RegionId = 15,
                        ClubId = 5,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Анна",
                        Surname = "Марусиченко",
                        BirthDate = new DateTime(2004, 7, 24),
                        Role = sportsmen,
                        RegionId = 26,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Дарья",
                        Surname = "Томаш",
                        BirthDate = new DateTime(2001, 5, 12),
                        Role = sportsmen,
                        RegionId = 27,
                        ClubId = 7,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Юлия",
                        Surname = "Бугаец",
                        BirthDate = new DateTime(1997, 2, 2),
                        Role = sportsmen,
                        RegionId = 7,
                        ClubId = 6,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Светлана",
                        Surname = "Пашиста",
                        BirthDate = new DateTime(2003, 8, 23),
                        Role = sportsmen,
                        RegionId = 9,
                        ClubId = 7,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Татьяна",
                        Surname = "Клепикова",
                        BirthDate = new DateTime(1995, 6, 20),
                        Role = sportsmen,
                        RegionId = 4,
                        ClubId = 5,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Татьяна",
                        Surname = "Олейник",
                        Role = sportsmen,
                        RegionId = 22,
                        ClubId = 5,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Александр",
                        Surname = "Авраменко",
                        BirthDate = new DateTime(1977, 7, 18),
                        Role = sportsmen,
                        RegionId = 25,
                        ClubId = 7,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Василий",
                        Surname = "Рублевский",
                        BirthDate = new DateTime(1999, 4, 8),
                        Role = sportsmen,
                        RegionId = 14,
                        ClubId = 6,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Карина",
                        Surname = "Бойсюк",
                        BirthDate = new DateTime(1978, 4, 12),
                        Role = sportsmen,
                        RegionId = 24,
                        ClubId = 4,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Анна",
                        Surname = "Волкова",
                        BirthDate = new DateTime(2002, 3, 2),
                        Role = sportsmen,
                        RegionId = 12,
                        ClubId = 6,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Полина",
                        Surname = "Волошина",
                        BirthDate = new DateTime(1972, 6, 12),
                        Role = sportsmen,
                        RegionId = 4,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Дарья",
                        Surname = "Гладкая",
                        Role = sportsmen,
                        RegionId = 20,
                        ClubId = 6,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Марьяна",
                        Surname = "Демченко",
                        BirthDate = new DateTime(2003, 2, 1),
                        Role = sportsmen,
                        RegionId = 7,
                        ClubId = 4,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Дарья",
                        Surname = "Додон",
                        BirthDate = new DateTime(2001, 12, 12),
                        Role = sportsmen,
                        RegionId = 5,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Инна",
                        Surname = "Игнатьева",
                        BirthDate = new DateTime(1993, 2, 26),
                        Role = sportsmen,
                        RegionId = 6,
                        ClubId = 6,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Евгения",
                        Surname = "Магас",
                        Role = sportsmen,
                        RegionId = 17,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Наталия",
                        Surname = "Малькова",
                        BirthDate = new DateTime(1984, 4, 17),
                        Role = sportsmen,
                        RegionId = 19,
                        ClubId = 5,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Анастасия",
                        Surname = "Мищук",
                        BirthDate = new DateTime(1994, 8, 27),
                        Role = sportsmen,
                        RegionId = 9,
                        ClubId = 5,
                        Sex = Sex.Female,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Тарас",
                        Surname = "Гаврилюк",
                        BirthDate = new DateTime(2001, 8, 7),
                        Role = sportsmen,
                        RegionId = 19,
                        ClubId = 6,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Максим",
                        Surname = "Дворный",
                        BirthDate = new DateTime(1956, 3, 27),
                        Role = sportsmen,
                        RegionId = 23,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Михаил",
                        Surname = "Давиденко",
                        BirthDate = new DateTime(1986, 8, 7),
                        Role = sportsmen,
                        RegionId = 26,
                        ClubId = 6,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Богдан",
                        Surname = "Кабанов",
                        BirthDate = new DateTime(1985, 4, 27),
                        Role = sportsmen,
                        RegionId = 14,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Денис",
                        Surname = "Кобзар",
                        BirthDate = new DateTime(1965, 4, 12),
                        Role = sportsmen,
                        RegionId = 17,
                        ClubId = 1,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Владимир",
                        Surname = "Куцак",
                        BirthDate = new DateTime(2001, 7, 11),
                        Role = sportsmen,
                        RegionId = 11,
                        ClubId = 6,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Константин",
                        Surname = "Комарницкий",
                        BirthDate = new DateTime(1991, 6, 1),
                        Role = sportsmen,
                        RegionId = 16,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Юрий",
                        Surname = "Черняк",
                        BirthDate = new DateTime(2000, 4, 12),
                        Role = sportsmen,
                        RegionId = 21,
                        ClubId = 7,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Андрей",
                        Surname = "Андрусяк",
                        BirthDate = new DateTime(1994, 10, 7),
                        Role = sportsmen,
                        RegionId = 11,
                        ClubId = 5,
                        Sex = Sex.Male,
                    },
                    new User
                    {
                        Login = "sportsmen" + i++,
                        Name = "Иван",
                        Surname = "Беляев",
                        BirthDate = new DateTime(1965, 10, 5),
                        Role = sportsmen,
                        RegionId = 8,
                        Sex = Sex.Male,
                    }
                };
                List<LoginData> logins = users.Select(u => new LoginData 
                                                        { 
                                                            Login = u.Login, 
                                                            HashedPassword = Hashing.HashPassword(u.Login) 
                                                        }).ToList();
                context.Users.AddRange(users);
                context.Logins.AddRange(logins);
                context.SaveChanges();
            }
            if (!context.Groups.Any())
            {
                context.Groups.AddRange(
                    new Group { Name = "Ж12" },
                    new Group { Name = "Ж14" },
                    new Group { Name = "Ж16" },
                    new Group { Name = "Ж18" },
                    new Group { Name = "Ж20" },
                    new Group { Name = "Ж21Е" },
                    new Group { Name = "Ж21А" },
                    new Group { Name = "Ж35" },
                    new Group { Name = "Ж40" },
                    new Group { Name = "Ж45" },
                    new Group { Name = "Ж50" },
                    new Group { Name = "Ж55" },
                    new Group { Name = "Ж60" },
                    new Group { Name = "Ж65" },
                    new Group { Name = "Ж70" },
                    new Group { Name = "Ж75" },
                    new Group { Name = "М12" },
                    new Group { Name = "М14" },
                    new Group { Name = "М16" },
                    new Group { Name = "М18" },
                    new Group { Name = "М20" },
                    new Group { Name = "М21Е" },
                    new Group { Name = "М21А" },
                    new Group { Name = "М35" },
                    new Group { Name = "М40" },
                    new Group { Name = "М45" },
                    new Group { Name = "М50" },
                    new Group { Name = "М55" },
                    new Group { Name = "М60" },
                    new Group { Name = "М65" },
                    new Group { Name = "М70" },
                    new Group { Name = "М75" }
                    );
                context.SaveChanges();
            }
            Dictionary<string, Group> groups = context.Groups.ToDictionary(g => g.Name);
            if (!context.Events.Any())
            {
                context.Events.AddRange(
                    new Event
                    {
                        Title = "Старт, посвященный памяти Рикуна В. Б.",
                        Date = new DateTime(2020, 12, 6),
                        InfoLink = "http://orientsumy.com.ua/index.php?event=3044&inf=1",
                        ResultsLink = "http://orientsumy.com.ua/index.php?event=3044&inf=2",
                        Location = "с. Китайгород",
                        RegionId = 23,
                        OrganizerLogin = "admin",
                        IsApplicationOpen = false,
                    },
                    new Event
                    {
                        Title = "Открытый турнир, посвященный Дню Энергетика",
                        Date = new DateTime(2020, 12, 12),
                        Location = "с. Катеринка",
                        RegionId = 23,
                        OrganizerLogin = "moderator1",
                    },
                    new Event
                    {
                        Title = "Тренировочный старт \"Днепровские пороги\"",
                        Date = new DateTime(2020, 12, 13),
                        InfoLink = "http://orientsumy.com.ua/index.php?event=3086&inf=1",
                        ResultsLink = "http://orientsumy.com.ua/index.php?event=3086&inf=2",
                        Location = "с. Майорка (дачи)",
                        RegionId = 12,
                        OrganizerLogin = "moderator2",
                    },
                    new Event
                    {
                        Title = "Відкриті змагання Донецької області зі спортивного орієнтування (бігом), присвячені Дню Святого Миколая.",
                        Date = new DateTime(2020, 12, 19),
                        Location = "Відокремлений підрозділ громадської організації ”Федерація спортивного орієнтування України” у Донецькій області.",
                        RegionId = 22,
                        OrganizerLogin = "moderator3",
                    },
                    new Event
                    {
                        Title = "Традиційні змагання зі спортивного орієнтування \"Сніжинка 2021\"",
                        Date = new DateTime(2020, 12, 19),
                        Location = "КСОТ \"Центуріон\"",
                        RegionId = 10,
                        OrganizerLogin = "moderator4",
                    },
                    new Event
                    {
                        Title = "Закрытие сезона",
                        Date = new DateTime(2020, 12, 20),
                        InfoLink = "http://orientsumy.com.ua/index.php?event=3044&inf=1",
                        ResultsLink = "http://orientsumy.com.ua/index.php?event=3044&inf=2",
                        Location = "с/к \"Наш клуб\"",
                        RegionId = 23,
                        OrganizerLogin = "organizer1",
                    },
                    new Event
                    {
                        Title = "Ёлки-палки",
                        Date = new DateTime(2020, 12, 25),
                        InfoLink = "http://orientsumy.com.ua/index.php?event=3086&inf=1",
                        ResultsLink = "http://orientsumy.com.ua/index.php?event=3086&inf=2",
                        Location = "с/к \"Сириус\"",
                        RegionId = 23,
                        OrganizerLogin = "organizer2",
                    },
                    new Event
                    {
                        Title = "Різдвяний старт",
                        Date = new DateTime(2020, 12, 26),
                        Location = "Відокремлений підрозділ громадської організації \"Федерація спортивного орієнтування України\" у Донецькій області.",
                        RegionId = 22,
                        OrganizerLogin = "organizer1",
                    },
                    new Event
                    {
                        Title = "НОВОРІЧНА КОРИДА 2020",
                        Date = new DateTime(2020, 12, 27),
                        InfoLink = "http://orientsumy.com.ua/index.php?event=3086&inf=1",
                        ResultsLink = "http://orientsumy.com.ua/index.php?event=3086&inf=2",
                        Location = "Лижна база \"Авангард\", ур.Токарі",
                        RegionId = 7,
                        OrganizerLogin = "admin",
                    },
                    new Event
                    {
                        Title = "Супер кубок приз мильярд денег",
                        Date = new DateTime(2020, 12, 31),
                        Location = "дом Колотушкина",
                        RegionId = 24,
                        OrganizerLogin = "moderator1",
                    },
                    new Event
                    {
                        Title = "Марафон веб-дизайнеров",
                        Date = new DateTime(2020, 12, 30),
                        Location = "с. Бутстрап",
                        RegionId = 3,
                        OrganizerLogin = "moderator2",
                    },
                    new Event
                    {
                        Title = "Биба Бобовна",
                        Date = new DateTime(2021, 1, 7),
                        InfoLink = "http://orientsumy.com.ua/index.php?event=3044&inf=1",
                        ResultsLink = "http://orientsumy.com.ua/index.php?event=3044&inf=2",
                        Location = "с. Моя хата",
                        RegionId = 17,
                        OrganizerLogin = "moderator3",
                    },
                    new Event
                    {
                        Title = "Кубок нероб",
                        Date = new DateTime(2021, 1, 14),
                        InfoLink = "http://orientsumy.com.ua/index.php?event=3086&inf=1",
                        ResultsLink = "http://orientsumy.com.ua/index.php?event=3086&inf=2",
                        Location = "с. Чилловое",
                        RegionId = 14,
                        OrganizerLogin = "moderator1",
                    }
                    );
                context.SaveChanges();
                var paterns = new[] { 
                        new HashSet<Group>
                        {
                            groups["Ж12"],
                            groups["Ж14"],
                            groups["Ж16"],
                            groups["Ж18"],
                            groups["Ж20"],
                            groups["Ж21А"],
                            groups["Ж21Е"],
                            groups["Ж35"],
                            groups["Ж40"],
                            groups["Ж45"],
                            groups["Ж50"],
                            groups["Ж55"],
                            groups["Ж60"],
                            groups["Ж65"],
                            groups["Ж70"],
                            groups["Ж75"],
                            groups["М12"],
                            groups["М14"],
                            groups["М16"],
                            groups["М18"],
                            groups["М20"],
                            groups["М21А"],
                            groups["М21Е"],
                            groups["М35"],
                            groups["М40"],
                            groups["М45"],
                            groups["М50"],
                            groups["М55"],
                            groups["М60"],
                            groups["М65"],
                            groups["М70"],
                            groups["М75"],
                        },
                        new HashSet<Group>
                        {
                            groups["Ж12"],
                            groups["Ж14"],
                            groups["Ж16"],
                            groups["Ж21А"],
                            groups["Ж21Е"],
                            groups["Ж35"],
                            groups["Ж45"],
                            groups["Ж55"],
                            groups["М12"],
                            groups["М14"],
                            groups["М16"],
                            groups["М16"],
                            groups["М21А"],
                            groups["М21Е"],
                            groups["М35"],
                            groups["М45"],
                            groups["М55"],
                        },
                        new HashSet<Group>
                        {
                            groups["Ж21Е"],
                            groups["Ж35"],
                            groups["Ж40"],
                            groups["Ж45"],
                            groups["Ж50"],
                            groups["Ж55"],
                            groups["Ж60"],
                            groups["Ж65"],
                            groups["М21Е"],
                            groups["М35"],
                            groups["М40"],
                            groups["М45"],
                            groups["М50"],
                            groups["М55"],
                            groups["М60"],
                            groups["М65"],
                        },
                        new HashSet<Group>
                        {
                            groups["Ж12"],
                            groups["Ж16"],
                            groups["Ж21А"],
                            groups["Ж21Е"],
                            groups["Ж35"],
                            groups["Ж45"],
                            groups["Ж55"],
                            groups["М12"],
                            groups["М16"],
                            groups["М21А"],
                            groups["М21Е"],
                            groups["М35"],
                            groups["М45"],
                            groups["М55"],
                        }
                };
                int i = 0;
                foreach (var item in context.Events)
                {
                    foreach (var gr in paterns[i % 4])
                    {
                        item.Groups.Add(gr);
                    }
                }
                context.SaveChanges();
            }
            if (!context.Applications.Any())
            {
                var random = new Random();
                var eventGroups = context.EventGroups.Where(eg => eg.Event == context.Events.First()).ToList();
                foreach (var item in context.Users)
                {
                    int? chip = random.Next(2) switch
                    {
                        0 => null,
                        1 => random.Next(1000000,100000000),
                        _ => null,
                    };
                    context.Applications.Add(new Application
                    {
                        Chip = chip,
                        EventGroup = eventGroups.ElementAt(random.Next(eventGroups.Count)),
                        User = item,
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
