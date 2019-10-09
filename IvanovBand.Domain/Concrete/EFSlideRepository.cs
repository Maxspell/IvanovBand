using System.Data;
using System.Linq;
using IvanovBand.Domain.Abstract;
using IvanovBand.Domain.Entities;

namespace IvanovBand.Domain.Concrete
{
    public class EFSlideRepository : ISlideRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Slide> Sliders
        {
            get { return context.Sliders; }
        }

        public void SaveSlide(Slide slide)
        {
            if (slide.SlideID == 0)
            {
                context.Sliders.Add(slide);
            }
            else
            {
                context.Entry(slide).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeleteSlide(Slide slide)
        {
            context.Sliders.Remove(slide);
            context.SaveChanges();
        }
    }
}
