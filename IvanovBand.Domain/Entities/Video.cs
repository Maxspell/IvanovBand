using System;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IvanovBand.Domain.Entities
{
    public class Video
    {
        public Video()
        {
            Date = DateTime.Now;
        }

        [HiddenInput(DisplayValue = false)]
        public int VideoID { get; set; }

        public string Title { get; set; }

        [DisplayName("Дата")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Image { get; set; }
        public string File { get; set; }
        [AllowHtml]
        public string Content { get; set; }
    }
}
