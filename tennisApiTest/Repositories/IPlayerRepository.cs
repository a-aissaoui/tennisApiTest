using tennisApiTest.Models;

namespace tennisApiTest.Repositories
{
    public interface IPlayerRepository
    {
        // retourne la liste des joueurs
        IEnumerable<Player> GetAllPlayers();


        // retourne les informations d’un joueur grâce à son ID.
        Player GetPlayerById(int id);
    }
}
