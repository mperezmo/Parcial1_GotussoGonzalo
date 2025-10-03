namespace Domain
{
    // Strategy Interface: Defines the contract for all weapon strategies.
    public interface IWeaponStrategy
    {
        void Attack(Target target);
        string GetWeaponName();
    }
}