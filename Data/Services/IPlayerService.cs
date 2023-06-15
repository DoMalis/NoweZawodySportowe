using ProjektZawody.Models;

namespace ProjektZawody.Data.Services
{
    public interface IPlayerService
    {
        List<Player> GetAll();

        Player GetPlayerById(int id);

        void Add(Player player);

        Player Update(int id, Player player);

        void Delete(int id);

        void JoinCompetition(Score score);

        List<Competition> GetAvailableCompetitions(int id);



    }
}
