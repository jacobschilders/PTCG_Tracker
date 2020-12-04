using PTCG_Tracker.Models.Collection;
using PTCG_Tracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTCG_Tracker.Controllers
{
    public class CollectionController : Controller
    {
        // GET: Collection
        public ActionResult Index()
        {
            var service = new CollectionService();
            var model = service.GetAllCollections();
            return View(model);
        }

        // GET: CollectionCreate
        public ActionResult Create()
        {
            return View();
        }

        //POST: CollectionCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CollectionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCollectionService();

            if (service.CreateCollection(model))
            {
                TempData["SaveResult"] = "Your Collection was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Collection could not be created.");

            return View(model);
        }

        //GET: CollectionDetails
        public ActionResult Details(int id)
        {
            var service = CreateCollectionService();
            var model = service.GetCollectionById(id);

            return View(model);
        }

        //Edit: CollectionEdit
        public ActionResult Edit(int id)
        {
            var service = CreateCollectionService();
            var detail = service.GetCollectionById(id);
            var model =
                new CollectionEdit
                {
                    CollectionId = detail.CollectionId,
                    Name = detail.Name,
                    Public = detail.Public,
                    CardsUntilComplete = detail.CardsUntilComplete,
                    ModifiedAt = DateTime.Now
                };
            return View(model);
        }

        //PUT: CollectionEdit/ {id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CollectionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.CollectionId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCollectionService();

            if (service.UpdateCollection(model))
            {
                TempData["SaveResult"] = "Your collection was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your collection could not be updated.");
            return View(model);
        }

        //GET: Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateCollectionService();
            var model = service.GetCollectionById(id);

            return View(model);
        }

        //POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCollection(int id)
        {
            var service = CreateCollectionService();

            service.DeleteCollection(id);

            TempData["SaveResult"] = "Your collection was deleted";

            return RedirectToAction("Index");
        }

        //Service READONLY
        private CollectionService CreateCollectionService()
        {
            var service = new CollectionService();
            return service;
        }
    }
}