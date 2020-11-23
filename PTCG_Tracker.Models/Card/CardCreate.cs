using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Models.Card
{
    public class CardCreate
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
        
        public int RetreateCost { get; set; }
        [Required]
        public int SetNumber { get; set; }
        [Required]
        public string Series { get; set; }
        [Required]
        public string Set { get; set; }

        public int WeaknessId { get; set; }

        public int ResistanceId { get; set; }

        public int AbilityId { get; set; }
        [Required]
        public string Artist { get; set; }
        [Required]
        public string Rarity { get; set; }

        
    }
}
