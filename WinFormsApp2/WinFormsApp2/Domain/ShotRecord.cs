using System;

namespace WinFormsApp2.Domain
{
    public sealed class ShotRecord
    {
        public DateTime TimestampUtc { get; init; }
        public string Weapon { get; init; } = string.Empty;
        public double DistanceKm { get; init; }
        public bool Hit { get; init; }
    }
}