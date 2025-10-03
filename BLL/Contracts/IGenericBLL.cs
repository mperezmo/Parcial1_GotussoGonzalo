using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface IGenericBLL<T, J, I>
    {
        T Movimiento(J S1, J S2);
        I Reporte(string propiedad, DateTime fechaDesde, DateTime fechaHasta);
    }
}
