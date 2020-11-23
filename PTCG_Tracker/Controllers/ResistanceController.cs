using PTCG_Tracker.Models.Resistance;
using PTCG_Tracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTCG_Tracker.Controllers
{
    public class ResistanceController : Controller
    {
        // GET: Resistance
        public ActionResult Index()
        {
            var service = new ResistanceService();
            var model = service.GetAllResistances();

            return View(model);
        }

        // GET: ResistanceCreate
        public ActionResult Create()
        {
            return View();
        }

        //POST: ResistanceCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResistanceCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateResistanceService();

            if (service.CreateResistance(model))
            {
                TempData["SaveResult"] = "Your Resistance was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Resistance could not be created.");

            return View(model);
        }

        //GET: ResistanceDetails
        public ActionResult Details(int id)
        {
            var service = CreateResistanceService();
            var model = service.GetResistanceById(id);

            return View(model);
        }

        //Edit: ResistanceEdit
        public ActionResult Edit(int id)
        {
            var service = CreateResistanceService();
            var detail = service.GetResistanceById(id);
            var model =
                new ResistanceEdit
                {
                    Type = detail.Type,
                    Value = detail.Value
                };
            return View(model);
        }

        //PUT: ResistanceEdit / {id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ResistanceEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateResistanceService();

            if (service.UpdateResistance(model))
            {
                TempData["SaveResult"] = "Your Resistance was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Resistance could not be updated.");
            return View(model);
        }

        //GET: Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateResistanceService();
            var model = service.GetResistanceById(id);

            return View(model);
        }

        //POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAttack(int id)
        {
            var service = CreateResistanceService();

            service.DeleteResistance(id);

            TempData["SaveResult"] = "Your Resistance was deleted";

            return RedirectToAction("Index");
        }

        //Service READONLY
        private ResistanceService CreateResistanceService()
        {
            var service = new ResistanceService();
            return service;
        }
    }
}