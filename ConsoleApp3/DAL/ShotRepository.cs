using Domain;

namespace DAL
{
    public class ShotRepository : IShotRepository
    {
        private readonly string _filePath = "C:\\temp\\shots_log.txt";

        public void Save(Shot shot)
        {
            // Formatea los detalles del disparo en una sola línea de texto.
            string logEntry = $"Timestamp: {shot.Timestamp:yyyy-MM-dd HH:mm:ss}, " +
                              $"Distancia: {shot.TargetDistance} km, " +
                              $"Arma: {shot.WeaponUsed}, " +
                              $"Resultado: {(shot.WasSuccessful ? "Acertado" : "Fallido")}" +
                              Environment.NewLine;

            // Anexa la nueva línea al archivo de log.
            // File.AppendAllText se encarga de crear el archivo si no existe.
            File.AppendAllText(_filePath, logEntry);

            Console.WriteLine($"Disparo registrado en {_filePath}");
        }
    }
}