using System;
using System.Linq;
using IvanovBand.Domain.Entities;

namespace IvanovBand.Domain.Abstract
{
    public interface IMemberRepository
    {
        IQueryable<Member> Members { get; }
        void SaveMember(Member member);
        void DeleteMember(Member member);
    }
}
