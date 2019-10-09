using System.Web;
using System.Linq;
using System.Web.Mvc;
using IvanovBand.Domain.Abstract;
using IvanovBand.Domain.Entities;
using IvanovBand.WebUI.Models;
using System.Collections.Generic;
using System.IO;

namespace IvanovBand.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class ConcertController : Controller
    {
        public int PageSize = 10;
        private IConcertRepository repository;

        public ConcertController(IConcertRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Concerts.OrderBy(m => m.Date));
        }

        public ViewResult Edit(int concertId)
        {
            return View(repository.Concerts.FirstOrDefault(m => m.ConcertId == concertId));
        }

        [HttpPost]
        public ActionResult Edit(Concert concert)
        {
            if (ModelState.IsValid)
            {
                repository.SaveConcert(new Concert()
                {
                    ConcertId = concert.ConcertId,
                    Date = concert.Date,
                    Content = concert.Content
                });
                TempData["message"] = string.Format("{0} has been saved", concert.ConcertId);
                return RedirectToAction("Index");
            }
            else
            {
                return View(concert);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Concert());
        }

        [HttpPost]
        public ActionResult Delete(int concertId)
        {
            Concert concert = repository.Concerts.FirstOrDefault(m => m.ConcertId == concertId);
            if (concert != null)
            {
                repository.DeleteConcert(concert);
                TempData["message"] = string.Format("{0} was deleted", concert.ConcertId);
            }
            return RedirectToAction("Index");
        }
    }
}
