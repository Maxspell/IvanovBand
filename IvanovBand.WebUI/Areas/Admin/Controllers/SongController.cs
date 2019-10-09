using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IvanovBand.Domain.Abstract;
using IvanovBand.Domain.Entities;

namespace IvanovBand.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class SongController : Controller
    {
        private ISongRepository repository;

        public SongController(ISongRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Songs.OrderBy(s => s.SongID));
        }

        public ViewResult Edit(int songId)
        {
            return View(repository.Songs.FirstOrDefault(s => s.SongID == songId));
        }

        [HttpPost]
        public ActionResult Edit(Song song, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var fileName = song.Link;
                if (file != null && file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Uploads/Audio"), fileName);
                    file.SaveAs(path);
                }
                repository.SaveSong(new Song()
                {
                    SongID = song.SongID,
                    Title = song.Title,
                    Link = fileName,
                    Order = song.Order
                });
                TempData["message"] = string.Format("{0} has been saved", song.Title);
                return RedirectToAction("Index");
            }
            else
            {
                return View(song);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Song());
        }

        [HttpPost]
        public ActionResult Delete(int songId)
        {
            Song song = repository.Songs.FirstOrDefault(s => s.SongID == songId);
            if (song != null)
            {
                repository.DeleteSong(song);
                TempData["message"] = string.Format("{0} was deleted", song.Title);
            }
            return RedirectToAction("Index");
        }

    }
}
