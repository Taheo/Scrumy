using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scrumy.Data;
using Scrumy.Models;
using Scrumy.Models.SprintVM;

namespace Scrumy.Controllers
{
    public class SprintController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SprintController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            //task list z repo
            var discuss = _context.SprintTasks.Where(x => x.willBeInNextSprint == true).ToList();
            var tosprint = _context.SprintTasks.Where(x => x.isInCurrentSprint == true).ToList();

            var model = discuss.Concat(tosprint);

            return View(model);
        }

        //[HttpPost]
        //public ActionResult Create(SprintPlanVM model)
        //{
        //    return View();
        //}

        public ActionResult WillNotBeInSprint(Guid id)
        {
            var st = _context.SprintTasks.Find(id);

            st.isInCurrentSprint = false;
            st.willBeInNextSprint = true;

            _context.SprintTasks.Update(st);
            _context.SaveChanges();
            return RedirectToAction(nameof(Create));
        }

        public ActionResult SetAsToDoInCurrentSprint(Guid id)
        {
            var st = _context.SprintTasks.Find(id);

            st.isInCurrentSprint = true;
            st.willBeInNextSprint = false;

            _context.SprintTasks.Update(st);
            _context.SaveChanges();
            return RedirectToAction(nameof(Create));
        }
    }
}