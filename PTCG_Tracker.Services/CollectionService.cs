using PTCG_Tracker.Data;
using PTCG_Tracker.Models.Card;
using PTCG_Tracker.Models.Collection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Services
{
    public class CollectionService
    {
        public bool CreateCollection(CollectionCreate model)
        {
            var entity = new Collection
            {
                CollectionId = model.CollectionId,
                Name = model.Name,
                Public = model.Public,
                CardsUntilComplete = model.CardsUntilComplete
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Collections.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //update cards in collection (add and remove)
        //public bool UpdateCardsInCollection(CollectionEdit model)
        //{
        //    using(var ctx = new ApplicationDbContext())
        //    {
        //        var entity = ctx.Collections.Where(c => c.Id == model.Id)
        //            .FirstOrDefault();
        //        if (entity == null)
        //            return false;

        //        var cards = new List<Card>();
                

        //        return ctx.SaveChanges() == 1;
        //    }
        //}
        public IEnumerable<CollectionListItem> GetAllCollections()
        {
            using(var ctx = new ApplicationDbContext())
            {
                return ctx.Collections
                    .Select(c => new CollectionListItem
                    {
                        CollectionId = c.CollectionId,
                        Name = c.Name,
                        //CardsInCollection = (int)c.CardsInCollection
                    }
                    ).ToList();
            }
        }

        public CollectionDetails GetCollectionById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var foundCollection = ctx.Collections.Where(c => c.CollectionId == id)
                    .FirstOrDefault();
                var cardService = new CardService();

                return (foundCollection != null) ?
                    new CollectionDetails ()
                    {
                        CollectionId = foundCollection.CollectionId,
                        Name = foundCollection.Name,
                        Public = foundCollection.Public,
                        //CardsInCollection = (int)foundCollection.CardsInCollection,
                        CardsUntilComplete = foundCollection.CardsUntilComplete,
                        Cards = (ICollection<CardDetails>)cardService.GetCardsByCollectionId(id)
                        //ModifiedAt = foundCollection.ModifiedAt
                        
                    }
                    : null;
            }
        }

        public bool UpdateCollection(CollectionEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Collections.Where(c => c.CollectionId == model.CollectionId)
                    .FirstOrDefault();
                if (entity == null)
                    return false;

                entity.Name = model.Name;
                entity.Public = model.Public;
                entity.CardsUntilComplete = model.CardsUntilComplete;
                entity.ModifiedAt = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCollection(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Collections.Where(c => c.CollectionId == id)
                    .FirstOrDefault();
                if (entity == null)
                    return false;

                ctx.Collections.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
