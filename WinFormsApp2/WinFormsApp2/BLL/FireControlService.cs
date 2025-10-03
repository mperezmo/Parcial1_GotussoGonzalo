using System.Collections.Generic;
using System.Linq;
using System;
using WinFormsApp2.Domain;
using WinFormsApp2.DAL;

namespace WinFormsApp2.BLL
{
    public sealed class FireControlService
    {
        private readonly List<IWeapon> _weapons;
        private readonly WeaponSelector _selector;
        private readonly IShotRepository _repo;

        public FireControlService(IEnumerable<IWeapon> weapons, IShotRepository repo)
        {
            _weapons = weapons.ToList();
            _selector = new WeaponSelector(_weapons);
            _repo = repo;
        }

        public IReadOnlyList<IWeapon> Weapons => _weapons;
        public WeaponSelector Selector => _selector;

        public ShotRecord Fire(IWeapon weapon, double distanceKm)
        {
            bool hit = weapon.CanHandle(distanceKm) && weapon.Fire(distanceKm);

            var record = new ShotRecord
            {
                TimestampUtc = DateTime.UtcNow,
                Weapon = weapon.Name,
                DistanceKm = distanceKm,
                Hit = hit
            };

            _repo.Append(record);
            return record;
        }

        public List<ShotRecord> GetHistory() => _repo.GetAll();
    }
}