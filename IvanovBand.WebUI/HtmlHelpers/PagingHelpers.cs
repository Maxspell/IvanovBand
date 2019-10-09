using System;
using System.Text;
using System.Web.Mvc;
using IvanovBand.WebUI.Models;

namespace IvanovBand.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PagingInfo pagingInfo,
            Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            result.Append("<ul class=\"pager-list\">");
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                if (i == pagingInfo.CurrentPage)
                {
                    TagBuilder span = new TagBuilder("span");
                    span.InnerHtml = i.ToString();

                    TagBuilder li = new TagBuilder("li");
                    li.AddCssClass("selected");
                    li.InnerHtml = (span.ToString());
                    result.Append(li.ToString());
                }
                else
                {
                    TagBuilder a = new TagBuilder("a");
                    a.MergeAttribute("href", pageUrl(i));
                    a.InnerHtml = i.ToString();

                    TagBuilder li = new TagBuilder("li");
                    li.InnerHtml = (a.ToString());
                    result.Append(li.ToString());
                }
            }
            result.Append("</ul>");
            return MvcHtmlString.Create(result.ToString());
        }
    }
}