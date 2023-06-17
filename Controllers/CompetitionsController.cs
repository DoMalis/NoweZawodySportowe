using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektZawody.Data;
using ProjektZawody.Data.Services;
using ProjektZawody.Data.ViewModels;
using ProjektZawody.Models;

namespace ProjektZawody.Controllers
{
    //[Route("api/competition")]
    //[ApiController]
    //[Authorize]
    public class CompetitionsController : Controller
    {
        private readonly ICompetitionService _service;

        public CompetitionsController(ICompetitionService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            ViewBag.PageTitle = "Lista zawodów";

            var data = _service.GetAll();
            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.PageTitle = "Dodawanie zawodów";

            return View();
        }

        //wynik dodwania nowych zawodów
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public IActionResult Create([Bind("Name,MinAge,MaxAge")] Competition competition)
        {
            if (!ModelState.IsValid)
            {
                return View(competition);
            }
            _service.Add(competition);
            return RedirectToAction("Index");
        }

        //Get: Competitions/Delete 

        public IActionResult Delete(int id)
        {
            ViewBag.PageTitle = "Usuwanie";

            var details = _service.GetCompetitionById(id);
            if (details == null) return View("NotFound");
            return View(details);
        }

        //wynik usuwania zawodów
        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            //uzyskujemy dane zawodów które planujemy usunąć
            var details = _service.GetCompetitionById(id);
            //jeśli nie istnieją, to przekierowywyujemy do strony notfound
            if (details == null) return View("NotFound");
            //wywyolujemy funkcje usuwania
            _service.Delete(id);
            //wracamy do strony głównej
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            ViewBag.PageTitle = "Szczegóły zawodów";

            var details = _service.GetCompetitionById(id);
            if (details == null) return View("NotFound");
            return View(details);
        }


        public IActionResult Edit(int id)
        {
            ViewBag.PageTitle = "Edycja";

            var details = _service.GetCompetitionById(id);
            if (details == null) return View("NotFound");
            return View(details);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin, Judge")]

        public IActionResult Edit(int id, [Bind("Id,Name,MinAge,MaxAge,CompetitionStatus")] Competition competition)
        {
            if (!ModelState.IsValid)
            {
                return View(competition);
            }
            _service.Update(id, competition);

            return RedirectToAction("Index");
        }


        public IActionResult Start(int id)
        {
            ViewBag.PageTitle = "Rozpoczęcie";

            var details = _service.GetCompetitionById(id);
            if (details == null) return View("NotFound");
            return View(details);
        }

        //wynik usuwania zawodów
        [HttpPost, ActionName("Start")]
        //[Authorize(Roles = "Admin, Judge")]
        public IActionResult StartConfirmed(int id)
        {
            var details = _service.GetCompetitionById(id);
            if (details == null) return View("NotFound");
            _service.StartCompetition(id);
            return RedirectToAction("Details", details);
        }

        public IActionResult Finish(int id)
        {
            ViewBag.PageTitle = "Zakończenie";

            var details = _service.GetScores(id);
            if (details == null) return View("NotFound");
            var detailsView = details.Select(s => new AddScoresViewModel
            {
                CompetitionId=s.CompetitionId,
                CompetitionName=s.Competition.Name,
                PlayerId=s.PlayerId,
                FirstName=s.Player.FirstName, 
                LastName=s.Player.LastName,
                Points=s.Points

            }).ToList();
          return View(detailsView);
        }

        [HttpPost, ActionName("Finish")]
        //[Authorize(Roles = "Admin, Judge")]
        public IActionResult FinishConfirmed(int id, List<AddScoresViewModel> scoresViewModel)
        {
            // Pobierz pełne dane zawodów z bazy danych
            var scores = _service.GetScores(id);
            if (scores == null)
                return View("NotFound");

            foreach(var scoreVM in scoresViewModel)
            {
                scores.Where(f=>f.PlayerId==scoreVM.PlayerId).FirstOrDefault().Points=scoreVM.Points;
            }

            if (!ModelState.IsValid)
            {
                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        // Tutaj można wyświetlić błąd lub podjąć odpowiednie działania
                        Console.WriteLine(error.ErrorMessage);
                    } 
                }
                return View(scoresViewModel) ;
            }

            _service.AddScores(id, scores);
            _service.FinishCompetition(id);
            var strona = _service.GetCompetitionById(id);
            return RedirectToAction("Details", strona);
        }

    }
}
