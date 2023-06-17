using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektZawody.Data;
using ProjektZawody.Data.Services;
using ProjektZawody.Models;
using System.Numerics;

namespace ProjektZawody.Controllers
{
    //[Route("api/players")]
    //[ApiController]
    //[Authorize]
    public class PlayersController : Controller //klasa będąca kontrolerem playera, przekierowuje do stron w zależności od wybranej czynności
    {
        //interfejs serwisu
        private readonly IPlayerService _service;

        public PlayersController(IPlayerService service)
        {
            _service = service;
        }

        //strona wyświetlająca listę players
        //używane do czasochlonnych operacji np. dostęp do bazy danych
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.PageTitle = "Lista graczy";
            var data = _service.GetAll();
            return View(data);
        }

        //Get: Players/Create
        //strona dodawania nowego użytkownika
        public IActionResult Create()
        {
            ViewBag.PageTitle = "Dodawanie gracza";
            return View();
        }
        //wynik dodwania nowego użytkownika
        [HttpPost]
        public IActionResult Create([Bind("FirstName,LastName,Age")] Player player)
        {
            if (!ModelState.IsValid)
            {
                return View(player);
            }
            _service.Add(player);
            return RedirectToAction("Index");
        }

        //Get: Players/Details/1
        public IActionResult Details(int id)
        {
            ViewBag.PageTitle = "Szczegóły gracza";
            var details = _service.GetPlayerById(id);
            if (details == null) return View("NotFound");
            return View(details);
        }

        //Get: Players/Edit
        public IActionResult Edit(int id)
        {
            ViewBag.PageTitle = "Edycja gracza";
            var details = _service.GetPlayerById(id);
            if (details == null) return View("NotFound");
            return View(details);
        }
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,FirstName,LastName,Age")] Player player)
        {
            if (!ModelState.IsValid)
            {
                return View(player);
            }
            _service.Update(id, player);
            return RedirectToAction("Index");
        }

        //Get: Players/Delete 
        public IActionResult Delete(int id)
        {
            ViewBag.PageTitle = "Usuwanie gracza";
            var details = _service.GetPlayerById(id);
            if (details == null) return View("NotFound");
            return View(details);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfiremd(int id)
        {
            var details = _service.GetPlayerById(id);
            if (details == null) return View("NotFound");

            _service.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult JoinCompetition(int playerId)
        {
            ViewBag.PageTitle = "Dołączanie do zawodów";
            var availableCompetitions = _service.GetAvailableCompetitions(playerId);
            if (availableCompetitions == null) return View("NotFound");
            ViewBag.PlayerId = playerId;

            return View(availableCompetitions);
        }

        //dołaczenie do zawodów nowego użytkownika
        [HttpPost]
        public IActionResult JoinCompetition(int playerId, int competitionId)
        {
            var score = new Score();
            score.CompetitionId = competitionId;

            score.PlayerId = playerId;
            score.Points = 0;
            var player = _service.GetPlayerById(playerId);
            if (!ModelState.IsValid)
            {
                return View("Details", player);
            }
            _service.JoinCompetition(score);
            return RedirectToAction("Details", player);

        }


    }
}
