using System;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace IvanovBand.WebUI.HtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Image(this HtmlHelper helper,
                                string url,
                                string altText,
                                object htmlAttributes)
        {
            TagBuilder builder = new TagBuilder("img");
            builder.Attributes.Add("src", url);
            builder.Attributes.Add("alt", altText);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString AbsoluteImagePath(this HtmlHelper helper, string ImagePath, string ImageName)
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0}://{1}{2}{3}",
                HttpContext.Current.Request.Url.Scheme,
                HttpContext.Current.Request.Url.Host,
                ImagePath,
                ImageName
            );
            return MvcHtmlString.Create(result.ToString());
        }

        public static string ActiveTab(this HtmlHelper helper, string activeController, string[] activeActions, string cssClass)
        {
            string currentAction = helper.ViewContext.Controller.
                    ValueProvider.GetValue("action").RawValue.ToString();
            string currentController = helper.ViewContext.Controller.
                    ValueProvider.GetValue("controller").RawValue.ToString();

            string cssClassToUse = currentController == activeController
                 && activeActions.Contains(currentAction)
                                       ? cssClass
                                       : string.Empty;
            return cssClassToUse;
        }
    }
}