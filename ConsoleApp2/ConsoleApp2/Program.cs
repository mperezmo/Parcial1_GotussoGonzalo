using BLL;
using Domain;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Military System Initialized. Press a key to simulate a target detection.");
            var militarySystem = new MilitarySystem();

            while (true)
            {
                Console.ReadKey();
                Console.WriteLine("\n-----------------------------------");
                Console.WriteLine("Radar detected a new enemy target!");

                // Simulate a target detected by radar at a random distance up to 250km.
                var target = new Target { Distance = new Random().Next(1, 250) };
                
                // The "button press" is simulated by this method call,
                // which dynamically selects the weapon and attacks.
                militarySystem.AttackTarget(target);
                Console.WriteLine("-----------------------------------\n");
                Console.WriteLine("Press any key for the next target or Ctrl+C to exit.");
            }
        }
    }
}
