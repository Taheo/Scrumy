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

                return RedirectToAction("ScrumDocEXT", "Account");
            }
            catch
            {
                return View();
            }
        }

        // GET: Slide/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: Slide/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slide model)
        {
            try
            {
                _context.Slides.Update(model);
                _context.SaveChanges();

                return RedirectToAction("ScrumDocEXT", "Account");
            }
            catch
            {
                return View();
            }
        }

        //[HttpGet] // this action result returns the partial containing the modal
        //public ActionResult EditSlide(Guid id)
        //{
        //    var viewModel = new SlideEditVM
        //    {
        //        Id = id
        //    };
        //    return PartialView("_editSlide", viewModel);
        //}

        //[HttpPost] // this action takes the viewModel from the modal
        //public ActionResult EditSlide(SlideEditVM viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var toUpdate = _context.Slides.Find(viewModel.Id);
        //        toUpdate.Content = viewModel.Content;
        //        toUpdate.Number = viewModel.Number;
        //        _context.Slides.Update(toUpdate);
        //        _context.SaveChanges();
        //        return View("Index");
        //    }
        //    return RedirectToAction(nameof(AccountController.ScrumDoc));
        //}

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
                //only for tests
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