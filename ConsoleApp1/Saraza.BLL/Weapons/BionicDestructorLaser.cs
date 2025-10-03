using Saraza.Domain;

namespace Saraza.BLL.Weapons
{
    /// <summary>
    /// Concrete Strategy: Weapon for targets between 50km and 200km.
    /// </summary>
    public class BionicDestructorLaser : IWeapon
    {
        public string Name => "Bionic destructor laser ray";

        public bool Attack(double distance)
        {
            Console.WriteLine($"Attacking with {Name} at {distance}km...");
            return distance > 50 && distance < 200;
        }
    }
}