using Warfighters.Models;
using Warfighters.Models.Data;

namespace Warfighters.Services
{
    public class WeaponServices
    {
        //Получение оружий
        public static List<Weapon> GetWeapon()
        {
            using (HoyoverseContext db = new())
            {
                var result = db.Weapons.ToList();
                return result;
            }
        }
    }
}
