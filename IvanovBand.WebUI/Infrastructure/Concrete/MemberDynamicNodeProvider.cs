using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcSiteMapProvider;
using IvanovBand.Domain.Concrete;
using IvanovBand.WebUI.HtmlHelpers;

namespace IvanovBand.WebUI.Infrastructure.Concrete
{
    public class MemberDynamicNodeProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            using (var db = new EFDbContext())
            {
                foreach (var item in db.Members.ToList())
                {
                    DynamicNode dynamicNode = new DynamicNode();
                    dynamicNode.Title = item.Name;
                    dynamicNode.Key = "member_" + item.MemberID.ToString();
                    dynamicNode.RouteValues.Add("id", item.MemberID);
                    dynamicNode.RouteValues.Add("seoname", FriendlyUrlHelpers.GetSeoName(item.Name));

                    yield return dynamicNode;
                }
            }
        }
    }
}