using Saraza.Domain;
using System.Text.Json;

namespace Saraza.DAL
{
    /// <summary>
    /// Implements the repository pattern using JSON file serialization for storage.
    /// </summary>
    public class JsonShotRepository : IShotRepository
    {
        private readonly string _filePath;

        public JsonShotRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<Shot> GetAll()
        {
            if (!File.Exists(_filePath))
            {
                return Enumerable.Empty<Shot>();
            }

            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Shot>>(json) ?? new List<Shot>();
        }

        public void Save(Shot shot)
        {
            var shots = GetAll().ToList();
            shots.Add(shot);

            string json = JsonSerializer.Serialize(shots, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}