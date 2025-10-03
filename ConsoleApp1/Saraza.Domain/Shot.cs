namespace Saraza.Domain
{
    /// <summary>
    /// Represents a single shot fired at a target.
    /// </summary>
    public class Shot
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string WeaponUsed { get; set; }
        public double TargetDistance { get; set; }
        public bool WasSuccessful { get; set; }
    }
}