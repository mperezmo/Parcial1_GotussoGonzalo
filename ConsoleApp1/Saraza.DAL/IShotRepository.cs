using Saraza.Domain;

namespace Saraza.DAL
{
    /// <summary>
    /// Defines the contract for persisting shot data.
    /// </summary>
    public interface IShotRepository
    {
        void Save(Shot shot);
        IEnumerable<Shot> GetAll();
    }
}