using System;
using System.Linq;
using IvanovBand.Domain.Entities;

namespace IvanovBand.Domain.Abstract
{
    public interface IFeedbackRepository
    {
        IQueryable<Feedback> Feedbacks { get; }
        void SaveFeedback(Feedback feedback);
        void DeleteFeedback(Feedback feedback);
    }
}
