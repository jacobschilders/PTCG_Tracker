﻿using PTCG_Tracker.Data;
using PTCG_Tracker.Models.Ability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Services
{
    public class AbilityService
    {
        public bool CreateAbility(AbilityCreate model)
        {
            var newAbility = new Ability
            {
                Name = model.Name,
                Text = model.Text,
                Type = model.Type
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Abilities.Add(newAbility);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AbilityListItem> GetAllAbilities()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Abilities
                    .Select(a => new AbilityListItem
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Text = a.Text,
                        Type = a.Type
                        
                    }
                    ).ToList();
            }
        }

        public AbilityListItem GetAbilityById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundAbility = ctx.Abilities.Where(a => a.Id == id)
                    .FirstOrDefault();
                return (foundAbility != null) ?
                    new AbilityListItem()
                    {
                        Id = foundAbility.Id,
                        Name = foundAbility.Name,
                        Text = foundAbility.Text,
                        Type = foundAbility.Type
                        
                    }
                    : null;
            }
        }

        public bool UpdateAbility(AbilityEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Abilities.Where(a => a.Id == model.Id)
                    .FirstOrDefault();
                if (entity == null)
                    return false;

                entity.Name = model.Name;
                entity.Text = model.Text;
                entity.Type = model.Type;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAbility(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Abilities.Where(a => a.Id == id)
                    .FirstOrDefault();
                if (entity == null)
                    return false;

                ctx.Abilities.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}