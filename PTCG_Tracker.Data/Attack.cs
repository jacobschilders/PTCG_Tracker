﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Data
{
    public class Attack
    {
        [Key]
        public int AttackId { get; set; }
        [Required]
        public string Name { get; set; }

        public string Text { get; set; }

        public string Damage { get; set; }

        public string EnergyCost { get; set; }
        
        public virtual Card Card { get; set; }


    }
}
