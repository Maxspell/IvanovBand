using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IvanovBand.Domain.Entities
{
    public class Concert
    {
        [HiddenInput(DisplayValue = false)]
        public int ConcertId { get; set; }

        
        private DateTime _date = DateTime.Now;
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        [DisplayName("Контент")]
        public string Content { get; set; }
    }
}
