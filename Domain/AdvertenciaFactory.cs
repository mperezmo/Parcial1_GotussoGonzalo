using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AdvertenciaFactory : IAdvertenciaFactory
    {
        public Advertencia CrearAdvertencia(string estado)
        {
            switch (estado)
            {
                case "AvanzarEntity":
                    return new Avanzar();
                case "GirarIzquierdaEntity":
                    return new GirarIzquierda();
                case "GirarDerechaEntity":
                    return new GirarDerecha();
                case "RetrocederEntity":
                    return new Retroceder();
                default:
                    throw new ArgumentException("Estado desconocido");
            }
        }
    }
}
