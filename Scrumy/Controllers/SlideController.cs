using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scrumy.Data;
using Scrumy.Models;
using Scrumy.Models.SlidesViewModel;

namespace Scrumy.Controllers
{
    public class SlideController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SlideController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Slide
        public ActionResult Index()
        {
            var st = _context.Slides.ToList();
            return View(st);
        }

        // GET: Slide/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Slide/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Slide/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SlideAddVM slide)
        {
            try
            {
                // TODO: Add insert logic here
                var newSlide = new Slide { Number = slide.Number, Content = slide.Content };
                if (ModelState.IsValid)
                {
                    _context.Add(newSlide);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Slide/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Slide/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Slide/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Slide/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}