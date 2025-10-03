namespace Domain
{
    // Concrete Strategy 2: Medium-range weapon.
    public class UltrasonicCannon : IWeaponStrategy
    {
        public void Attack(Target target)
        {
            Console.WriteLine($"Attacking target at {target.Distance}km with Ultrasonic Cannon.");
        }

        public string GetWeaponName() => "Ultrasonic Cannon";
    }
}