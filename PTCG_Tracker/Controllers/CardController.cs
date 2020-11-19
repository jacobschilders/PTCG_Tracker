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

        private CardService CreateCardService()
        {
            var service = new CardService();
            return service;

        }
    }
}