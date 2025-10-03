namespace Domain
{
    // Represents a target with its distance from the base.
    public class Target
    {
        public int Distance { get; set; }
    }

    // Represents a recorded shot.
    public class Shot
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public int TargetDistance { get; set; }
        public string WeaponUsed { get; set; }
        public bool WasHit { get; set; }

        public override string ToString()
        {
            return $"Shot {Id}: At {Timestamp}, Target at {TargetDistance}km, Weapon: {WeaponUsed}, Result: {(WasHit ? "Hit" : "Miss")}";
        }
    }
}