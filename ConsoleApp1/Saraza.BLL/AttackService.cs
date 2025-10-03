using Saraza.BLL.Weapons;
using Saraza.DAL;
using Saraza.Domain;

namespace Saraza.BLL
{
    /// <summary>
    /// Main business logic service. This is the "Context" for the Strategy pattern.
    /// </summary>
    public class AttackService
    {
        private readonly IShotRepository _shotRepository;
        private IWeapon _currentWeapon;

        public AttackService(IShotRepository shotRepository)
        {
            _shotRepository = shotRepository;
            // Default to a safe state with no weapon selected.
            _currentWeapon = new NoWeapon(); 
        }

        /// <summary>
        /// Selects the appropriate weapon based on target distance.
        /// </summary>
        public void SelectWeaponForTarget(double distance)
        {
            if (distance < 10)
            {
                _currentWeapon = new ShortRangeCannon();
            }
            else if (distance >= 10 && distance <= 50)
            {
                _currentWeapon = new UltrasonicCannon();
            }
            else if (distance > 50 && distance < 200)
            {
                _currentWeapon = new BionicDestructorLaser();
            }
            else
            {
                _currentWeapon = new NoWeapon(); // Target is out of range
            }
        }

        /// <summary>
        /// Attacks the target with the currently selected weapon and persists the result.
        /// </summary>
        public void AttackTarget(double distance)
        {
            SelectWeaponForTarget(distance);

            bool success = _currentWeapon.Attack(distance);

            Console.WriteLine(success ? "Target hit successfully!" : "Attack failed or target out of range.");

            var shot = new Shot
            {
                Id = Guid.NewGuid(),
                Timestamp = DateTime.UtcNow,
                WeaponUsed = _currentWeapon.Name,
                TargetDistance = distance,
                WasSuccessful = success
            };

            _shotRepository.Save(shot);
            Console.WriteLine("Shot outcome has been recorded.");
        }
    }

    /// <summary>
    /// Null Object Pattern: A safe default strategy for when no other weapon is suitable.
    /// </summary>
    internal class NoWeapon : IWeapon
    {
        public string Name => "N/A";
        public bool Attack(double distance)
        {
            Console.WriteLine($"Target at {distance}km is out of effective range of all weapons.");
            return false;
        }
    }
}