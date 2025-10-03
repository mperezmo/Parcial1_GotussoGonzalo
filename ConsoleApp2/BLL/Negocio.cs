using DAL;
using Domain;

namespace BLL
{
    public class MilitarySystem
    {
        private IWeaponStrategy _weaponStrategy;
        private readonly ShotRepository _shotRepository;

        public MilitarySystem()
        {
            _shotRepository = new ShotRepository();
        }

        // This method dynamically selects the weapon strategy based on the target's distance.
        public void SelectWeapon(Target target)
        {
            if (target.Distance < 10)
            {
                _weaponStrategy = new ShortRangeCannon();
            }
            else if (target.Distance >= 10 && target.Distance <= 50)
            {
                _weaponStrategy = new UltrasonicCannon();
            }
            else if (target.Distance > 50 && target.Distance < 200)
            {
                _weaponStrategy = new BionicLaser();
            }
            else
            {
                _weaponStrategy = null; // No weapon available for this range.
            }
        }

        public void AttackTarget(Target target)
        {
            SelectWeapon(target);

            if (_weaponStrategy == null)
            {
                Console.WriteLine($"Target at {target.Distance}km is out of range for all available weapons.");
                return;
            }

            // Execute the attack using the selected strategy.
            _weaponStrategy.Attack(target);

            // Simulate if the shot was a hit (e.g., random chance).
            bool wasHit = new Random().Next(0, 100) > 20; // 80% chance of hitting.

            // Create the shot record.
            var shot = new Shot
            {
                Timestamp = DateTime.UtcNow,
                TargetDistance = target.Distance,
                WeaponUsed = _weaponStrategy.GetWeaponName(),
                WasHit = wasHit
            };

            // Persist the shot record using the repository.
            _shotRepository.SaveShot(shot);

            Console.WriteLine(wasHit ? "It's a HIT!" : "It's a MISS!");
        }
    }
}
