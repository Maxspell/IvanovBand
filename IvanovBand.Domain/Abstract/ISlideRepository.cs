using System;
using System.Linq;
using IvanovBand.Domain.Entities;

namespace IvanovBand.Domain.Abstract
{
    public interface ISlideRepository
    {
        IQueryable<Slide> Sliders { get; }
        void SaveSlide(Slide slide);
        void DeleteSlide(Slide slide);
    }
}
