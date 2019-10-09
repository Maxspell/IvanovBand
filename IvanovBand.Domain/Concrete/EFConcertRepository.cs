using System.Data;
using System.Linq;
using IvanovBand.Domain.Abstract;
using IvanovBand.Domain.Entities;


namespace IvanovBand.Domain.Concrete
{
    public class EFConcertRepository : IConcertRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Concert> Concerts
        {
            get { return context.Concerts; }
        }

        public void SaveConcert(Concert concert)
        {
            if (concert.ConcertId == 0)
            {
                context.Concerts.Add(concert);
            }
            else
            {
                context.Entry(concert).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeleteConcert(Concert concert)
        {
            context.Concerts.Remove(concert);
            context.SaveChanges();
        }
    }
}
