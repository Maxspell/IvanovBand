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
    public class ArticleController : Controller
    {
        public int PageSize = 10;
        private IArticlesRepository repository;

        public ArticleController(IArticlesRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string category, int page = 1)
        {
            ArticlesListViewModel viewModel = new ArticlesListViewModel
            {
                Articles = repository.Articles
                    .Where(a => category == null || a.Category == category)
                    .OrderByDescending(a => a.ArticleID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                       repository.Articles.Count() :
                       repository.Articles.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(viewModel);
        }

        public ViewResult Edit(int articleId)
        {
            Article article = repository.Articles.FirstOrDefault(a => a.ArticleID == articleId);
            return View(article);
        }

        [HttpPost]
        public ActionResult Edit(Article article, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var fileName = article.ImagePath;
                if (file != null && file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Uploads/Images"), fileName);
                    file.SaveAs(path);
                }
                repository.SaveArticle(new Article()
                    {
                        ArticleID = article.ArticleID,
                        Date = article.Date,
                        Title = article.Title,
                        Description = article.Description,
                        Text = article.Text,
                        Category = article.Category,
                        ImagePath = fileName
                    });
                TempData["message"] = string.Format("{0} has been saved", article.Title);
                return RedirectToAction("Index");
            }
            else
            {
                return View(article);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Article());
        }

        [HttpPost]
        public ActionResult Delete(int articleId)
        {
            Article article = repository.Articles.FirstOrDefault(a => a.ArticleID == articleId);
            if (article != null)
            {
                repository.DeleteArticle(article);
                TempData["message"] = string.Format("{0} was deleted", article.Title);
            }
            return RedirectToAction("Index");
        }
    }
}
