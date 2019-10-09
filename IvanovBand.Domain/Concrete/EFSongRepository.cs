using System.Data;
using System.Linq;
using IvanovBand.Domain.Abstract;
using IvanovBand.Domain.Entities;

namespace IvanovBand.Domain.Concrete
{
    public class EFSongRepository : ISongRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Song> Songs
        {
            get { return context.Songs; }
        }

        public void SaveSong(Song song)
        {
            if (song.SongID == 0)
            {
                context.Songs.Add(song);
            }
            else
            {
                context.Entry(song).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeleteSong(Song song)
        {
            context.Songs.Remove(song);
            context.SaveChanges();
        }
    }
}
