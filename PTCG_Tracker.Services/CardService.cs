using PTCG_Tracker.Data;
using PTCG_Tracker.Models.Card;
using PTCG_Tracker.Models.Collection;
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
                CardId = model.CardId,
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
            //using(var ctx = new ApplicationDbContext())
            //{
            //    var attackEntity = ctx.Attacks.ToList();
            //    var attackList = attackEntity.Add(a => new Attack
            //    {
            //        AttackId = a.AttackId,
            //        Name = a.Name,
            //        Text = a.Text,
            //        Damage = a.Damage,
            //        EnergyCost = a.EnergyCost

            //    })
            //}
            

            //entity.addtoAttackList <Research adding Multiple>
            //entity.Attacks.Add(new Attack());

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cards.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Add Card to Collection (find collection then add card to it)
        //public IEnumerable<Card> AddCardsToCollection(CollectionDetails model)
        //{

        //}

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
                    CardId = c.CardId,
                    Name = c.Name,
                    Rarity = c.Rarity
                }).ToArray();
            }
        }

        public CardDetails GetCardById(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var card = ctx.Cards.Where(c => c.CardId == id)
                    .Include(c => c.Weakness)
                    .Include(c => c.Resistance)
                    .Include(c => c.Attacks)
                    .FirstOrDefault();

                if (card == null) return null;

                return new CardDetails()
                {
                    CardId = card.CardId,
                    Name = card.Name,
                    ImageURL = card.ImageURL,
                    Type = card.Type,
                    SuperType = card.SuperType,
                    HP = card.HP,
                    RetreatCost = card.RetreatCost,
                    SetNumber = card.SetNumber,
                    Series = card.Series,
                    Set = card.Set,
                    WeaknessId = (int)card.WeaknessId,
                    ResistanceId = (int)card.ResistanceId,
                    AbilityId = (int)card.AbilityId,
                    Artist = card.Artist,
                    Rarity = card.Rarity,
                    Collections = (HashSet<Models.Collection.CollectionDetails>)card.Collections,
                    Attacks = (HashSet<Models.Attack.AttackDetails>)card.Attacks
                };
            }
        }

        public bool UpdateCard(CardEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var card = ctx.Cards.Where(c => c.CardId == model.CardId)
                    .FirstOrDefault();

                if (card == null) return false;

                card.CardId = model.CardId;
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
                    .Where(c => c.CardId == id)
                    .FirstOrDefault();

                ctx.Cards.Remove(card);

                return ctx.SaveChanges() == 1; 
            }
        }


    }
}
