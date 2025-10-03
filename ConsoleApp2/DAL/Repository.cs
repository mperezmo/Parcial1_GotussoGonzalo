using Domain;
using System.IO;
using System.Text;

namespace DAL
{
    public class ShotRepository
    {
        private readonly string _filePath = "shot_log.txt";
        private static int _lastId = 0;

        public ShotRepository()
        {
            // In a real application, you would load the last ID from the database or file.
            if (File.Exists(_filePath))
            {
                try
                {
                    var lines = File.ReadAllLines(_filePath);
                    if (lines.Length > 0)
                    {
                        var lastLine = lines[lines.Length - 1];
                        var idPart = lastLine.Split(',')[0].Split(':')[1].Trim();
                        _lastId = int.Parse(idPart);
                    }
                }
                catch
                {
                    // If the file is corrupt or empty, start from 0.
                    _lastId = 0;
                }
            }
        }

        public void SaveShot(Shot shot)
        {
            shot.Id = ++_lastId;
            // In a real relational DB, the data would be normalized.
            // For example, WeaponUsed could be a foreign key to a Weapons table.
            // Here, we persist to a simple CSV-like format.
            string logEntry = $"Id:{shot.Id},Timestamp:{shot.Timestamp:O},Distance:{shot.TargetDistance},Weapon:{shot.WeaponUsed},Hit:{shot.WasHit}\n";

            File.AppendAllText(_filePath, logEntry, Encoding.UTF8);
            Console.WriteLine($"[LOG] Shot {shot.Id} saved to persistence.");
        }
    }
}
