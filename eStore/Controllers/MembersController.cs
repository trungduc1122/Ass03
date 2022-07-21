using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Repository;
using BusinessObject;

namespace eStore.Controllers
{
    public class MembersController : Controller
    {
        IMemberRepository memberRepository = null;
        public MembersController() => memberRepository = new MemberRepository();
        // GET: MembersController
        public ActionResult Index()
        {
            var list = memberRepository.GetMembers();
            return View(list);
        }

        // GET: MembersController/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }var member = memberRepository.GetMemberById(id.Value);
            return View(member);
        }

        // GET: MembersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MembersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    memberRepository.AddMember(member);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(member);
            }
        }

        // GET: MembersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MembersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Member member)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    memberRepository.UpdateMember(member);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(member);
            }
        }

        // GET: MembersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MembersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Member member)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    memberRepository.AddMember(member);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(member);
            }
        }
        //HomeController/Index
        public ActionResult Home()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
