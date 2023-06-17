using Microsoft.EntityFrameworkCore;
using ProjektZawody.Models;

namespace ProjektZawody.Data.Services
{
    public class PlayersService : IPlayerService
    {
        private readonly AppDbContext _context;
        public PlayersService(AppDbContext context)
        {
            _context = context;
        }


        public void Add(Player player)
        {
            player.Scores=new List<Score>();
            _context.Add(player);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = _context.Players.FirstOrDefault(n => n.Id == id);
            _context.Players.Remove(result);
            _context.SaveChanges();
        }

        public List<Player> GetAll()
        {
            var result = _context.Players.ToList();
            return result;
        }

        public Player GetPlayerById(int id)
        {
            var result = _context.Players.Include(p => p.Scores).FirstOrDefault(n => n.Id == id);
            if (result != null)
            {
                foreach (var score in result.Scores)
                {
                    score.Player = result;
                    score.Competition = _context.Competitions.FirstOrDefault(c => c.Id == score.CompetitionId);
                }
            }
            return result;
        }

        public Player Update(int id, Player player)
        {
            _context.Update(player);
            _context.SaveChanges();
            return player;

        }

        public List<Competition> GetAvailableCompetitions(int id) //zwraca listę zawodów w których zawodnik o danym id nie bieerze udziału i w którym przedziale wiekowym się mieści
            {
            var age=GetPlayerById(id).Age;
            var result = _context.Competitions
                .Where(c=> c.CompetitionStatus==Enums.CompetitionStatus.Notstarted)
                .Where(c => !c.Scores.Any(p => p.PlayerId == id) )
                .Where(c => c.MaxAge>=age && c.MinAge <= age)
                .ToList();
            return result;
}


        public void JoinCompetition(Score score)
        {
            _context.Scores.Add(score);
            _context.SaveChanges();
        }


    }
}
