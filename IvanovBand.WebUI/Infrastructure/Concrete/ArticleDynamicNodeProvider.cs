using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcSiteMapProvider;
using IvanovBand.Domain.Concrete;
using IvanovBand.WebUI.HtmlHelpers;

namespace IvanovBand.WebUI.Infrastructure.Concrete
{
    public class ArticleDynamicNodeProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            using (var db = new EFDbContext())
            {
                foreach (var item in db.Articles.ToList())
                {
                    DynamicNode dynamicNode = new DynamicNode();
                    dynamicNode.Title = item.Title;
                    dynamicNode.Key = "article_" + item.ArticleID.ToString();
                    dynamicNode.RouteValues.Add("id", item.ArticleID);
                    dynamicNode.RouteValues.Add("seoname", FriendlyUrlHelpers.GetSeoName(item.Title));

                    yield return dynamicNode;
                }
            }
        }
    }
}