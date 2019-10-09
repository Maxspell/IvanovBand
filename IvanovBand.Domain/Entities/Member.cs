using System;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IvanovBand.Domain.Entities
{
    public class Member
    {
        [HiddenInput(DisplayValue = false)]
        public int MemberID { get; set; }

        [DisplayName("Имя")]
        public string Name { get; set; }

        [DisplayName("Изображение")]
        public string Image { get; set; }

        [DisplayName("Анонс")]
        [AllowHtml]
        public string Description { get; set; }

        [DisplayName("Текст")]
        [AllowHtml]
        public string Text { get; set; }

        [DisplayName("Инструмент")]
        public string Instrument { get; set; }
    }
}
