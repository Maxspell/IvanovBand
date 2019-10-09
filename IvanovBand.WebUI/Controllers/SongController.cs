using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IvanovBand.Domain.Abstract;

namespace IvanovBand.WebUI.Controllers
{
    public class SongController : Controller
    {
        private ISongRepository repository;

        public SongController(ISongRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Songs.OrderBy(s => s.Order));
        }
    }
}
