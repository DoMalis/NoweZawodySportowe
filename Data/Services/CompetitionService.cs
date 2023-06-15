using Microsoft.EntityFrameworkCore;
using ProjektZawody.Models;
using System.Numerics;

namespace ProjektZawody.Data.Services
{
    public class CompetitionService : ICompetitionService
    {
        private readonly AppDbContext _context;
        public CompetitionService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Competition competition)
        {
            competition.CompetitionStatus = Enums.CompetitionStatus.Notstarted;
            _context.Add(competition);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var result=_context.Competitions.FirstOrDefault(x => x.Id == id);
            _context.Competitions.Remove(result);
            _context.SaveChanges();
        }

        public List<Competition> GetAll()
        {
            var result = _context.Competitions.ToList();
            return result;
        }

        public Competition GetCompetitionById(int id)
        {
            var result = _context.Competitions.Include(p=>p.Scores).FirstOrDefault(p => p.Id == id);
            if (result != null)
            {
                foreach (var score in result.Scores)
                {
                    score.Competition = result;
                    score.Player = _context.Players.FirstOrDefault(c => c.Id == score.PlayerId);
                }

            }
            return result;
        }

        public Competition Update(int id, Competition competition)
        {
            _context.Update(competition);
            _context.SaveChanges();
            return competition;
        }

        public void StartCompetition(int id)
        {
            var competition=_context.Competitions.FirstOrDefault(p => p.Id == id);
            competition.CompetitionStatus = Data.Enums.CompetitionStatus.InProgress;
            if (!competition.Scores.Any())
            { competition.CompetitionStatus = Data.Enums.CompetitionStatus.Finished; }


            _context.Update(competition);
            _context.SaveChanges();
        }
        public void FinishCompetition(int id)
        {
            var competition = _context.Competitions.FirstOrDefault(p => p.Id == id);
            competition.CompetitionStatus = Data.Enums.CompetitionStatus.Finished;
            _context.Update(competition);
            _context.SaveChanges();
        }

        public void AddScores(int id, List<Score> updatedScores)
        {
            var competition = _context.Competitions.Include(p => p.Scores).FirstOrDefault(p=>p.Id==id);
            competition.Scores.Clear();
            competition.Scores= updatedScores;
            _context.SaveChanges();
        }

        public List<Score> GetScores(int id)
        {
            var result = _context.Scores
                .Include(s => s.Player) 
                .Include(s => s.Competition) 
                .Where(s => s.CompetitionId == id) 
                .ToList();
            return result;
        }

    }
}
