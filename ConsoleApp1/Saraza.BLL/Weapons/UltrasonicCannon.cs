using Saraza.Domain;

namespace Saraza.BLL.Weapons
{
    /// <summary>
    /// Concrete Strategy: Weapon for targets between 10km and 50km.
    /// </summary>
    public class UltrasonicCannon : IWeapon
    {
        public string Name => "Ultrasonic cannon";

        public bool Attack(double distance)
        {
            Console.WriteLine($"Attacking with {Name} at {distance}km...");
            return distance >= 10 && distance <= 50;
        }
    }
}