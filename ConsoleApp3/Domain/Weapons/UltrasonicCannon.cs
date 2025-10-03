namespace Domain.Weapons
{
    public class UltrasonicCannon : IWeapon
    {
        public string Name => "Cañón Ultrasónico";

        public Shot Fire(Target target)
        {
            Console.WriteLine($"Disparando {Name} a objetivo a {target.Distance} km.");
            return new Shot
            {
                Id = Guid.NewGuid(),
                Timestamp = DateTime.UtcNow,
                TargetDistance = target.Distance,
                WeaponUsed = Name,
                WasSuccessful = true
            };
        }
    }
}