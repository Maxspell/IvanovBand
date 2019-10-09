using System.Data;
using System.Linq;
using IvanovBand.Domain.Abstract;
using IvanovBand.Domain.Entities;

namespace IvanovBand.Domain.Concrete
{
    public class EFFeedbackRepository : IFeedbackRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Feedback> Feedbacks
        {
            get { return context.Feedbacks; }
        }

        public void SaveFeedback(Feedback feedback)
        {
            if (feedback.FeedbackID == 0)
            {
                context.Feedbacks.Add(feedback);
            }
            else
            {
                context.Entry(feedback).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeleteFeedback(Feedback feedback)
        {
            context.Feedbacks.Remove(feedback);
            context.SaveChanges();
        }
    }
}
