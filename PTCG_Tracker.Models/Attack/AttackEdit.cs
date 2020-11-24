﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Models.Attack
{
    public class AttackEdit
    {
        [Key]
        public int AttackId { get; set; }
        public string Name { get; set; }

        public string Text { get; set; }

        public string Damage { get; set; }

        public List<string> EnergyCost { get; set; }

    }
}
