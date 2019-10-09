using System;
using System.Linq;
using IvanovBand.Domain.Entities;

namespace IvanovBand.Domain.Abstract
{
    public interface ISongRepository
    {
        IQueryable<Song> Songs { get; }
        void SaveSong(Song song);
        void DeleteSong(Song song);
    }
}
