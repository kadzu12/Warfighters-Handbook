using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Warfighters.Models;
using Warfighters.Models.Data;
using Warfighters.Pages;
using Warfighters.Services.For_calculator;

namespace Warfighters.Services
{
    public class CalculatorServices
    {
        //Метод для проверки ввода
        public static TextBox tbEM = Calculator.calculator.tbEM;
        public static void KeyControl(KeyEventArgs e, TextBox textbox, double max)
        {
            if (e.Key == Key.Back || e.Key == Key.LeftShift || e.Key == Key.RightShift || e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
            {
                return;
            }

            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                int keyValue = (int)KeyInterop.VirtualKeyFromKey(e.Key);
                if ((textbox.Text.IndexOf(',') != -1) && (textbox.Text[textbox.Text.Length - 1] != ','))
                    e.Handled = true;
                if ((textbox.Text == "") && (keyValue == 48))
                    e.Handled = true;
                if (textbox.Text.IndexOf(',') == -1)
                {
                    if (Convert.ToDouble(textbox.Text + (char)keyValue) > max)
                        if (textbox == tbEM)
                            e.Handled = true;
                        else
                        {
                            textbox.Text += ',';
                            textbox.Text += (char)keyValue;
                            e.Handled = true;
                        }
                }
                return;
            }

            if (textbox == tbEM)
                e.Handled = true;

            if (e.Key == Key.OemPeriod || e.Key == Key.OemComma || e.Key == Key.OemQuestion || e.Key == Key.Oem2)
            {
                textbox.Text += ',';
                e.Handled = true;
            }

            if (e.Key == Key.OemComma)
            {
                if (textbox.Text == String.Empty)
                    e.Handled = true;
            }

            if (e.Key == Key.OemComma)
            {
                if (textbox.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                }
                return;
            }

            e.Handled = true;
        }

