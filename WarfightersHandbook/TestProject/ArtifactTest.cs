using Warfighters.Models;
using Warfighters.Services;

namespace TestProject
{
    [TestClass]
    public class ArtifactTest
    {
        [TestMethod]
        public void GetSetArtifact_ShouldReturnListOfSetArtifacts()
        {
            List<SetArtifact> result = ArtifactServices.GetSetArtifact();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetArtifactsName_ShouldReturnListOfArtifactNames()
        {
            List<string> result = ArtifactServices.GetArtifactsName();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetMainStatsName_ShouldReturnListOfMainStatsNames()
        {
            List<string> result = ArtifactServices.GetMainStatsName();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetSetsName_ShouldReturnListOfSetsNames()
        {
            List<string> result = ArtifactServices.GetSetsName();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetArtifactIDByName_ShouldReturnArtifactID()
        {
            string testName = "Цветок жизни";
            int result = ArtifactServices.GetArtifactIDByName(testName);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void GetArtifactIDByName_ShouldReturnMinusOneForNonExistentArtifact()
        {
            string nonExistentName = "Перо";
            int result = ArtifactServices.GetArtifactIDByName(nonExistentName);
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void GetMainStatsByArtifactId_ShouldReturnListOfMainStats()
        {
            int testArtifactId = 1;
            List<string> result = ArtifactServices.GetMainStatsByArtifactId(testArtifactId);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void GetMainStatsByArtifactId_ShouldReturnEmptyListForNonExistentArtifactId()
        {
            int nonExistentArtifactId = -1;
            List<string> result = ArtifactServices.GetMainStatsByArtifactId(nonExistentArtifactId);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 0);
        }

    }
}
