using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IvanovBand.Domain.Entities;

namespace IvanovBand.Domain.Abstract
{
    public interface IVideoRepository
    {
        IQueryable<Video> Videos { get; }
        void SaveVideo(Video video);
        void DeleteVideo(Video video);
    }
}
