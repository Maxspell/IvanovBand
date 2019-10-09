using System;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IvanovBand.Domain.Entities
{
    public class Article
    {
        public Article()
        {
            Date = DateTime.Now;
        }

        [HiddenInput(DisplayValue = false)]
        public int ArticleID { get; set; }

        [DisplayName("Дата")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DisplayName("Заголовок")]
        [Required(ErrorMessage = "Please enter a article title")]
        public string Title { get; set; }

        [DisplayName("Анонс")]
        [Required(ErrorMessage = "Please enter a article Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("Текст")]
        [AllowHtml]
        [Required(ErrorMessage = "Please enter a article text")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImagePath { get; set; }

        [DisplayName("Категория")]
        [Required(ErrorMessage = "Please enter a article Category")]
        public string Category { get; set; }
    }
}
