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
    public class SlideController : Controller
    {
        private ISlideRepository repository;

        public SlideController(ISlideRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Sliders.OrderBy(s => s.SlideID));
        }

        public ViewResult Edit(int slideId)
        {
            return View(repository.Sliders.FirstOrDefault(s => s.SlideID == slideId));
        }

        [HttpPost]
        public ActionResult Edit(Slide slide, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var fileName = slide.Image;
                if (file != null && file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Uploads/Images"), fileName);
                    file.SaveAs(path);
                }
                repository.SaveSlide(new Slide()
                {
                    SlideID = slide.SlideID,
                    Title = slide.Title,
                    Image = fileName,
                    Link = slide.Link,
                    Order = slide.Order
                });
                TempData["message"] = string.Format("{0} has been saved", slide.Title);
                return RedirectToAction("Index");
            }
            else
            {
                return View(slide);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Slide());
        }

        [HttpPost]
        public ActionResult Delete(int slideId)
        {
            Slide slide = repository.Sliders.FirstOrDefault(s => s.SlideID == slideId);
            if (slide != null)
            {
                repository.DeleteSlide(slide);
                TempData["message"] = string.Format("{0} was deleted", slide.Title);
            }
            return RedirectToAction("Index");
        }
    }
}
