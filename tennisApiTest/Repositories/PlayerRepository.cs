using tennisApiTest.Models;
using tennisApiTest.Data;
using System.Text.Json;

namespace tennisApiTest.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<Player> _players;

        public PlayerRepository()
        {
            try
            {
                // Charger les données des joueurs à partir du fichier JSON
                var rootPath = Directory.GetCurrentDirectory();
                var jsonPath = Path.Combine(rootPath, "headtohead.json");
                _players = DataLoader.LoadPlayers(jsonPath);
            }
            catch (FileNotFoundException)
            {
                // Gérer l'erreur si le fichier n'est pas trouvé
                Console.WriteLine("Le fichier JSON n'a pas été trouvé.");
                _players = new List<Player>();
            }
            catch (JsonException)
            {
                // Gérer l'erreur si le fichier JSON est vide ou mal formaté
                Console.WriteLine("Le fichier JSON est vide ou mal formaté.");
                _players = new List<Player>();
            }
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            // retourne la liste des joueurs
            return _players;
        }

        public Player GetPlayerById(int id)
        {
            // retourne les informations d’un joueur grâce à son ID.
            return _players.FirstOrDefault(p => p.id == id);
        }
    }
}
