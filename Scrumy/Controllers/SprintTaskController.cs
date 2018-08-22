using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scrumy.Data;
using Scrumy.Models;
using Scrumy.Models.SprintTaskViewModel;

namespace Scrumy.Controllers
{
    public class SprintTaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SprintTaskController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: SprintTask
        public ActionResult Index()
        {
            var st = _context.SprintTasks.ToList();
            return View(st);
        }

        public ActionResult AgileWall()
        {
            var st = _context.SprintTasks.ToList();
            return View(st);
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
                //var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var newTask = new SprintTask {Title = model.Title, Desc = model.Desc };
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _context.Add(newTask);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SprintTask/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: SprintTask/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SprintTask model)
        {
            try
            {
                _context.SprintTasks.Update(model);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
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
            return RedirectToAction(nameof(Index));
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
    }
}