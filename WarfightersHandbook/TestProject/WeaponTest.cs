using Warfighters.Services;

namespace TestProject
{
    [TestClass]
    public class WeaponTest
    {
        [TestMethod]
        public void GetWeapon_ShouldReturnListOfWeapons()
        {
            List<string> result;
            result = ArtifactServices.GetArtifactsName();
            Assert.IsNotNull(result);
        }
    }
}
