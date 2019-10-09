using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IvanovBand.Domain.Abstract;
using IvanovBand.WebUI.Models;

namespace IvanovBand.WebUI.Controllers
{
    public class VideoController : Controller
    {
        public int PageSize = 9;
        private IVideoRepository repository;

        public VideoController(IVideoRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int page = 1)
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

        public ViewResult Details(int? id)
        {
            return View(repository.Videos.FirstOrDefault(a => a.VideoID == id));
        }

    }
}
