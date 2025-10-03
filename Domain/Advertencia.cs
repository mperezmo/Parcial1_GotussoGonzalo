using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable] // Marca la clase abstracta como serializable
    public abstract class Advertencia
    {
        public abstract string Moverse();
    }
}
