using PTCG_Tracker.Models.Attack;
using PTCG_Tracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTCG_Tracker.Controllers
{
    public class AttackController : Controller
    {
        // GET: Attack
        public ActionResult Index()
        {
            var service = new AttackService();
            var model = service.GetAllAttacks();

            return View(model);
        }

        // GET: AttackCreate
        public ActionResult Create()
        {
            return View();
        }

        //POST: AttackCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AttackCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAttackService();

            if (service.CreateAttack(model))
            {
                TempData["SaveResult"] = "Your Attack was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Attack could not be created.");

            return View(model);
        }

        //GET: AttackDetails
        public ActionResult Details(int id)
        {
            var service = CreateAttackService();
            var model = service.GetAttackById(id);

            return View(model);
        }

        //Edit: AttackEdit
        public ActionResult Edit(int id)
        {
            var service = CreateAttackService();
            var detail = service.GetAttackById(id);
            var model =
                new AttackEdit
                {
                    AttackId = detail.AttackId,
                    Name = detail.Name,
                    Text = detail.Text,
                    Damage = detail.Damage,
                    EnergyCost = detail.EnergyCost          
                };
            return View(model);
        }

        //PUT: AttackEdit/ {id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AttackEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AttackId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAttackService();

            if (service.UpdateAttack(model))
            {
                TempData["SaveResult"] = "Your Attack was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Attack could not be updated.");
            return View(model);
        }

        //GET: Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateAttackService();
            var model = service.GetAttackById(id);

            return View(model);
        }

        //POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAttack(int id)
        {
            var service = CreateAttackService();

            service.DeleteAttack(id);

            TempData["SaveResult"] = "Your Attack was deleted";

            return RedirectToAction("Index");
        }

        //Service READONLY
        private AttackService CreateAttackService()
        {
            var service = new AttackService();
            return service;
        }
    }
}
