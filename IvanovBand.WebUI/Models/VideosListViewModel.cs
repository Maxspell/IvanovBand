using System;
using System.Collections.Generic;
using IvanovBand.Domain.Entities;

namespace IvanovBand.WebUI.Models
{
    public class VideosListViewModel
    {
        public IEnumerable<Video> Videos { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}