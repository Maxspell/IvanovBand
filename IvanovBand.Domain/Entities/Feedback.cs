using System;

namespace IvanovBand.Domain.Entities
{
    public class Feedback
    {
        public Feedback()
        {
            Date = DateTime.Now;
        }

        public int FeedbackID { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Message { get; set; }
    }
}
