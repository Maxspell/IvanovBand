using System;
using System.Collections.Generic;
using IvanovBand.Domain.Entities;

namespace IvanovBand.WebUI.Models
{
    public class ArticlesListViewModel
    {
        public IEnumerable<Article> Articles { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}