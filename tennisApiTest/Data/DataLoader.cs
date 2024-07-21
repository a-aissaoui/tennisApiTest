using System.Text.Json;
using tennisApiTest.Models;

namespace tennisApiTest.Data
{
    public class DataLoader
    {
        public static List<Player> LoadPlayers(string path)
        {
            try
            {
                var json = System.IO.File.ReadAllText(path);
                var playersData = JsonSerializer.Deserialize<PlayersList>(json);
                return playersData?.players;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Class : DataLoader , Method : LoadPlayers , Erreur : Erreur lors du chargement des données des joueurs : {ex.Message}");
                throw;
            }
        }
    }
}
