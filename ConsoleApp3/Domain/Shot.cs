namespace Domain
{
    public class Shot
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public double TargetDistance { get; set; }
        public string WeaponUsed { get; set; }
        public bool WasSuccessful { get; set; }
    }
}