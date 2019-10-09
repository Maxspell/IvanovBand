using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcSiteMapProvider;
using IvanovBand.Domain.Concrete;
using IvanovBand.WebUI.HtmlHelpers;

namespace IvanovBand.WebUI.Infrastructure.Concrete
{
    public class VideoDynamicNodeProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            using (var db = new EFDbContext())
            {
                foreach (var item in db.Videos.ToList())
                {
                    DynamicNode dynamicNode = new DynamicNode();
                    dynamicNode.Title = item.Title;
                    dynamicNode.Key = "video_" + item.VideoID.ToString();
                    dynamicNode.RouteValues.Add("id", item.VideoID);
                    dynamicNode.RouteValues.Add("seoname", FriendlyUrlHelpers.GetSeoName(item.Title));

                    yield return dynamicNode;
                }
            }
        }
    }
}