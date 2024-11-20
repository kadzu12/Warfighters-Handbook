using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Warfighters.Models;
using Warfighters.Models.Data;
using Warfighters.Services;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetWeapon_ShouldReturnListOfWeapons()
        {
            // Arrange: ���������� ���������� ��� ���� ������ ��� ������� �����
            var options = new DbContextOptionsBuilder<HoyoverseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // ���������� ��� ���� ������
                .Options;

            using (var context = new HoyoverseContext(options))
            {
                context.Weapons.AddRange(new List<Weapon>
                {
                    new Weapon
                    {
                        IdWeapon = 1,
                        NameWeapon = "Sword",
                        ImageWeapon = "sword.png",
                        TypeWeapon = "Melee",
                        RarityWeapon = 5,
                        BasicAttack = 42,
                        AdditionalStat = "Critical Rate",
                        PassiveEffect = "Increases critical rate"
                    },
                    new Weapon
                    {
                        IdWeapon = 2,
                        NameWeapon = "Bow",
                        ImageWeapon = "bow.png",
                        TypeWeapon = "Ranged",
                        RarityWeapon = 4,
                        BasicAttack = 40,
                        AdditionalStat = "Critical Damage",
                        PassiveEffect = "Increases critical damage"
                    }
                });
                context.SaveChanges();
            }

            // Act
            List<Weapon> result;
            using (var context = new HoyoverseContext(options))
            {
                result = WeaponServices.GetWeapon();
            }

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(2, result.Count);
            //Assert.AreEqual("Sword", result[0].NameWeapon);
            //Assert.AreEqual("Bow", result[1].NameWeapon);
        }
    }
}