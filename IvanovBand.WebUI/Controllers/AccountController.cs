using System.Web.Mvc;
using IvanovBand.WebUI.Infrastructure.Abstract;
using IvanovBand.WebUI.Models;

namespace IvanovBand.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;

        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        public ViewResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Article", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Некорректный логин или пароль");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}
