using System;

namespace WinFormsApp2.Domain
{
    public sealed class Target
    {
        public Guid Id { get; }
        public double DistanceKm { get; }
        public string Description => $"Target {Id.ToString()[..4]} - {DistanceKm:0.##} km";

        public Target(double distanceKm)
        {
            Id = Guid.NewGuid();
            DistanceKm = distanceKm;
        }

        public override string ToString() => Description;
    }
}