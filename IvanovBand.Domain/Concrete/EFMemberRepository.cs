using System.Data;
using System.Linq;
using IvanovBand.Domain.Abstract;
using IvanovBand.Domain.Entities;

namespace IvanovBand.Domain.Concrete
{
    public class EFMemberRepository : IMemberRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Member> Members
        {
            get { return context.Members; }
        }

        public void SaveMember(Member member)
        {
            if (member.MemberID == 0)
            {
                context.Members.Add(member);
            }
            else
            {
                context.Entry(member).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeleteMember(Member member)
        {
            context.Members.Remove(member);
            context.SaveChanges();
        }
    }
}
