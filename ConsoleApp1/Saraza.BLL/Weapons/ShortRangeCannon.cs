using Saraza.Domain;

namespace Saraza.BLL.Weapons
{
    /// <summary>
    /// Concrete Strategy: Weapon for targets less than 10km away.
    /// </summary>
    public class ShortRangeCannon : IWeapon
    {
        public string Name => "Short-range cannon";

        public bool Attack(double distance)
        {
            // Attack logic for this weapon.
            // For this simulation, it always succeeds within its effective range.
            Console.WriteLine($"Attacking with {Name} at {distance}km...");
            return distance < 10;
        }
    }
}