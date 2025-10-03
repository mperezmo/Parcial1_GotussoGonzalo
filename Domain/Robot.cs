using Domain;
using System;

[Serializable] // Marca la clase como serializable
public class Robot : IObserver
{
    public bool Sensor1 { get; private set; }
    public bool Sensor2 { get; private set; }
    public DateTime FechaHora { get; private set; }
    public Advertencia Estado { get; set; }

    public Robot(bool sensor1, bool sensor2)
    {
        Sensor1 = sensor1;
        Sensor2 = sensor2;
        FechaHora = DateTime.Now;
    }

    public void Update(bool value1, bool value2)
    {
        Sensor1 = value1;
        Sensor2 = value2;
        FechaHora = DateTime.Now;
    }
}