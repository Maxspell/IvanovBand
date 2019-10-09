using System.Web.Mvc;

namespace IvanovBand.WebUI.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                null,
                "Admin/{controller}/page-{page}",
                new { controller = "Article", action = "Index", category = (string)null },
                new { page = @"\d+" } // Ограничения: страница должна быть числовой
                );
            context.MapRoute(
                null,
                "Admin/{controller}/{action}",
                new { controller = "Home", action = "Index" }
            );
        }
    }
}
