using System;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace IvanovBand.WebUI.HtmlHelpers
{
    public static class ActiveActionLinkHelpers
    {
        public static MvcHtmlString MenuActionLink(this HtmlHelper helper,
            string linkText, string actionName, string controlName)
        {
            if (helper.ViewContext.RouteData.Values["action"].ToString() == actionName &&
                helper.ViewContext.RouteData.Values["controller"].ToString() == controlName)
                  return helper.ActionLink(linkText, actionName, controlName, new { @class = "selected" });

            return helper.ActionLink(linkText, actionName, controlName);
        }
    }
}