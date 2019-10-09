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
    public class VideoController : Controller
    {
        public int PageSize = 10;
        private IVideoRepository repository;

        public VideoController(IVideoRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(int page = 1)
        {
            VideosListViewModel viewModel = new VideosListViewModel
            {
                Videos = repository.Videos
                    .OrderBy(v => v.VideoID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Videos.Count()
                },
            };
            return View(viewModel);
        }

        public ViewResult Edit(int videoId)
        {
            Video video = repository.Videos.FirstOrDefault(v => v.VideoID == videoId);
            return View(video);
        }

        [HttpPost]
        public ActionResult Edit(Video video, HttpPostedFileBase imgFile, HttpPostedFileBase videoFile)
        {
            if (ModelState.IsValid)
            {
                var fileImgName = video.Image;
                if (imgFile != null && imgFile.ContentLength > 0)
                {
                    fileImgName = Path.GetFileName(imgFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Uploads/Images"), fileImgName);
                    imgFile.SaveAs(path);
                }

                var fileVideoName = video.File;
                if (videoFile != null && videoFile.ContentLength > 0)
                {
                    fileVideoName = Path.GetFileName(videoFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Uploads/Video"), fileVideoName);
                    videoFile.SaveAs(path);
                }

                repository.SaveVideo(new Video()
                {
                    VideoID = video.VideoID,
                    Title = video.Title,
                    Date = video.Date,
                    Image = fileImgName,
                    File = fileVideoName,
                    Content = video.Content
                });
                TempData["message"] = string.Format("{0} has been saved", video.Title);
                return RedirectToAction("Index");
            }
            else
            {
                return View(video);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Video());
        }

        [HttpPost]
        public ActionResult Delete(int videoId)
        {
            Video video = repository.Videos.FirstOrDefault(v => v.VideoID == videoId);
            if (video != null)
            {
                repository.DeleteVideo(video);
                TempData["message"] = string.Format("{0} was deleted", video.Title);
            }
            return RedirectToAction("Index");
        }
    }
}
