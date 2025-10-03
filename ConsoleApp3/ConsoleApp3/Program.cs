using BLL;
using DAL;
using Domain;

// Configuración de Inyección de Dependencias (manual para simplicidad)
IShotRepository shotRepository = new ShotRepository();
WeaponSystem weaponSystem = new WeaponSystem(shotRepository);

Console.WriteLine("Iniciando sistema de ataque...");
Console.WriteLine("Ingrese la distancia del objetivo en km o escriba 'salir' para terminar.");

while (true)
{
    Console.Write("\nDistancia del objetivo: ");
    string input = Console.ReadLine() ?? "";

    if (input.Equals("salir", StringComparison.OrdinalIgnoreCase))
    {
        break; // Salir del bucle si el usuario escribe "salir"
    }

    if (double.TryParse(input, out double distance))
    {
        // Si la entrada es un número válido, crear el objetivo y atacar
        var target = new Target { Distance = distance };
        
        Console.WriteLine($"Nuevo objetivo detectado a {target.Distance} km.");
        
        // Simula la presión del botón de ataque
        weaponSystem.Attack(target);
    }
    else
    {
        // Si la entrada no es un número válido
        Console.WriteLine("Entrada no válida. Por favor, ingrese un número para la distancia.");
    }
}

Console.WriteLine("\n------------------------------------");
Console.WriteLine("Sistema finalizado.");
