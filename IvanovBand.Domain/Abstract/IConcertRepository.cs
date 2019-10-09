using System;
using System.Collections.Generic;
using System.Linq;
using IvanovBand.Domain.Entities;

namespace IvanovBand.Domain.Abstract
{
    public interface IConcertRepository
    {
        IQueryable<Concert> Concerts { get; }
        void SaveConcert(Concert concert);
        void DeleteConcert(Concert concert);
    }
}
