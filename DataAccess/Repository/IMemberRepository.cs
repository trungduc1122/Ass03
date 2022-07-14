using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        public List<Member> GetMembers();
        public void AddMember(Member member);
        public void UpdateMember(Member member);
        public void DeleteMember(Member member);
        
        public Member GetMemberById(int id);

    }
}
