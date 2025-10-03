using DAL;
using Domain;
using Domain.Weapons;

namespace BLL
{
    public class WeaponSystem
    {
        private readonly IShotRepository _shotRepository;
        private IWeapon _selectedWeapon;

        public WeaponSystem(IShotRepository shotRepository)
        {
            _shotRepository = shotRepository;
            _selectedWeapon = new ShortRangeCannon(); 
        }

        private void SelectWeapon(Target target)
        {
            if (target.Distance < 10)
            {
                _selectedWeapon = new ShortRangeCannon();
            }
            else if (target.Distance >= 10 && target.Distance <= 50)
            {
                _selectedWeapon = new UltrasonicCannon();
            }
            else if (target.Distance > 50 && target.Distance < 200)
            {
                _selectedWeapon = new BionicLaserRay();
            }
            else
            {
                throw new InvalidOperationException($"No hay arma disponible para un objetivo a {target.Distance} km.");
            }
        }

        public void Attack(Target target)
        {
            try
            {
                SelectWeapon(target);
                Shot shotResult = _selectedWeapon.Fire(target);
                _shotRepository.Save(shotResult);
                Console.WriteLine(shotResult.WasSuccessful ? "El disparo fue acertado." : "El disparo falló.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}