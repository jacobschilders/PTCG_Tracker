using PTCG_Tracker.Data;
using PTCG_Tracker.Models.Card;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Services
{
    public class CardService
    {
      

        public bool CreateCard(CardCreate model)
        {
            var entity = new Card()
            {
                ID = model.CardId,
                Name = model.Name,
                ImageURL = model.ImageURL,
                Type = model.Type,
                SuperType = model.SuperType,
                SubType = model.SubType,
                HP = model.HP,
                RetreatCost = model.RetreateCost,
                SetNumber = model.SetNumber,
                Series = model.Series,
                Set = model.Set,
                WeaknessId = model.WeaknessId,
                ResistanceId = model.ResistanceId,
                AbilityId = model.AbilityId,
                Artist = model.Artist,
                Rarity = model.Rarity,
                
                //How to add attacks to card? ICollection<Attack>
            };

            //entity.addtoAttackList <Research adding Multiple>

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cards.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Add Card to Collection (find collection then add card to it)


        public IEnumerable<CardListItem> GetCards(CardSearchParams model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var cards = ctx.Cards.AsQueryable();

                if (model.ShowOnlyPokemon)
                    cards = cards.Where(c => c.SuperType == "Pokemon");

                if (model.ShowOnlyTrainers)
                    cards = cards.Where(c => c.SuperType == "Trainer");

                if (model.ShowOnlyEnergy)
                    cards = cards.Where(c => c.SuperType == "Energy");

                return cards.Select(c => new CardListItem
                {
                    ID = c.ID,
                    Name = c.Name,
                    Rarity = c.Rarity
                }).ToArray();
            }
        }

        public CardDetails GetCardById(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var card = ctx.Cards.Where(c => c.ID == id)
                    .Include(c => c.Weakness)
                    .Include(c => c.Resistance)
                    .Include(c => c.Attacks)
                    .FirstOrDefault();

                if (card == null) return null;

                return new CardDetails()
                {
                    ID = card.ID,
                    Name = card.Name,
                    ImageURL = card.ImageURL,
                    Type = card.Type,
                    SuperType = card.SuperType,
                    HP = card.HP,
                    RetreatCost = card.RetreatCost,
                    SetNumber = card.SetNumber,
                    Series = card.Series,
                    Set = card.Set,
                    WeaknessId = card.WeaknessId,
                    ResistanceId = card.ResistanceId,
                    AbilityId = card.AbilityId,
                    Artist = card.Artist,
                    Rarity = card.Rarity,
                    Collections = (ICollection<Models.Collection.CollectionDetails>)card.Collections,
                    Attacks = (ICollection<Models.Attack.AttackDetails>)card.Attacks
                };
            }
        }

        public bool UpdateCard(CardEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var card = ctx.Cards.Where(c => c.ID == model.ID)
                    .FirstOrDefault();

                if (card == null) return false;

                card.ID = model.ID;
                card.Name = model.Name;
                card.ImageURL = model.ImageURL;
                card.Type = model.Type;
                card.SuperType = model.SuperType;
                card.SubType = model.SubType;
                card.HP = model.HP;
                card.RetreatCost = model.RetreatCost;
                card.SetNumber = model.SetNumber;
                card.Series = model.Series;
                card.Set = model.Set;
                card.WeaknessId = model.WeaknessId;
                card.ResistanceId = model.ResistanceId;
                card.AbilityId = model.AbilityId;
                card.Artist = model.Artist;
                card.Rarity = model.Rarity;
                // how to edit Attakcs

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCard(string id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var card = ctx.Cards
                    .Where(c => c.ID == id)
                    .FirstOrDefault();

                ctx.Cards.Remove(card);

                return ctx.SaveChanges() == 1; 
            }
        }


    }
}
