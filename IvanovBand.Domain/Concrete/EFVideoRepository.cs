using System.Data;
using System.Linq;
using IvanovBand.Domain.Abstract;
using IvanovBand.Domain.Entities;

namespace IvanovBand.Domain.Concrete
{
    public class EFVideoRepository : IVideoRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Video> Videos
        {
            get { return context.Videos; }
        }

        public void SaveVideo(Video video)
        {
            if (video.VideoID == 0)
            {
                context.Videos.Add(video);
            }
            else
            {
                context.Entry(video).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeleteVideo(Video video)
        {
            context.Videos.Remove(video);
            context.SaveChanges();
        }
    }
}
