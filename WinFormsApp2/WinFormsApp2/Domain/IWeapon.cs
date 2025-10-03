namespace WinFormsApp2.Domain
{
    public interface IWeapon
    {
        string Name { get; }
        double MinKm { get; }
        double MaxKm { get; }
        bool CanHandle(double distanceKm);
        bool Fire(double distanceKm);
    }
}