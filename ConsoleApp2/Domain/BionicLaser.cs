namespace Domain
{
    // Concrete Strategy 3: Long-range weapon.
    public class BionicLaser : IWeaponStrategy
    {
        public void Attack(Target target)
        {
            Console.WriteLine($"Attacking target at {target.Distance}km with Bionic Destructor Laser Beam.");
        }

        public string GetWeaponName() => "Bionic Destructor Laser Beam";
    }
}