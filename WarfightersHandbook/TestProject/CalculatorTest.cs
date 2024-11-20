using System.Windows.Controls;
using Warfighters.Models;
using Warfighters.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;

namespace TestProject
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void GetStatNames_ShouldReturnArrayOfStatNames()
        {
            string[] result = CalculatorServices.GetStatNames();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }
        [TestMethod]
        public void GetIDSetByName_ShouldReturnSetID()
        {
            string testName = "Эмблема рассечённой судьбы";
            int result = CalculatorServices.GetIDSetByName(testName);
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void GetIDSetByName_ShouldReturnMinusOneForNonExistentSet()
        {
            string nonExistentName = "Эмблема";
            int result = CalculatorServices.GetIDSetByName(nonExistentName);
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void GetIDPArtifactByName_ShouldReturnArtifactID()
        {
            string testName = "Корона разума";
            int result = CalculatorServices.GetIDPArtifactByName(testName);
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void GetIDPArtifactByName_ShouldReturnMinusOneForNonExistentArtifact()
        {
            string nonExistentName = "Корона";
            int result = CalculatorServices.GetIDPArtifactByName(nonExistentName);
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void GetIDMainStatByName_ShouldReturnMainStatID()
        {
            string testName = "HP";
            int result = CalculatorServices.GetIDMainStatByName(testName);
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void GetIDMainStatByName_ShouldReturnMinusOneForNonExistentMainStat()
        {
            string nonExistentName = "Здоровье";
            int result = CalculatorServices.GetIDMainStatByName(nonExistentName);
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void GetIDStatByName_ShouldReturnStatID()
        {
            string testName = "Критический урон";
            int result = CalculatorServices.GetIDStatByName(testName);
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void GetIDStatByName_ShouldReturnMinusOneForNonExistentStat()
        {
            string nonExistentName = "КУ";
            int result = CalculatorServices.GetIDStatByName(nonExistentName);
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void Calculate_ShouldReturnListOfSuitableCharacters()
        {
            string setArtifact = "Церемония древней знати";
            string piece = "Цветок жизни";
            string mainStat = "HP";
            string hp = string.Empty;
            string atk = string.Empty;
            string def = string.Empty;
            string em = "63";
            string er = "12";
            string critRate = string.Empty;
            string critDmg = string.Empty;

            List<Character> result = CalculatorServices.CalculateForTest(setArtifact, piece, mainStat, hp, atk, def, em, er, critRate, critDmg);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void CalculateForTest_ShouldReturnEmptyListForInvalidInput()
        {
            string setArtifact = "invalid";
            string piece = "Цветок жизни";
            string mainStat = "HP";
            string hp = "invalid";
            string atk = string.Empty;
            string def = string.Empty;
            string em = "63";
            string er = "12";
            string critRate = string.Empty;
            string critDmg = string.Empty;

            List<Character> result = CalculatorServices.CalculateForTest(setArtifact, piece, mainStat, hp, atk, def, em, er, critRate, critDmg);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void CalculateForTest_ShouldReturnEmptyListForTooManyStats()
        {
            string setArtifact = "Церемония древней знати";
            string piece = "Цветок жизни";
            string mainStat = "HP";
            string hp = "10";
            string atk = "20";
            string def = "30";
            string em = "63";
            string er = "12";
            string critRate = "5";
            string critDmg = "10";

            List<Character> result = CalculatorServices.CalculateForTest(setArtifact, piece, mainStat, hp, atk, def, em, er, critRate, critDmg);

            Assert.IsTrue(result.Count == 0);
        }
    }
}
