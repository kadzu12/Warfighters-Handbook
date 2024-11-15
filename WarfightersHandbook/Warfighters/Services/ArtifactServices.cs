using Warfighters.Models;
using Warfighters.Models.Data;

namespace Warfighters.Services
{
    public class ArtifactServices
    {
        //Получение названий сетов артефактов
        public static List<SetArtifact> GetSetArtifact()
        {
            using (HoyoverseContext db = new HoyoverseContext())
            {
                var result = db.SetArtifacts.ToList();
                return result;
            }
        }
        //Получение названий артефактов
        public static List<string> GetArtifactsName()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                return context.Artifacts.Where(a => a.IdArtifact != 0).Select(ar => ar.Category).ToList();
            }
        }
        //Получение основных харак-к
        public static List<string> GetMainStatsName()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                return context.Stats.Where(s => s.TypeStat == "Осн").Select(st => st.NameStat).ToList();
            }
        }
        //Получение названий сетов артефактов в массив строк
        public static List<string> GetSetsName()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                return context.SetArtifacts.Select(s => s.NameSet).ToList();
            }
        }
        //Получение идентификатора артефакта
        public static int GetArtifactIDByName(string name)
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var artifact = context.Artifacts.FirstOrDefault(a => a.Category == name);

                return artifact != null ? artifact.IdArtifact : -1;
            }
        }
        //Получение основных харак-к в зависимости от артефакта
        public static List<string> GetMainStatsByArtifactId(int artifactId)
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var mainStats = context.Stats
                    .Where(s => s.IdArtifacts.Any(a => a.IdArtifact == artifactId) && s.TypeStat == "Осн")
                    .Select(s => s.NameStat)
                    .ToList();

                return mainStats;
            }
        }
    }
}
