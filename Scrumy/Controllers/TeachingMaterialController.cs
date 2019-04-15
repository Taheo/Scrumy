using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scrumy.Data;
using Scrumy.Models;
using Scrumy.Models.TeachingMaterialsVM;

namespace Scrumy.Controllers
{
    public class TeachingMaterialController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeachingMaterialController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TeachingMaterial
        public ActionResult Index()
        {
            var st = _context.TeachingMaterials.ToList();
            return View(st);
        }

        // GET: TeachingMaterial/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TeachingMaterial/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeachingMaterial/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeachingMaterialAddVM model)
        {
            try
            {
                // TODO: Add insert logic here
                var newMaterial = new TeachingMaterial { Link = model.Link, Note = model.Note };
                if (ModelState.IsValid)
                {
                    _context.Add(newMaterial);
                    _context.SaveChanges();
                }

                return RedirectToAction("ScrumDocEXT", "Account");
            }
            catch
            {
                return View();
            }
        }

        // GET: TeachingMaterial/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TeachingMaterial/Edit/5
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

        // GET: TeachingMaterial/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeachingMaterial/Delete/5
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