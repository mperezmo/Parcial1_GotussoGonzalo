using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Retroceder : Advertencia
    {
        public override string Moverse()
        {
            return "Retrocediendo y emitiendo sonido";
        }
    }
}
