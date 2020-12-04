using PTCG_Tracker.Models.Weakness;
using PTCG_Tracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTCG_Tracker.Controllers
{
    public class WeaknessController : Controller
    {
        // GET: Weakness
        public ActionResult Index()
        {
            var service = new WeaknessService();
            var model = service.GetAllWeaknesses();

            return View(model);
        }

        // GET: WeaknessCreate
        public ActionResult Create()
        {
            return View();
        }

        //POST: WeaknessCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WeaknessCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateWeaknessService();

            if (service.CreateWeakness(model))
            {
                TempData["SaveResult"] = "Your Weakness was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Weakness could not be created.");

            return View(model);
        }

        //GET: Weakness Details
        public ActionResult Details(int id)
        {
            var service = CreateWeaknessService();
            var model = service.GetWeaknessById(id);

            return View(model);
        }

        //Edit: Weakness Edit
        public ActionResult Edit(int id)
        {
            var service = CreateWeaknessService();
            var detail = service.GetWeaknessById(id);
            var model =
                new WeaknessEdit
                {
                    WeaknessId = detail.WeaknessId,
                    Type = detail.Type,
                    Value = detail.Value
                };
            return View(model);
        }

        //PUT: Weakness Edit / {id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WeaknessEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.WeaknessId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateWeaknessService();

            if (service.UpdateWeakness(model))
            {
                TempData["SaveResult"] = "Your Weakness was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Weakness could not be updated.");
            return View(model);
        }

        //GET: Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateWeaknessService();
            var model = service.GetWeaknessById(id);

            return View(model);
        }

        //POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAttack(int id)
        {
            var service = CreateWeaknessService();

            service.DeleteWeakness(id);

            TempData["SaveResult"] = "Your Weakness was deleted";

            return RedirectToAction("Index");
        }

        //Service READONLY
        private WeaknessService CreateWeaknessService()
        {
            var service = new WeaknessService();
            return service;
        }
    }
}