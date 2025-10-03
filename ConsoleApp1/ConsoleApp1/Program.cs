using Saraza.BLL;
using Saraza.DAL;

// 1. Composition Root: Initialize layers and dependencies.
const string databaseFile = "shot_history.json";
IShotRepository shotRepository = new JsonShotRepository(databaseFile);
AttackService attackService = new AttackService(shotRepository);

// 2. Radar Simulation: A list of targets at various distances.
var targets = new List<double> { 5, 15, 75, 250, 45 };

Console.WriteLine("--- Military Attack System Initialized ---");
Console.WriteLine($"Target data will be saved to '{Path.GetFullPath(databaseFile)}'");

// 3. Main Loop: Simulate attacking targets when the user presses a key.
foreach (var distance in targets)
{
    Console.WriteLine("\n------------------------------------------");
    Console.WriteLine($"New target detected at {distance}km.");
    Console.WriteLine("Press any key to engage the target...");
    Console.ReadKey(intercept: true);

    // The service handles weapon selection, attack, and persistence.
    attackService.AttackTarget(distance);
}

Console.WriteLine("\n------------------------------------------");
Console.WriteLine("All targets processed. Mission complete.");
