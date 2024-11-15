using Microsoft.EntityFrameworkCore;
using Warfighters.Models;
using Warfighters.Models.Data;

namespace Warfighters.Services
{
    public class CharacterServices
    {
        //Получение оружий
        public static List<Weapon> GetWeapon()
        {
            using (HoyoverseContext db = new())
            {
                var result = db.Weapons.ToList();
                return result;
            }
        }
        //Получение талантов и навыков персонажа
        public static List<Talent> GetTalent()
        {
            using (HoyoverseContext db = new())
            {
                var result = db.Talents.ToList();
                return result;
            }
        }
        //Получение персонажей
        public static List<Character> GetCharacters()
        {
            using (HoyoverseContext db = new())
            {
                var characterQuery = db.Characters
                    .Include(c => c.IdSignatureWeponsNavigation)
                    .Include(c => c.IdSignaturSetNavigation)
                    .Include(c => c.Constellations)
                    .Include(c => c.RecommendedStats)
                    .Include(c => c.Talents)
                    .Include(c => c.IdSets)
                    .Include(c => c.IdWeapons);

                var characterList = characterQuery.Select(c => new Character
                {
                    IdCharacter = c.IdCharacter,
                    ImageCharacter = c.ImageCharacter,
                    NameCharacter = c.NameCharacter,
                    EyeGod = c.EyeGod,
                    Region = c.Region,
                    TypeWeapon = c.TypeWeapon,
                    Rariry = c.Rariry,
                    IdSignatureWepons = c.IdSignatureWepons,
                    IdSignatureSetArtifact = c.IdSignatureSetArtifact,
                    CountViews = c.CountViews,
                    MainDps = c.MainDps,
                    SubDps = c.SubDps,
                    Support = c.Support,
                    Constellations = c.Constellations,
                    IdSignatureWeponsNavigation = c.IdSignatureWeponsNavigation,
                    IdSignaturSetNavigation = c.IdSignaturSetNavigation,
                    RecommendedStats = c.RecommendedStats.Select(rs => new RecommendedStat
                    {
                        IdCharacter = rs.IdCharacter,
                        IdArtifact = rs.IdArtifact,
                        IdStat = rs.IdStat,
                        IdArtifactNavigation = rs.IdArtifactNavigation,
                        IdStatNavigation = rs.IdStatNavigation
                    }).ToList(),
                    Talents = c.Talents,
                    IdSets = c.IdSets,
                    IdWeapons = c.IdWeapons
                }).ToList();

                return characterList;
            }
        }
        //Получение пяти просматриваемых персонажей
        public static List<Character> GetTolViewedCharacters()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var topCharacters = context.Characters.OrderByDescending(c => c.CountViews).Take(5).ToList();

                return topCharacters;
            }
        }
        //Тир-лист
        ////S+
        public static List<Character> GetDpsSS()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var characters = context.Characters.Where(c => c.MainDps == "S+").ToList();
                return characters;
            }
        }
        public static List<Character> GetSubSS()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var characters = context.Characters.Where(c => c.SubDps == "S+").ToList();
                return characters;
            }
        }
        public static List<Character> GetSupportSS()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var characters = context.Characters.Where(c => c.Support == "S+").ToList();
                return characters;
            }
        }
        ////S
        public static List<Character> GetDpsS()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var characters = context.Characters.Where(c => c.MainDps == "S").ToList();
                return characters;
            }
        }
        public static List<Character> GetSubS()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var characters = context.Characters.Where(c => c.SubDps == "S").ToList();
                return characters;
            }
        }
        public static List<Character> GetSupportS()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var characters = context.Characters.Where(c => c.Support == "S").ToList();
                return characters;
            }
        }
        ////A
        public static List<Character> GetDpsA()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var characters = context.Characters.Where(c => c.MainDps == "A").ToList();
                return characters;
            }
        }
        public static List<Character> GetSubA()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var characters = context.Characters.Where(c => c.SubDps == "A").ToList();
                return characters;
            }
        }
        public static List<Character> GetSupportA()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var characters = context.Characters.Where(c => c.Support == "A").ToList();
                return characters;
            }
        }
        ////B
        public static List<Character> GetDpsB()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var characters = context.Characters.Where(c => c.MainDps == "B").ToList();
                return characters;
            }
        }
        public static List<Character> GetSubB()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var characters = context.Characters.Where(c => c.SubDps == "B").ToList();
                return characters;
            }
        }
        public static List<Character> GetSupportB()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var characters = context.Characters.Where(c => c.Support == "B").ToList();
                return characters;
            }
        }
        ////C
        public static List<Character> GetDpsC()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var characters = context.Characters.Where(c => c.MainDps == "C").ToList();
                return characters;
            }
        }
        public static List<Character> GetSubC()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var characters = context.Characters.Where(c => c.SubDps == "C").ToList();
                return characters;
            }
        }
        public static List<Character> GetSupportC()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var characters = context.Characters.Where(c => c.Support == "C").ToList();
                return characters;
            }
        }
        ////D
        public static List<Character> GetDpsD()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var characters = context.Characters.Where(c => c.MainDps == "D").ToList();
                return characters;
            }
        }
        public static List<Character> GetSubD()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var characters = context.Characters.Where(c => c.SubDps == "D").ToList();
                return characters;
            }
        }
        public static List<Character> GetSupportD()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var characters = context.Characters.Where(c => c.Support == "D").ToList();
                return characters;
            }
        }
    }
}
