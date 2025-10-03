using System.Collections.Generic;
using System.Linq;
using WinFormsApp2.Domain;

namespace WinFormsApp2.BLL
{
    // Strategy/Factory-like selector
    public sealed class WeaponSelector
    {
        private readonly IReadOnlyList<IWeapon> _weapons;

        public WeaponSelector(IReadOnlyList<IWeapon> weapons)
        {
            _weapons = weapons;
        }

        // Rules:
        // d < 10: Short-range Cannon
        // 10 <= d <= 50: Ultrasonic Cannon
        // 50 < d < 200: Bionic Laser
        public IWeapon? SelectForDistance(double distanceKm)
        {
            // Explicit rule precedence to avoid floating-point edge cases.
            if (distanceKm < 10)
                return _weapons.FirstOrDefault(w => w is Domain.ShortRangeCannon);
            if (distanceKm >= 10 && distanceKm <= 50)
                return _weapons.FirstOrDefault(w => w is Domain.UltrasonicCannon);
            if (distanceKm > 50 && distanceKm < 200)
                return _weapons.FirstOrDefault(w => w is Domain.BionicLaser);

            return null; // Out of supported range
        }

        public IWeapon Next(IWeapon current)
        {
            int idx = _weapons.ToList().FindIndex(w => w.Name == current.Name);
            if (idx < 0 || _weapons.Count == 0) return current;
            return _weapons[(idx + 1) % _weapons.Count];
        }
    }
}