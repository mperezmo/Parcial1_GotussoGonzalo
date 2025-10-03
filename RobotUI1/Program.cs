using BLL;
using BLL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;


namespace RobotUI1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Leer la ruta del archivo desde App.config
            string filePath = ConfigurationManager.AppSettings["RobotDataFilePath"];

            if (string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine("La ruta del archivo de datos no está configurada en App.config.");
                return;
            }

            // Instanciar manualmente la BLL pasando la ruta del archivo
            IGenericBLL<string, bool, List<Robot>> business = new Negocio(filePath);

            // Inicialización del Robot y el Sensor
            var robot = new Robot(true, true);
            var sensor = new Sensor("Sensores");
            sensor.Subscribe(robot);

            // Estado inicial del sistema
            EstadoSistema.Estado = "Inicial";

            while (true)
            {
                MostrarMenu();
                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            ActivarSensores(sensor, business, robot);
                            break;
                        case 2:
                            ConsultarHistorial(business);
                            break;
                        case 3:
                            Console.WriteLine("Saliendo del sistema...");
                            return;
                        default:
                            Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingresa un número.");
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("         Sistema de Control del Robot        ");
            Console.WriteLine("=============================================");
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Ingresar valores de sensores");
            Console.WriteLine("2. Consultar historial");
            Console.WriteLine("3. Salir");
            Console.Write("Opción: ");
        }

        static void ActivarSensores(Sensor sensor, IGenericBLL<string, bool, List<Robot>> business, Robot robot)
        {
            for (int i = 0; i < 10; i++)
            {
                sensor.Activate();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine(business.Movimiento(robot.Sensor1, robot.Sensor2));
                Console.WriteLine("---------------------------------------------\n");
                Thread.Sleep(3000);
            }
        }

        static void ConsultarHistorial(IGenericBLL<string, bool, List<Robot>> business)
        {
            try
            {
                Console.WriteLine("Ingrese la fecha de inicio (DD/MM/AAAA):");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime fechaDesde))
                {
                    Console.WriteLine("Fecha inválida.");
                    return;
                }

                Console.WriteLine("Ingrese la fecha de fin (DD/MM/AAAA):");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime fechaHasta))
                {
                    Console.WriteLine("Fecha inválida.");
                    return;
                }

                var report = business.Reporte("FechaHora", fechaDesde, fechaHasta);
                Console.WriteLine("\nLos cambios se muestran a continuación:");
                Console.WriteLine("=============================================");

                foreach (var item in report)
                {
                    Console.WriteLine($"Fecha y Hora: {item.FechaHora}");
                    Console.WriteLine($"Sensor 1: {item.Sensor1}");
                    Console.WriteLine($"Sensor 2: {item.Sensor2}");
                    Console.WriteLine($"Acción: {item.Estado.Moverse()}");
                    Console.WriteLine("---------------------------------------------");
                }

                if (report.Count == 0)
                {
                    Console.WriteLine("No se encontraron registros en el rango de fechas especificado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consultar historial: {ex.Message}");
            }
        }
    }
}

