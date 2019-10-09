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
    public class ArticleController : Controller
    {
        public int PageSize = 10;
        private IArticlesRepository repository;

        public ArticleController(IArticlesRepository articlesRepository)
        {
            repository = articlesRepository;
        }

        public ViewResult List(int page = 1)
        {
            ArticlesListViewModel viewModel = new ArticlesListViewModel
            {
                Articles = repository.Articles
                    .OrderByDescending(a => a.Date)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Articles.Count()
                },
            };
            return View(viewModel);
        }

        public PartialViewResult MainList()
        {
            return PartialView(repository.Articles.OrderByDescending(a => a.Date).Take(3));
        }

        public PartialViewResult MoreList(int id)
        {
            return PartialView(repository.Articles
                .Where(a => a.ArticleID != id)
                .OrderByDescending(a => a.Date)
                .Take(3));
        }

        public ActionResult Details(int? id, string seoName)
        {
            Article article = repository.Articles
                .FirstOrDefault(a => a.ArticleID == id);

            if (seoName != FriendlyUrlHelpers.GetSeoName(article.Title))
            {
                return RedirectToActionPermanent("Details",
                    new { id = id, seoName = FriendlyUrlHelpers.GetSeoName(article.Title) }
                );
            }
            return View(article);
        }

    }
}
