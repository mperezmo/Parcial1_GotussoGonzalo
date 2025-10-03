using DAL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;


namespace DAL
{
    public class Repository : IGenericDAL<Robot>
    {
        private readonly string _filePath;

        public Repository(string filePath)
        {
            _filePath = filePath;

            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Dispose();
            }
        }

        public void Store(Robot objeto)
        {
            try
            {
                using (FileStream fs = new FileStream(_filePath, FileMode.Append, FileAccess.Write))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, objeto);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al almacenar el objeto: {ex.Message}");
                throw;
            }
        }

        public List<Robot> LoadPorValor(string propiedad, DateTime fechaDesde, DateTime fechaHasta)
        {
            var resultado = new List<Robot>();
            try
            {
                using (FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    while (fs.Position < fs.Length)
                    {
                        var objeto = (Robot)formatter.Deserialize(fs);
                        if (objeto != null && Comparar(objeto, propiedad, fechaDesde, fechaHasta))
                        {
                            resultado.Add(objeto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar los datos: {ex.Message}");
                throw;
            }
            return resultado;
        }

        private bool Comparar(Robot objeto, string propiedad, DateTime fechaDesde, DateTime fechaHasta)
        {
            var propInfo = objeto.GetType().GetProperty(propiedad, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
            if (propInfo != null && propInfo.PropertyType == typeof(DateTime))
            {
                var value = (DateTime)propInfo.GetValue(objeto);
                return value >= fechaDesde && value <= fechaHasta;
            }
            return false;
        }
    }
}
