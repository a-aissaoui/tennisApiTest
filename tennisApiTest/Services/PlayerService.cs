using tennisApiTest.Models;
using tennisApiTest.Repositories;

namespace tennisApiTest.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _repository;

        public PlayerService(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Player> GetSortedPlayers()
        {
            // retourne les joueurs et trier du meilleur au moins bon.
            return _repository.GetAllPlayers().OrderByDescending(p => p.data.points).ToList();
        }

        public Player GetPlayerById(int id)
        {
            //retourner les informations d’un joueur grâce à son ID.
            return _repository.GetPlayerById(id);
        }


        // retourne les statistiques
        public Statistics GetStatistics()
        {
            try
            {
                // charger tous les joueurs
                var players = _repository.GetAllPlayers().ToList();

                Statistics statistics = new Statistics();


                if (players != null)
                {
                    statistics = new Statistics
                    {
                        // Extraire Pays qui a le plus grand ratio de parties gagnées

                        CountryWithHighestWinRatio = players
                        .GroupBy(p => p.country.code)
                        .OrderByDescending(g => g.Average(p => p.data.last.Count(l => l == 1) / (double)p.data.last.Count))
                        .FirstOrDefault()?.Key,

                        //Calcul IMC moyen de tous les joueurs
                        AverageIMC = players.Average(p => (p.data.weight / 1000.0) / Math.Pow(p.data.height / 100.0, 2)),

                        // Calcul de La médiane de la taille des joueurs
                        MedianHeight = GetMedian(players.Select(p => p.data.height).ToList())
                    };
                }
                else
                {
                    statistics = null;
                    // retourner un message indiquant que la liste des joueurs est null
                    Console.WriteLine(("Liste des joueurs null"));
                }

                return statistics;

            }
            catch (Exception ex)
            {
                // Gérer l'exception ici
                Console.WriteLine($"Une erreur s'est produite lors du calcul des statistiques : {ex.Message}");
                return null;
            }
        }

        private double GetMedian(List<int> heights)
        {
            heights.Sort();
            int count = heights.Count;
            if (count % 2 == 0)
            {
                return (heights[count / 2 - 1] + heights[count / 2]) / 2.0;
            }
            return heights[count / 2];
        }


    }
}
