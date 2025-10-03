using BLL.Contracts;
using DAL;
using DAL.Contracts;
using Domain;
using System;
using System.Collections.Generic;


namespace BLL
{
    public class Negocio : IGenericBLL<string, bool, List<Robot>>
    {
        private readonly IGenericDAL<Robot> _repository;
        private readonly IAdvertenciaFactory _advertenciaFactory;

        // Constructor que recibe la ruta del archivo
        public Negocio(string filePath)
        {
            _repository = new Repository(filePath);
            _advertenciaFactory = new AdvertenciaFactory();
        }

        public string Movimiento(bool s1, bool s2)
        {
            try
            {
                string estadoActual = DeterminarEstado(s1, s2);
                var estado = _advertenciaFactory.CrearAdvertencia(estadoActual);
                var robot = new Robot(s1, s2)
                {
                    Estado = estado
                };

                if (!estadoActual.Equals(EstadoSistema.Estado))
                {
                    EstadoSistema.Estado = estadoActual;
                    _repository.Store(robot);
                }

                return estado.Moverse();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error en Movimiento: {ex.Message}");
                throw;
            }
        }

        private string DeterminarEstado(bool s1, bool s2)
        {
            if (s1 && s2)
                return "AvanzarEntity";
            if (s1 && !s2)
                return "GirarIzquierdaEntity";
            if (!s1 && s2)
                return "GirarDerechaEntity";
            if (!s1 && !s2)
                return "RetrocederEntity";

            throw new InvalidOperationException("Combinación de sensores inválida");
        }

        public List<Robot> Reporte(string propiedad, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                if (fechaDesde > fechaHasta)
                {
                    throw new ArgumentException("La fecha de inicio no puede ser posterior a la fecha de fin.");
                }

                return _repository.LoadPorValor(propiedad, fechaDesde, fechaHasta);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Reporte: {ex.Message}");
                throw;
            }
        }
    }
}
