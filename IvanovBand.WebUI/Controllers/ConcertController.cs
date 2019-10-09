using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IvanovBand.Domain.Abstract;
using IvanovBand.Domain.Entities;
using IvanovBand.WebUI.Models;
using IvanovBand.WebUI.HtmlHelpers;

namespace IvanovBand.WebUI.Controllers
{
    public class ConcertController : Controller
    {
        private IConcertRepository repository;

        public ConcertController(IConcertRepository concertsRepository)
        {
            repository = concertsRepository;
        }

        public PartialViewResult ConcertList()
        {
            return PartialView(repository.Concerts.OrderByDescending(c => c.Date));
        }

    }
}
