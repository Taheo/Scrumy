using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scrumy.Data;
using Scrumy.Models;
using Scrumy.Models.MixedVM;
using Scrumy.Models.ProjectSettingsVM;

namespace Scrumy.Controllers
{
    public class ProjectSettingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProjectSettingsController(ApplicationDbContext context)
        {
            _context = context;
        }
            
        public ActionResult RenderErrorIfSettingsAreEmpty()
        {
            var model = new ProjectSettingsAddVM();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectSettingsAddVM model)
        {
            try
            {

                var newProjectSettings = new ProjectSettings
                {
                    EstimatedSPsum = model.EstimatedSPsum,
                    EstimatedTeamSpeed = model.EstimatedTeamSpeed,
                    SprintAmount = model.SprintAmount,
                    SprintLength = model.SprintLength
                };
                
                if (ModelState.IsValid)
                {
                    _context.Add(newProjectSettings);
                    _context.SaveChanges();
                }

                return RedirectToAction("Dashboard", "Account");
            }
            catch
            {
                return View();
            }
        }
    }
}