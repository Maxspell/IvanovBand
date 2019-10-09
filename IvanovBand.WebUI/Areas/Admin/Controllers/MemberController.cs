using System.Web;
using System.Linq;
using System.Web.Mvc;
using IvanovBand.Domain.Abstract;
using IvanovBand.Domain.Entities;
using IvanovBand.WebUI.Models;
using System.Collections.Generic;
using System.IO;

namespace IvanovBand.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        public int PageSize = 10;
        private IMemberRepository repository;

        public MemberController(IMemberRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Members.OrderBy(m => m.MemberID));
        }

        public ViewResult Edit(int memberId)
        {
            return View(repository.Members.FirstOrDefault(m => m.MemberID == memberId));
        }

        [HttpPost]
        public ActionResult Edit(Member member, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var fileName = member.Image;
                if (file != null && file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Uploads/Images"), fileName);
                    file.SaveAs(path);
                }
                repository.SaveMember(new Member()
                {
                    MemberID = member.MemberID,
                    Name = member.Name,
                    Image = fileName,
                    Instrument = member.Instrument,
                    Description = member.Description,
                    Text = member.Text
                });
                TempData["message"] = string.Format("{0} has been saved", member.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(member);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Member());
        }

        [HttpPost]
        public ActionResult Delete(int memberId)
        {
            Member member = repository.Members.FirstOrDefault(m => m.MemberID == memberId);
            if (member != null)
            {
                repository.DeleteMember(member);
                TempData["message"] = string.Format("{0} was deleted", member.Name);
            }
            return RedirectToAction("Index");
        }
    }
}
