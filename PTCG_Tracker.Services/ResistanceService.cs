﻿using PTCG_Tracker.Data;
using PTCG_Tracker.Models.Resistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Services
{
    public class ResistanceService
    {
        public bool CreateResistance(ResistanceCreate model)
        {
            var newResistance = new Resistance
            {
                Type = model.Type,
                Value = model.Value
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Resistances.Add(newResistance);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ResistanceListItem> GetAllResistances()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Resistances
                    .Select(a => new ResistanceListItem
                    {
                        Id = a.Id,
                        Type = a.Type,
                        Value = a.Value

                    }
                    ).ToList();
            }
        }

        public ResistanceListItem GetResistanceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundResistance = ctx.Resistances.Where(a => a.Id == id)
                    .FirstOrDefault();
                return (foundResistance != null) ?
                    new ResistanceListItem()
                    {
                        Id = foundResistance.Id,
                        Type = foundResistance.Type,
                        Value = foundResistance.Value
                    }
                    : null;
            }
        }

        public bool UpdateResistance(ResistanceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Resistances.Where(a => a.Id == model.Id)
                    .FirstOrDefault();
                if (entity == null)
                    return false;

                entity.Type = model.Type;
                entity.Value = model.Value;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteResistance(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Resistances.Where(a => a.Id == id)
                    .FirstOrDefault();
                if (entity == null)
                    return false;

                ctx.Resistances.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
