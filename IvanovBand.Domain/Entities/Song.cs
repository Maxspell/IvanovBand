using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IvanovBand.Domain.Entities
{
    public class Song
    {
        [HiddenInput(DisplayValue = false)]
        public int SongID { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public int Order { get; set; }
    }
}
