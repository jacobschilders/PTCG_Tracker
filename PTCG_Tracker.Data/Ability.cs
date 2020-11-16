using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Data
{
    public class Ability
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string Type { get; set; }
    }
}
