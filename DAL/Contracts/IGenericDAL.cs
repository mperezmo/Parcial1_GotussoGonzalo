using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IGenericDAL<T>
    {
        void Store(T obj);
        List<T> LoadPorValor(string propiedad, DateTime fechaDesde, DateTime fechaHasta);
    }
}
