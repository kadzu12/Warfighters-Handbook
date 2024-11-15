using Warfighters.Models;

namespace Warfighters.ViewModels
{
    public class StatViewModel
    {
        public Stat Stat { get; }

        public string Name => Stat.NameStat;
        public decimal StartNumber => Stat.StartNumber;

        public decimal MaxNumber => Stat.MaxNumber;

        public string TypeStat => Stat.TypeStat;

        public StatViewModel(Stat stat)
        {
            Stat = stat;
        }
    }
}
