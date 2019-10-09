using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IvanovBand.Domain.Abstract;
using IvanovBand.Domain.Entities;

namespace IvanovBand.WebUI.Controllers
{
    public class SlideController : Controller
    {
        private ISlideRepository repository;

        public SlideController(ISlideRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Index()
        {
            return PartialView(repository.Sliders.OrderBy(s => s.Order));
        }

    }
}
