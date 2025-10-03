namespace Domain
{
    // Concrete Strategy 1: Short-range weapon.
    public class ShortRangeCannon : IWeaponStrategy
    {
        public void Attack(Target target)
        {
            Console.WriteLine($"Attacking target at {target.Distance}km with Short-Range Cannon.");
        }

        public string GetWeaponName() => "Short-Range Cannon";
    }
}