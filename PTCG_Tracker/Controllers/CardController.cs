using Microsoft.AspNet.Identity;
using PTCG_Tracker.Models.Card;
using PTCG_Tracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTCG_Tracker.Controllers
{
    public class CardController : Controller
    {
        // GET: Card
        public ActionResult Index()
        {
            var search = new CardSearchParams();
            var service = new CardService();
            var model = service.GetCards(search);
            return View(model);
        }

        //GET: CardCreate
        public ActionResult Create()
        {
            return View();
        }

        //POST: Card Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CardCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCardService();

            if (service.CreateCard(model))
            {
                TempData["SaveResult"] = "Your card was created successfully";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Card could not be created.");

            return View(model);

        }

        //Get: CardDetails
        public ActionResult Details(string id)
        {
            var svc = CreateCardService();
            var model = svc.GetCardById(id);

            return View(model);
        }

        //Edit CardEdit
        public ActionResult Edit(string id)
        {
            var service = CreateCardService();
            var detail = service.GetCardById(id);
            var model =
                new CardEdit
                {
                    CardId = detail.CardId,
                    Name = detail.Name,
                    ImageURL = detail.ImageURL,
                    Type = detail.Type,
                    SuperType = detail.SuperType,
                    SubType = detail.SubType,
                    HP = detail.HP,
                    RetreatCost = detail.RetreatCost,
                    SetNumber = detail.SetNumber,
                    Series = detail.Series,
                    Set = detail.Set,
                    WeaknessId = detail.WeaknessId,
                    ResistanceId = detail.ResistanceId,
                    AbilityId = detail.AbilityId,
                    Artist = detail.Artist,
                    Rarity = detail.Rarity,
                };
            return View(model);
        }
        //PUT: Card/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, CardEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.CardId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCardService();

            if (service.UpdateCard(model))
            {
                TempData["SaveResult"] = "Your card was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your card could not be updated.");
            return View(model);
        }

        //Get: Delete
        [ActionName("Delete")]
        public ActionResult Delete(string id)
        {
            var service = CreateCardService();
            var model = service.GetCardById(id);

            return View(model);
        }

        //Post: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCard(string id)
        {
            var service = CreateCardService();
            service.DeleteCard(id);
            TempData["SaveResult"] = "Your card was successfully deleted";
            return RedirectToAction("Index");
        }

        private CardService CreateCardService()
        {
            var service = new CardService();
            return service;

        }
    }
}