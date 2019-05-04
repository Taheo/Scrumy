using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Scrumy.Data;
using Scrumy.Models;
using Scrumy.Models.MixedVM;
using Scrumy.Models.RetroVM;
using Scrumy.Models.SprintVM;
using Scrumy.Services;

namespace Scrumy.Controllers
{
    public class SprintController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISprintTaskService _sprintTaskService;
        private readonly ISprintService _sprintService;

        public SprintController(
            ApplicationDbContext context, 
            ISprintTaskService sprintTaskService, 
            ISprintService sprintService)
        {
            _context = context;
            _sprintTaskService = sprintTaskService;
            _sprintService = sprintService;
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

        public void CheckIfSprintIsDone()
        {
            var currentSprint = _sprintService.GetCurrentSprint();
            var currentSprintTasks = _sprintTaskService.GetAll().Where(x => x.SprintId == currentSprint.Id);
           
            if (currentSprintTasks.All(z => z.isDone == true) == true)
            {
                currentSprint.isDone = true;

                _context.Sprints.Update(currentSprint);
                _context.SaveChanges();
            }
            //jeszcze nie wywoływane
        }

        public ActionResult Retro()
        {
            var sprintList = _sprintService.GetDoneSprints();
            var ListItemsFromSprints = new List<SelectListItem>();

            foreach (var item in sprintList)
            {
                ListItemsFromSprints.Add(new SelectListItem { Text = item.SprintTarget, Value = item.Id.ToString() });
            }

            var model = new RetroVM {
                Feedback = _context.Opinions.ToList(),
                OpinionToAdd = new OpinionAddVM() {
                    Sprints = ListItemsFromSprints
                },
                Sprints = _sprintService.GetDoneSprints(),
                Tasks = _sprintTaskService.GetDoneTasks(),
            };

            return View(model);
        }

        public ActionResult CreateOpinion(OpinionAddVM model)
        {
            var newOpinion = new Opinion(User.Identity.Name)
            {
                Comment = model.Comment,
                OpinionType = model.OpinionType,
                SprintId = model.SprintId
            };

            _context.Add(newOpinion);
            _context.SaveChanges();

            return RedirectToAction(nameof(Retro));
        }

        public ActionResult Archive()
        {
            return View();
        }
    }
}