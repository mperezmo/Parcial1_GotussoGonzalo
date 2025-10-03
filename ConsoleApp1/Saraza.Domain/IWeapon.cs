namespace Saraza.Domain
{
    /// <summary>
    /// Defines the contract for a weapon that can attack a target.
    /// This is the "Strategy" interface for our design pattern.
    /// </summary>
    public interface IWeapon
    {
        string Name { get; }
        bool Attack(double distance);
    }
}