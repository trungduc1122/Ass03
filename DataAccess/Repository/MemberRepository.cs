using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {

       public void AddMember(Member member)=>MemberDAO.Instance.AddMember(member);

        public void DeleteMember(Member member)=>MemberDAO.Instance.DeleteMember(member);

        public Member GetMemberById(int id) => MemberDAO.Instance.GetMemberById(id);

        public List<Member> GetMembers() => MemberDAO.Instance.GetMembers();

        public void UpdateMember(Member member)=>MemberDAO.Instance.UpdateMember(member);   
    }
}
