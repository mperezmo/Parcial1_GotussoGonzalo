using System;

namespace WinFormsApp2.Domain
{
    public abstract class WeaponBase : IWeapon
    {
        public abstract string Name { get; }
        public abstract double MinKm { get; }
        public abstract double MaxKm { get; }

        public bool CanHandle(double distanceKm) =>
            distanceKm >= MinKm && distanceKm <= MaxKm;

        // Default Fire uses a probability; override if needed.
        public virtual bool Fire(double distanceKm)
        {
            // Simple hit chance; can be made smarter based on distance.
            double p = Name switch
            {
                "Short-range Cannon" => 0.85,
                "Ultrasonic Cannon" => 0.70,
                "Bionic Laser" => 0.60,
                _ => 0.5
            };
            return Random.Shared.NextDouble() < p;
        }
    }

    // d < 10
    public sealed class ShortRangeCannon : WeaponBase
    {
        public override string Name => "Short-range Cannon";
        public override double MinKm => 0;
        public override double MaxKm => 10 - double.Epsilon;
    }

    // 10 <= d <= 50
    public sealed class UltrasonicCannon : WeaponBase
    {
        public override string Name => "Ultrasonic Cannon";
        public override double MinKm => 10;
        public override double MaxKm => 50;
    }

    // 50 < d < 200
    public sealed class BionicLaser : WeaponBase
    {
        public override string Name => "Bionic Laser";
        public override double MinKm => 50 + double.Epsilon;
        public override double MaxKm => 200 - double.Epsilon;
    }
}