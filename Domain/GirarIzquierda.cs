using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class GirarIzquierda : Advertencia
    {

        public override string Moverse()
        {
            return "Girando a la izquierda";
        }
    }
}
