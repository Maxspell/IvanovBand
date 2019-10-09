using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IvanovBand.Domain.Abstract;
using IvanovBand.WebUI.Models;

namespace IvanovBand.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private IMemberRepository repository;

        public AboutController(IMemberRepository repo)
        {
            repository = repo;
        }

        public ViewResult List()
        {
            return View(repository.Members);
        }

        public ViewResult Details(int? id)
        {
            return View(repository.Members.FirstOrDefault(m => m.MemberID == id));
        }

    }
}
