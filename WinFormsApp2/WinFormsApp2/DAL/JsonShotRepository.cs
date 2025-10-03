using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WinFormsApp2.Domain;

namespace WinFormsApp2.DAL
{
    public sealed class JsonShotRepository : IShotRepository
    {
        private readonly string _filePath;
        private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };

        public JsonShotRepository(string filePath)
        {
            _filePath = filePath;
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }

        public void Append(ShotRecord record)
        {
            var list = GetAll();
            list.Add(record);
            var json = JsonSerializer.Serialize(list, Options);
            File.WriteAllText(_filePath, json);
        }

        public List<ShotRecord> GetAll()
        {
            try
            {
                var json = File.ReadAllText(_filePath);
                var list = JsonSerializer.Deserialize<List<ShotRecord>>(json, Options);
                return list ?? new List<ShotRecord>();
            }
            catch
            {
                return new List<ShotRecord>();
            }
        }
    }
}