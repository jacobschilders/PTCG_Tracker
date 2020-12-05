using PTCG_Tracker.Data;
using PTCG_Tracker.Models.Attack;
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
                
                
            };

            
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cards.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Add Card to Collection (find collection then add card to it)
        public bool AddCardToCollection(int collectionId, string cardId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundCollection = ctx.Collections.Find(collectionId);
                var addedCard = ctx.Cards.Find(cardId);

                foundCollection.Cards.Add(addedCard);
               
                return ctx.SaveChanges() == 1;

            }
        }

        public IEnumerable<CardDetails> GetCardsByCollectionId(int collectionId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var collectedCards = ctx.Collections.Single(c => c.CollectionId == collectionId)
                    .Cards
                    .Select(c => new CardDetails
                    {
                        CardId = c.CardId,
                        Name = c.Name,
                        Rarity = c.Rarity,
                        SuperType = c.SuperType
                    });
                return collectedCards.ToArray();
            }
        }

        public bool AddAttackToCard(int attackId, string cardId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var foundCard = ctx.Cards.Find(cardId);
                var addedAttack = ctx.Attacks.Find(attackId);

                foundCard.Attacks.Add(addedAttack);

                return ctx.SaveChanges() == 1;
            }
        }

        //[OutputCache(Duration= int.MaxValue, VaryByParam = "model")]
        public IEnumerable<CardListItem> GetCards(/*CardSearchParams model*/)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var cards = ctx.Cards.AsQueryable();

                //if (model.ShowOnlyPokemon)
                //    cards = cards.Where(c => c.SuperType == "Pokemon");

                //if (model.ShowOnlyTrainers)
                //    cards = cards.Where(c => c.SuperType == "Trainer");

                //if (model.ShowOnlyEnergy)
                //    cards = cards.Where(c => c.SuperType == "Energy");

                return cards.Select(c => new CardListItem
                {
                    CardId = c.CardId,
                    Name = c.Name,
                    Rarity = c.Rarity,
                    SuperType = c.SuperType
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
                    .FirstOrDefault();

                if (card == null) return null;
                var attackService = new AttackService();
                var collectionService = new CollectionService();

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
                    Attacks = (ICollection<AttackDetails>)attackService.GetAttacksByCardId(id),
                    Collections = (ICollection<CollectionDetails>)collectionService.GetCollectionByCardId(id)
                    
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
