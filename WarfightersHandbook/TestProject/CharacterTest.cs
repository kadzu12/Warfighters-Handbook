using Warfighters.Models;
using Warfighters.Services;

namespace TestProject
{
    [TestClass]
    public class CharacterTest
    {
        [TestMethod]
        public void GetWeapon_ShouldReturnListOfWeapons()
        {
            List<Weapon> result = CharacterServices.GetWeapon();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetTalent_ShouldReturnListOfTalents()
        {
            List<Talent> result = CharacterServices.GetTalent();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetCharacters_ShouldReturnListOfCharacters()
        {
            List<Character> result = CharacterServices.GetCharacters();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetTolViewedCharacters_ShouldReturnListOfTopViewedCharacters()
        {
            List<Character> result = CharacterServices.GetTolViewedCharacters();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetDpsSS_ShouldReturnListOfDpsSSCharacters()
        {
            List<Character> result = CharacterServices.GetDpsSS();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetSubSS_ShouldReturnListOfSubSSCharacters()
        {
            List<Character> result = CharacterServices.GetSubSS();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetSupportSS_ShouldReturnListOfSupportSSCharacters()
        {
            List<Character> result = CharacterServices.GetSupportSS();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetDpsS_ShouldReturnListOfDpsSCharacters()
        {
            List<Character> result = CharacterServices.GetDpsS();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetSubS_ShouldReturnListOfSubSCharacters()
        {
            List<Character> result = CharacterServices.GetSubS();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetSupportS_ShouldReturnListOfSupportSCharacters()
        {
            List<Character> result = CharacterServices.GetSupportS();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetDpsA_ShouldReturnListOfDpsACharacters()
        {
            List<Character> result = CharacterServices.GetDpsA();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetSubA_ShouldReturnListOfSubACharacters()
        {
            List<Character> result = CharacterServices.GetSubA();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetSupportA_ShouldReturnListOfSupportACharacters()
        {
            List<Character> result = CharacterServices.GetSupportA();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetDpsB_ShouldReturnListOfDpsBCharacters()
        {
            List<Character> result = CharacterServices.GetDpsB();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 0);
        }
        [TestMethod]
        public void GetSubB_ShouldReturnListOfSubBCharacters()
        {
            List<Character> result = CharacterServices.GetSubB();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetSupportB_ShouldReturnListOfSupportBCharacters()
        {
            List<Character> result = CharacterServices.GetSupportB();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 0);
        }
        [TestMethod]
        public void GetDpsC_ShouldReturnListOfDpsCCharacters()
        {
            List<Character> result = CharacterServices.GetDpsC();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetSubC_ShouldReturnListOfSubCCharacters()
        {
            List<Character> result = CharacterServices.GetSubC();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetSupportC_ShouldReturnListOfSupportCCharacters()
        {
            List<Character> result = CharacterServices.GetSupportC();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetDpsD_ShouldReturnListOfDpsDCharacters()
        {
            List<Character> result = CharacterServices.GetDpsD();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 0);
        }
        [TestMethod]
        public void GetSubD_ShouldReturnListOfSubDCharacters()
        {
            List<Character> result = CharacterServices.GetSubD();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 0);
        }
        [TestMethod]
        public void GetSupportD_ShouldReturnListOfSupportDCharacters()
        {
            List<Character> result = CharacterServices.GetSupportD();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
