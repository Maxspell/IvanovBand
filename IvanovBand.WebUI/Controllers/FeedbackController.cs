using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IvanovBand.Domain.Entities;
using IvanovBand.Domain.Abstract;

namespace IvanovBand.WebUI.Controllers
{
    public class FeedbackController : Controller
    {
        private IFeedbackRepository repository;

        public FeedbackController(IFeedbackRepository repo)
        {
            repository = repo;
        }

        [HttpPost]
        public ActionResult Create(Feedback item)
        {
            if (ModelState.IsValid)
            {
                repository.SaveFeedback(new Feedback()
                {
                    FeedbackID = item.FeedbackID,
                    Date = item.Date,
                    Name = item.Name,
                    Email = item.Email,
                    Phone = item.Phone,
                    Message = item.Message
                });
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

    }
}
