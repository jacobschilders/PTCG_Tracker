﻿using PTCG_Tracker.Data;
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

        public IEnumerable<CollectionListItem> GetAllCollections()
        {
            using(var ctx = new ApplicationDbContext())
            {
                return ctx.Collections
                    .Select(c => new CollectionListItem
                    {
                        Id = c.Id,
                        Name = c.Name,
                        CardsInCollection = c.CardsInCollection
                    }
                    ).ToList();
            }
        }

        public CollectionListItem GetCollectionById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var foundCollection = ctx.Collections.Where(c => c.Id == id)
                    .FirstOrDefault();
                return (foundCollection != null) ?
                    new CollectionListItem()
                    {
                        Id = foundCollection.Id,
                        Name = foundCollection.Name,
                        CardsInCollection = foundCollection.CardsInCollection
                    }
                    : null;
            }
        }

        public bool UpdateCollection(CollectionEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Collections.Where(c => c.Id == model.Id)
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
                var entity = ctx.Collections.Where(c => c.Id == id)
                    .FirstOrDefault();
                if (entity == null)
                    return false;

                ctx.Collections.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
