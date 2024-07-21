using tennisApiTest.Models;

namespace tennisApiTest.Services
{
    public interface IPlayerService
    {
        // retourne les joueurs et trier du meilleur au moins bon.
        IEnumerable<Player> GetSortedPlayers();

        //retourner les informations d’un joueur grâce à son ID.
        Player GetPlayerById(int id);

        // retourne les statistiques
        Statistics GetStatistics();
    }
}
