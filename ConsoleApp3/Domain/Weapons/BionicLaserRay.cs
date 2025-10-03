namespace Domain.Weapons
{
    public class BionicLaserRay : IWeapon
    {
        public string Name => "Rayo Láser Destructor Biónico";

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