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
            var model = _context.SprintTasks.Where(x => x.willBeInNextSprint == true).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(SprintPlanVM model)
        {
            return View();
        }
    }
}