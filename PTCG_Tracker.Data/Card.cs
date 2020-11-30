﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Data
{
    public class Card
    {
        [Key]
        public string CardId { get; set; }
        [Required]
        public string Name { get; set; }

        public string ImageURL { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string SuperType { get; set; }
        [Required]
        public string SubType { get; set; }

        public int HP { get; set; }

        public int RetreatCost { get; set; }


        public int SetNumber { get; set; }

        public string Series { get; set; }

        public string Set { get; set; }

        //Connection to Weakness Table
        [DisplayFormat(NullDisplayText ="No Weakness Available")]
        public int? WeaknessId { get; set; }
        [ForeignKey(nameof(WeaknessId))]
        public virtual Weakness Weakness { get; set; }

        //Connection to Resistance Table
        [DisplayFormat(NullDisplayText = "No Resistance Available")]
        public int? ResistanceId { get; set; }
        [ForeignKey(nameof(ResistanceId))]
        public virtual Resistance Resistance { get; set; }

        //Connection to Ability Table
        [DisplayFormat(NullDisplayText = "No Ability Available")]
        public int? AbilityId { get; set; }
        [ForeignKey(nameof(AbilityId))]
        public virtual Ability Ability { get; set; }

        public string Artist { get; set; }

        public string Rarity { get; set; }

        public virtual ICollection<Attack> Attacks { get; set; }
       
         public virtual ICollection<Collection> Collections { get; set; }
        


    }
}
