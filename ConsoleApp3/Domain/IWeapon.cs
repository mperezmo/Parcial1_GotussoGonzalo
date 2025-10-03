namespace Domain
{
    public interface IWeapon
    {
        string Name { get; }
        Shot Fire(Target target);
    }
}