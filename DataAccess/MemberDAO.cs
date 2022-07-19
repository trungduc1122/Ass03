using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        public static MemberDAO Instance
        {
            get {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                }
                return instance;
            }
        }

        public Member GetMemberByEmail(string email)
        {
            Member member = null;
            using var db = new FStoreDBAssignmentContext();
            member=db.Member.SingleOrDefault(x => x.Email == email);
            return member;
        }
        public Member CheckLogin(string email,string password)
        {
            Member member = null;
            using var db = new FStoreDBAssignmentContext();
            member =(Member)db.Member.Where(x => x.Email == email && x.Password == password);
            return member;
        }
        public Member GetMemberById(int id)
        {
            Member member = null;
            using var db = new FStoreDBAssignmentContext();
            member = db.Member.SingleOrDefault(x => x.MemberId == id);
            return member;
        }

        public List<Member> GetMembers()
        {
            List<Member> list = null;
            using var db = new FStoreDBAssignmentContext();
            list = db.Member.ToList<Member>();
            return list;
        }

        public void AddMember(Member member)
        {
            Member mem = GetMemberByEmail(member.Email);
            if (mem == null) { 
            using var db = new FStoreDBAssignmentContext();
            db.Member.Add(member);
            db.SaveChanges();
            }
            else
            {
                throw new Exception("member already exsit");
            }
        }

        public void DeleteMember(Member member)
        {
            Member mem = GetMemberByEmail(member.Email);
            if (mem != null)
            {
                using var db = new FStoreDBAssignmentContext();
                db.Member.Remove(member);
                db.SaveChanges();
            }
        }
        public void UpdateMember(Member member)
        {
            Member mem = GetMemberByEmail(member.Email);
            if (mem != null)
            {
                using var db = new FStoreDBAssignmentContext();
                db.Member.Update(member);
                db.SaveChanges();
            }
        }

    }
}
