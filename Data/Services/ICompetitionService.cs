using ProjektZawody.Models;

namespace ProjektZawody.Data.Services
{
    public interface ICompetitionService
    {
        List<Competition> GetAll();

        Competition GetCompetitionById(int id);

        List<Score> GetScores(int id);

        void Add(Competition competition);

        Competition Update(int id, Competition competition);
        
        void Delete(int id);

        void StartCompetition(int id);

        void FinishCompetition(int id);

        void AddScores(int id, List<Score> scores);

    }
}
