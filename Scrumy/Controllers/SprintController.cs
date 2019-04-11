﻿using System;
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

        public ActionResult Discuss()
        {
            //task list z repo
            var discuss = _context.SprintTasks.Where(x => x.willBeInNextSprint == true).ToList();
            var tosprint = _context.SprintTasks.Where(x => x.isInCurrentSprint == true).ToList();

            var tasks = discuss.Concat(tosprint);

            var model = new SprintPlanVM
            {
                TasksToDiscuss = tasks.ToList()
            };

            return View(model);
        }

        public ActionResult GenerateSprint(SprintPlanVM model)
        {
            model.TasksToDiscuss = _context.SprintTasks.Where(x => x.isInCurrentSprint == true).ToList();

            var newSprint = new Sprint {
                Deadline = model.SprintToCreate.Deadline,
                SprintTarget = model.SprintToCreate.SprintTarget
            };


            foreach (var item in model.TasksToDiscuss)
            {
                item.SprintId = newSprint.Id;
            }

            _context.Add(newSprint);
            _context.SaveChanges();

            return RedirectToAction("AgileWall", "SprintTask");
        }

        public ActionResult WillNotBeInSprint(Guid id)
        {
            var st = _context.SprintTasks.Find(id);

            st.isInCurrentSprint = false;
            st.willBeInNextSprint = true;

            _context.SprintTasks.Update(st);
            _context.SaveChanges();
            return RedirectToAction(nameof(Discuss));
        }

        public ActionResult SetAsToDoInCurrentSprint(Guid id)
        {
            var st = _context.SprintTasks.Find(id);

            st.isInCurrentSprint = true;
            st.willBeInNextSprint = false;

            _context.SprintTasks.Update(st);
            _context.SaveChanges();
            return RedirectToAction(nameof(Discuss));
        }

        public ActionResult SprintStats()
        {
            var model = new SprintStatsVM
            {
                Sprints = _context.Sprints.ToList(),
                Tasks = _context.SprintTasks.ToList()
            };

            return View(model);
        }
    }
}