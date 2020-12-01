using PTCG_Tracker.Data;
using PTCG_Tracker.Models.Weakness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Services
{
    public class WeaknessService
    {
        public bool CreateWeakness(WeaknessCreate model)
        {
            var newWeakness = new Weakness
            {
                WeaknessId = model.WeaknessId,
                Type = model.Type,
                Value = model.Value
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Weaknesses.Add(newWeakness);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WeaknessListItem> GetAllWeaknesses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Weaknesses
                    .Select(a => new WeaknessListItem
                    {
                        WeaknessId = a.WeaknessId,
                        Type = a.Type,
                        Value = a.Value

                    }
                    ).ToList();
            }
        }

        public WeaknessListItem GetWeaknessById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundWeakness = ctx.Weaknesses.Where(a => a.WeaknessId == id)
                    .FirstOrDefault();
                return (foundWeakness != null) ?
                    new WeaknessListItem()
                    {
                        WeaknessId = foundWeakness.WeaknessId,
                        Type = foundWeakness.Type,
                        Value = foundWeakness.Value
                    }
                    : null;
            }
        }

        public bool UpdateWeakness(WeaknessEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Weaknesses.Where(a => a.WeaknessId == model.WeaknessId)
                    .FirstOrDefault();
                if (entity == null)
                    return false;

                entity.Type = model.Type;
                entity.Value = model.Value;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteWeakness(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Weaknesses.Where(a => a.WeaknessId == id)
                    .FirstOrDefault();
                if (entity == null)
                    return false;

                ctx.Weaknesses.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
