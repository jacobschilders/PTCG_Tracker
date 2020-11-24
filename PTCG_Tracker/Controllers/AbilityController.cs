using PTCG_Tracker.Models.Ability;
using PTCG_Tracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTCG_Tracker.Controllers
{
    public class AbilityController : Controller
    {
        // GET: Ability
        public ActionResult Index()
        {
            var service = new AbilityService();
            var model = service.GetAllAbilities();

            return View(model);
        }

        // GET: AbilityCreate
        public ActionResult Create()
        {
            return View();
        }

        //POST: AbilityCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AbilityCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAbilityService();

            if (service.CreateAbility(model))
            {
                TempData["SaveResult"] = "Your Ability was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Ability could not be created.");

            return View(model);
        }

        //GET: AbilityDetails
        public ActionResult Details(int id)
        {
            var service = CreateAbilityService();
            var model = service.GetAbilityById(id);

            return View(model);
        }

        //Edit: AbilityEdit
        public ActionResult Edit(int id)
        {
            var service = CreateAbilityService();
            var detail = service.GetAbilityById(id);
            var model =
                new AbilityEdit
                {
                    Name = detail.Name,
                    Text = detail.Text,
                    Type = detail.Type
                };
            return View(model);
        }

        //PUT: AbilityEdit/ {id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AbilityEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AbilityId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAbilityService();

            if (service.UpdateAbility(model))
            {
                TempData["SaveResult"] = "Your Ability was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Ability could not be updated.");
            return View(model);
        }

        //GET: Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateAbilityService();
            var model = service.GetAbilityById(id);

            return View(model);
        }

        //POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAttack(int id)
        {
            var service = CreateAbilityService();

            service.DeleteAbility(id);

            TempData["SaveResult"] = "Your Ability was deleted";

            return RedirectToAction("Index");
        }

        //Service READONLY
        private AbilityService CreateAbilityService()
        {
            var service = new AbilityService();
            return service;
        }
    }
}