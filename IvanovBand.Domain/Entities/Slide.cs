using System;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IvanovBand.Domain.Entities
{
    public class Slide
    {
        [HiddenInput(DisplayValue = false)]
        public int SlideID { get; set; }

        public string Title { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public int Order { get; set; }
    }
}
