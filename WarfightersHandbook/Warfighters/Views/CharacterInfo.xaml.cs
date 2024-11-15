using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Warfighters.Models;
using Warfighters.Models.Data;
using Warfighters.ViewModels;

namespace Warfighters.Views
{
    /// <summary>
    /// Логика взаимодействия для CharacterInfo.xaml
    /// </summary>
    public partial class CharacterInfo : Page
    {
        public Character Character { get; set; }
        public ObservableCollection<Talent> Talents { get; set; }
        public ObservableCollection<WeaponViewModel> Weapons { get; set; }
        public ObservableCollection<SetViewModel> SetsArtifact { get; set; }
        public ObservableCollection<Constellation> Constellations { get; set; }
        public List<StatWithArtifact> Stats { get; set; }
        public List<ArtifactViewModel> Artifacts { get; set; }
        public string FirstTalent {  get; set; }
        public string SecondTalent { get; set; }
        public string ThirdTalent { get; set; }
        public List<StatWithArtifact> ClockStats { get; set; }
        public List<StatWithArtifact> CupStats { get; set; }
        public List<StatWithArtifact> CrownStats { get; set; }
        public List<StatWithArtifact> AdditionalStats { get; set; }

        public CharacterInfo(Character character)
        {
            InitializeComponent();

            using (HoyoverseContext db = new HoyoverseContext())
            {
                Character = db.Characters
                    .Include(c => c.Talents)
                    .Include(c => c.Constellations)
                    .Include(c => c.RecommendedStats)
                    .ThenInclude(rs => rs.IdStatNavigation)
                    .Include(c => c.RecommendedStats)
                    .ThenInclude(rs => rs.IdArtifactNavigation)
                    .Include(c => c.IdSignatureWeponsNavigation)
                    .Include(c => c.IdWeapons)
                    .Include(c => c.IdSignaturSetNavigation)
                    .Include(c => c.IdSets)
                    .FirstOrDefault(c => c.IdCharacter == character.IdCharacter);

                Talents = new ObservableCollection<Talent>(Character.Talents);
                FirstTalent = Talents.FirstOrDefault(t => t.PriorityImprovement == 1)?.CategoryTalent;
                SecondTalent = Talents.FirstOrDefault(t => t.PriorityImprovement == 2)?.CategoryTalent;
                ThirdTalent = Talents.FirstOrDefault(t => t.PriorityImprovement == 3)?.CategoryTalent;

                var signatureWeapon = Character.IdSignatureWeponsNavigation;
                Weapons = new ObservableCollection<WeaponViewModel>(Character.IdWeapons.Select(w => new WeaponViewModel(w)));

                Weapons.Insert(0, new WeaponViewModel(signatureWeapon));

                var signatureSet = Character.IdSignaturSetNavigation;
                SetsArtifact = new ObservableCollection<SetViewModel>(Character.IdSets.Select(s => new SetViewModel(s)));
                SetsArtifact.Insert(0, new SetViewModel(signatureSet));

                var artifacts = Character.RecommendedStats
                .Select(rs => rs.IdArtifactNavigation)
                .Distinct()
                .Select(a => new ArtifactViewModel(a))
                .ToList();
                var stats = Character.RecommendedStats
                    .Select(rs => new StatWithArtifact
                    {
                        Stat = new StatViewModel(rs.IdStatNavigation),
                        Artifact = artifacts.FirstOrDefault(a => a.IdArtifact == rs.IdArtifact)
                    })
                    .ToList();

                ClockStats = stats.Where(s => s.Artifact?.IdArtifact == 3).ToList();
                CupStats = stats.Where(s => s.Artifact?.IdArtifact == 4).ToList();
                CrownStats = stats.Where(s => s.Artifact?.IdArtifact == 5).ToList();
                AdditionalStats = stats.Where(s => s.Artifact?.IdArtifact == 0).ToList();

                Artifacts = artifacts;

                Constellations = new ObservableCollection<Constellation>(Character.Constellations);
                DataContext = this;

                //Character.CountViews++;
                //db.SaveChanges();
            }
        }
        public class StatWithArtifact
        {
            public StatViewModel Stat { get; set; }
            public ArtifactViewModel Artifact { get; set; }
        }
    }
}
