using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Models.CardModels
{
    public class CardAttack
    {
        [Key]
        public string CardId { get; set; }

        public int AttackId { get; set; }
    }
}