        // Получение названий статов
        public static string[] GetStatNames()
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var stats = context.Stats.Where(s => s.TypeStat == "Доп").ToList();
                return stats.Select(s => s.NameStat).ToArray();
            }
        }

        // Получение идентификатора сета по названию
        public static int GetIDSetByName(string name)
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var set = context.SetArtifacts.FirstOrDefault(s => s.NameSet == name);
                return set != null ? set.IdSet : -1;
            }
        }

        // Получение идентификатора категории артефакта по названию
        public static int GetIDPArtifactByName(string name)
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var artifact = context.Artifacts.FirstOrDefault(a => a.Category == name);
                return artifact != null ? artifact.IdArtifact : -1;
            }
        }

        // Получение идентификатора основной характеристики по названию
        public static int GetIDMainStatByName(string name)
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var stat = context.Stats.FirstOrDefault(s => s.NameStat == name && s.TypeStat == "Осн");
                return stat != null ? stat.IdStat : -1;
            }
        }

        // Получение идентификатора доп характеристики по названию
        public static int GetIDStatByName(string name)
        {
            using (HoyoverseContext context = new HoyoverseContext())
            {
                var stat = context.Stats.FirstOrDefault(s => s.NameStat == name && s.TypeStat == "Доп");
                return stat != null ? stat.IdStat : -1;
            }
        }

        // Основная логика калькулятора
        public static List<Character> Calculate(string setArtifact, string piece, string mainStat, TextBox[] textBoxes, string hp, string atk, string def, string em, string er, string critRate, string critDmg)
        {
            double[] stats = new double[7];
            string[] statNames = GetStatNames();
            double[] maximumRolls = { MaximumRoll.HP_PERCENT, MaximumRoll.ATK_PERCENT, MaximumRoll.DEF_PERCENT, MaximumRoll.ELEMENTAL_MASTERY, MaximumRoll.ENERGY_RECHARGE, MaximumRoll.CRIT_RATE, MaximumRoll.CRIT_DMG };

            // Заполнение массива stats
            for (int i = 0; i < stats.Length; i++)
            {
                if (textBoxes[i].Text == string.Empty)
                {
                    stats[i] = 0;
                }
                else
                {
                    try
                    {
                        stats[i] = Convert.ToDouble(textBoxes[i].Text);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Введите числовое значение.");
                        return new List<Character>();
                    }
                }
            }

            // Максимальное количество характеристик
            int maxRollsCount = 9;
            // Максимальное количество различных характеристик
            int maxDifferentStats = 4;
            // Максимальное количество уровней при прокачке
            int maxLvlRolls = 5;

            for (int i = 0; i < statNames.Length; i++)
            {
                if (mainStat == statNames[i] && stats[i] > 0)
                {
                    MessageBox.Show("Верхняя и нижняя характеристика не могут повторяться.");
                    return new List<Character>();
                }

                if (stats[i] > 0)
                {
                    maxDifferentStats--;
                    maxRollsCount -= (int)Math.Ceiling(stats[i] / maximumRolls[i]);
                    maxLvlRolls -= (int)Math.Ceiling(stats[i] / maximumRolls[i]) - 1;
                }

                if (maxRollsCount < 0 || maxDifferentStats < 0 || maxLvlRolls < 0)
                {
                    MessageBox.Show("Было введено много характеристик.");
                    return new List<Character>();
                }
            }

            // Список всех персонажей
            List<Character> allCharacters = CharacterServices.GetCharacters();

            // Список персонажей, которым подходит введенный артефакт
            List<Character> suitableCharacters = new List<Character>();

            // Получение идентификаторов сета артефактов, артефакта и основной харак-ки
            int idSet = GetIDSetByName(setArtifact);
            int idPiece = GetIDPArtifactByName(piece);
            int idMainStat = GetIDMainStatByName(mainStat);

            // Список идентификаторов доп характеристик, соответствующих заполненным переменным
            List<int> statIds = new List<int>();
            if (!string.IsNullOrEmpty(hp)) statIds.Add(GetIDStatByName("Процент от HP"));
            if (!string.IsNullOrEmpty(atk)) statIds.Add(GetIDStatByName("Процент от силы атаки"));
            if (!string.IsNullOrEmpty(def)) statIds.Add(GetIDStatByName("Процент от защиты"));
            if (!string.IsNullOrEmpty(em)) statIds.Add(GetIDStatByName("Мастерство стихий"));
            if (!string.IsNullOrEmpty(er)) statIds.Add(GetIDStatByName("Восстановление энергии"));
            if (!string.IsNullOrEmpty(critRate)) statIds.Add(GetIDStatByName("Шанс критического попадания"));
            if (!string.IsNullOrEmpty(critDmg)) statIds.Add(GetIDStatByName("Критический урон"));

            foreach (var character in allCharacters)
            {
                // Проверка, чтобы выбранный сет был указан у персонажа
                bool hasSet = character.IdSignaturSetNavigation.NameSet == setArtifact || character.IdSets.Any(s => s.NameSet == setArtifact);
                // Проверка, чтобы выбранная основная характ-ка была указана у выбранного артефакта
                bool hasPieceAndMainStat = false;
                foreach (var recommendedStat in character.RecommendedStats)
                {
                    if ((idPiece == 1 || idPiece == 2) || (idPiece == 3 && recommendedStat.IdStat == idMainStat) || (idPiece == 4 && recommendedStat.IdStat == idMainStat) || (idPiece == 5 && recommendedStat.IdStat == idMainStat))
                    {
                        hasPieceAndMainStat = true;
                        break;
                    }
                }
                // Проверка, чтобы хотя бы 2 введенные харак-ти были указаны у персонажа
                int filledStatsCount = 0;
                foreach (var recommendedStat in character.RecommendedStats)
                {
                    if (recommendedStat.IdArtifact == 0 && statIds.Contains(recommendedStat.IdStat))
                    {
                        filledStatsCount++;
                    }
                }
                bool hasEnteredStats = filledStatsCount >= 2;

                // Если все проверки пройдены, персонаж добавляется в список suitableCharacters
                if (hasSet && hasPieceAndMainStat && hasEnteredStats)
                {
                    suitableCharacters.Add(character);
                }
            }

            return suitableCharacters;
        }

        public static List<Character> CalculateForTest(string setArtifact, string piece, string mainStat, string hp, string atk, string def, string em, string er, string critRate, string critDmg)
        {
            double[] stats = new double[7];
            string[] statNames = GetStatNames();
            double[] maximumRolls = { MaximumRoll.HP_PERCENT, MaximumRoll.ATK_PERCENT, MaximumRoll.DEF_PERCENT, MaximumRoll.ELEMENTAL_MASTERY, MaximumRoll.ENERGY_RECHARGE, MaximumRoll.CRIT_RATE, MaximumRoll.CRIT_DMG };

            // Заполнение массива stats
            string[] statValues = { hp, atk, def, em, er, critRate, critDmg };
            for (int i = 0; i < stats.Length; i++)
            {
                if (string.IsNullOrEmpty(statValues[i]))
                {
                    stats[i] = 0;
                }
                else
                {
                    try
                    {
                        stats[i] = Convert.ToDouble(statValues[i]);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Введите числовое значение.");
                        return new List<Character>();
                    }
                }
            }

            // Максимальное количество характеристик
            int maxRollsCount = 9;
            // Максимальное количество различных характеристик
            int maxDifferentStats = 4;
            // Максимальное количество уровней при прокачке
            int maxLvlRolls = 5;

            for (int i = 0; i < statNames.Length; i++)
            {
                if (mainStat == statNames[i] && stats[i] > 0)
                {
                    MessageBox.Show("Верхняя и нижняя характеристика не могут повторяться.");
                    return new List<Character>();
                }

                if (stats[i] > 0)
                {
                    maxDifferentStats--;
                    maxRollsCount -= (int)Math.Ceiling(stats[i] / maximumRolls[i]);
                    maxLvlRolls -= (int)Math.Ceiling(stats[i] / maximumRolls[i]) - 1;
                }

                if (maxRollsCount < 0 || maxDifferentStats < 0 || maxLvlRolls < 0)
                {
                    MessageBox.Show("Было введено много характеристик.");
                    return new List<Character>();
                }
            }

            // Список всех персонажей
            List<Character> allCharacters = CharacterServices.GetCharacters();

            // Список персонажей, которым подходит введенный артефакт
            List<Character> suitableCharacters = new List<Character>();

            // Получение идентификаторов сета артефактов, артефакта и основной харак-ки
            int idSet = GetIDSetByName(setArtifact);
            int idPiece = GetIDPArtifactByName(piece);
            int idMainStat = GetIDMainStatByName(mainStat);

            // Список идентификаторов доп характеристик, соответствующих заполненным переменным
            List<int> statIds = new List<int>();
            if (!string.IsNullOrEmpty(hp)) statIds.Add(GetIDStatByName("Процент от HP"));
            if (!string.IsNullOrEmpty(atk)) statIds.Add(GetIDStatByName("Процент от силы атаки"));
            if (!string.IsNullOrEmpty(def)) statIds.Add(GetIDStatByName("Процент от защиты"));
            if (!string.IsNullOrEmpty(em)) statIds.Add(GetIDStatByName("Мастерство стихий"));
            if (!string.IsNullOrEmpty(er)) statIds.Add(GetIDStatByName("Восстановление энергии"));
            if (!string.IsNullOrEmpty(critRate)) statIds.Add(GetIDStatByName("Шанс критического попадания"));
            if (!string.IsNullOrEmpty(critDmg)) statIds.Add(GetIDStatByName("Критический урон"));

            foreach (var character in allCharacters)
            {
                // Проверка, чтобы выбранный сет был указан у персонажа
                bool hasSet = character.IdSignaturSetNavigation.NameSet == setArtifact || character.IdSets.Any(s => s.NameSet == setArtifact);
                // Проверка, чтобы выбранная основная характ-ка была указана у выбранного артефакта
                bool hasPieceAndMainStat = false;
                foreach (var recommendedStat in character.RecommendedStats)
                {
                    if ((idPiece == 1 || idPiece == 2) || (idPiece == 3 && recommendedStat.IdStat == idMainStat) || (idPiece == 4 && recommendedStat.IdStat == idMainStat) || (idPiece == 5 && recommendedStat.IdStat == idMainStat))
                    {
                        hasPieceAndMainStat = true;
                        break;
                    }
                }
                // Проверка, чтобы хотя бы 2 введенные харак-ти были указаны у персонажа
                int filledStatsCount = 0;
                foreach (var recommendedStat in character.RecommendedStats)
                {
                    if (recommendedStat.IdArtifact == 0 && statIds.Contains(recommendedStat.IdStat))
                    {
                        filledStatsCount++;
                    }
                }
                bool hasEnteredStats = filledStatsCount >= 2;

                // Если все проверки пройдены, персонаж добавляется в список suitableCharacters
                if (hasSet && hasPieceAndMainStat && hasEnteredStats)
                {
                    suitableCharacters.Add(character);
                }
            }

            return suitableCharacters;
        }
    }
}
