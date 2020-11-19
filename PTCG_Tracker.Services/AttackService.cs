using PTCG_Tracker.Data;
using PTCG_Tracker.Models.Attack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Services
{
    public class AttackService
    {
       public bool CreateAttack(AttackCreate model)
        {
            var newAttack = new Attack
            {
                Name = model.Name,
                Text = model.Text,
                Damage = model.Damage,
                EnergyCost = model.EnergyCost

            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Attacks.Add(newAttack);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AttackListItem> GetAllAttacks()
        {
            using(var ctx = new ApplicationDbContext())
            {
                return ctx.Attacks
                    .Select(a => new AttackListItem
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Text = a.Text,
                        Damage = a.Damage,
                        EnergyCost = a.EnergyCost
                    }
                    ).ToList();
            }
        }

        public AttackListItem GetAttackById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var foundAttack = ctx.Attacks.Where(a => a.Id == id)
                    .FirstOrDefault();
                return (foundAttack != null) ?
                    new AttackListItem()
                    {
                        Id = foundAttack.Id,
                        Name = foundAttack.Name,
                        Text = foundAttack.Text,
                        Damage = foundAttack.Damage,
                        EnergyCost = foundAttack.EnergyCost
                    }
                    : null;
            }
        }

        public bool UpdateAttack(AttackEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Attacks.Where(a => a.Id == model.Id)
                    .FirstOrDefault();
                if (entity == null)
                    return false;

                entity.Name = model.Name;
                entity.Text = model.Text;
                entity.Damage = model.Damage;
                entity.EnergyCost = model.EnergyCost;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAttack(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Attacks.Where(a => a.Id == id)
                    .FirstOrDefault();
                if (entity == null)
                    return false;

                ctx.Attacks.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
