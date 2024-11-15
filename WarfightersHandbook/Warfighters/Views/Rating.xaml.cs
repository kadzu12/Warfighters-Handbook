using System.Windows.Controls;
using Warfighters.Models;
using Warfighters.Services;
using Warfighters.ViewModels;
using Warfighters.Views;

namespace Warfighters.Pages
{
    /// <summary>
    /// Логика взаимодействия для Rating.xaml
    /// </summary>
    public partial class Rating : Page
    {
        public Rating()
        {
            InitializeComponent();
            DataContext = new BrowseTierList();

            //S+
            List<Character> mainDpsSS = CharacterServices.GetDpsSS();
            foreach (var character in mainDpsSS)
                lvDpsSS.Items.Add(new UserControlCharacterTearList(character));
            List<Character> subDpsSS = CharacterServices.GetSubSS();
            foreach (var character in subDpsSS)
                lvSubSS.Items.Add(new UserControlCharacterTearList(character));
            List<Character> supportSS = CharacterServices.GetSupportSS();
            foreach (var character in supportSS)
                lvSupportSS.Items.Add(new UserControlCharacterTearList(character));
            //S
            List<Character> mainDpsS = CharacterServices.GetDpsS();
            foreach (var character in mainDpsS)
                lvDpsS.Items.Add(new UserControlCharacterTearList(character));
            List<Character> subDpsS = CharacterServices.GetSubS();
            foreach (var character in subDpsS)
                lvSubS.Items.Add(new UserControlCharacterTearList(character));
            List<Character> supportS = CharacterServices.GetSupportS();
            foreach (var character in supportS)
                lvSupportS.Items.Add(new UserControlCharacterTearList(character));
            //A
            List<Character> mainDpsA = CharacterServices.GetDpsA();
            foreach (var character in mainDpsA)
                lvDpsA.Items.Add(new UserControlCharacterTearList(character));
            List<Character> subDpsA = CharacterServices.GetSubA();
            foreach (var character in subDpsA)
                lvSubA.Items.Add(new UserControlCharacterTearList(character));
            List<Character> supportA = CharacterServices.GetSupportA();
            foreach (var character in supportA)
                lvSupportA.Items.Add(new UserControlCharacterTearList(character));
            //B
            List<Character> mainDpsB = CharacterServices.GetDpsB();
            foreach (var character in mainDpsB)
                lvDpsB.Items.Add(new UserControlCharacterTearList(character));
            List<Character> subDpsB = CharacterServices.GetSubB();
            foreach (var character in subDpsB)
                lvSubB.Items.Add(new UserControlCharacterTearList(character));
            List<Character> supportB = CharacterServices.GetSupportB();
            foreach (var character in supportB)
                lvSupportB.Items.Add(new UserControlCharacterTearList(character));
            //C
            List<Character> mainDpsC = CharacterServices.GetDpsC();
            foreach (var character in mainDpsC)
                lvDpsC.Items.Add(new UserControlCharacterTearList(character));
            List<Character> subDpsC = CharacterServices.GetSubC();
            foreach (var character in subDpsC)
                lvSubC.Items.Add(new UserControlCharacterTearList(character));
            List<Character> supportC = CharacterServices.GetSupportC();
            foreach (var character in supportC)
                lvSupportC.Items.Add(new UserControlCharacterTearList(character));
            //D
            List<Character> mainDpsD = CharacterServices.GetDpsD();
            foreach (var character in mainDpsD)
                lvDpsD.Items.Add(new UserControlCharacterTearList(character));
            List<Character> subDpsD = CharacterServices.GetSubD();
            foreach (var character in subDpsD)
                lvSubD.Items.Add(new UserControlCharacterTearList(character));
            List<Character> supportD = CharacterServices.GetSupportD();
            foreach (var character in supportD)
                lvSupportD.Items.Add(new UserControlCharacterTearList(character));
        }
    }
}
