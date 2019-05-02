﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scrumy.Data;
using Scrumy.Models;
using Scrumy.Models.MixedVM;
using Scrumy.Models.SprintTaskViewModel;
using Scrumy.Services;

namespace Scrumy.Controllers
{
    public class SprintTaskController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISprintTaskService _sprintTaskService;

        public SprintTaskController(ApplicationDbContext context, ISprintTaskService sprintTaskService)
        {
            _context = context;
            _sprintTaskService = sprintTaskService;
        }
        // GET: SprintTask
        public ActionResult Index()
        {
            var st = _context.SprintTasks.ToList();
            return View(st);
        }

        public ActionResult AgileWall()
        {
            ClearToDoInCurrentSprintIfSprintNotExist();
            
            var model = new AgileWallVM
            {
                TaskList = _sprintTaskService.GetAll(),
                TaskToCreate = new SprintTaskAddVM()
            };

            return View(model);
        }

        public void ClearToDoInCurrentSprintIfSprintNotExist()
        {
            var tasks = _context.SprintTasks.Where(
                x => x.isInCurrentSprint == true && 
                x.SprintId.ToString().Equals("00000000-0000-0000-0000-000000000000")).ToList();

            foreach (var item in tasks)
            {
                item.isInCurrentSprint = false;
                item.willBeInNextSprint = true;
                _context.SprintTasks.Update(item);
            }
            _context.SaveChanges();
        }

        public ActionResult Stats()
        {
            return View();
        }

        public ActionResult Archive()
        {
            return View();
        }
        // GET: SprintTask/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SprintTask/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SprintTask/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SprintTaskAddVM model)
        {
            try
            {

                var newTask = new SprintTask {Title = model.Title, Desc = model.Desc };
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _context.Add(newTask);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(AgileWall));
            }
            catch
            {
                return View();
            }
        }

        // GET: SprintTask/Delete/5
        public ActionResult Delete(Guid id)
        {
            var st = _context.SprintTasks.Find(id);
            _context.SprintTasks.Remove(st);
            _context.SaveChanges();
            return RedirectToAction(nameof(AgileWall));
           
        }

        // POST: SprintTask/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(Guid id)
        //{
        //    try
        //    {
        //        var st = _context.SprintTasks.Find(id); ;
        //        _context.SprintTasks.Remove(st);
        //        _context.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public ActionResult MoveAsToDoInNextSprint(Guid id)
        {
            var st = _context.SprintTasks.Find(id);

            st.isDone = false;
            st.isInBacklog = false;
            st.isInCurrentSprint = false;
            st.willBeInNextSprint = true;

            _context.SprintTasks.Update(st);
            _context.SaveChanges();

            return RedirectToAction(nameof(AgileWall));
        }

        public ActionResult BackToBacklog(Guid id)
        {
            var st = _context.SprintTasks.Find(id);

            st.isDone = false;
            st.isInBacklog = true;
            st.isInCurrentSprint = false;
            st.willBeInNextSprint = false;

            _context.SprintTasks.Update(st);
            _context.SaveChanges();

            return RedirectToAction(nameof(AgileWall));
        }

        //public ActionResult ToDoInCurrentSprint(Guid id)
        //{
        //    var st = _context.SprintTasks.Find(id);

        //    st.isDone = false;
        //    st.isInCurrentSprint = true;
        //    st.willBeInNextSprint = false;

        //    _context.SprintTasks.Update(st);
        //    _context.SaveChanges();

        //    return RedirectToAction("Create", "SprintController", new { area = "" });
        //}

        public ActionResult SetAsDone(Guid id)
        {
            var st = _context.SprintTasks.Find(id);

            st.isDone = true;
            st.isInCurrentSprint = false;
            st.willBeInNextSprint = false;
            st.isInBacklog = false;

            _context.SprintTasks.Update(st);
            _context.SaveChanges();
            return RedirectToAction(nameof(AgileWall));
        }

        public ActionResult SetAsCurrentlyWorkingOn(Guid id)
        {
            var st = _context.SprintTasks.Find(id);
            st.whoIsWorkingOn = User.Identity.Name.ToString();

            return RedirectToAction(nameof(AgileWall));
        }

        [HttpPost]
        public ActionResult AddStoryPointValue(SprintTask model)
        {
            var st = _context.SprintTasks.Find(model.Id);

            st.StoryPointsValue = model.StoryPointsValue;

            _context.SprintTasks.Update(st);
            _context.SaveChanges();

            return RedirectToAction("Discuss", "Sprint");
        }
    }
}