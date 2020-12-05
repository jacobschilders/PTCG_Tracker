using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Models.Card
{
    public class CardCollection
    {
        [Key]

        public string CardId { get; set; }

        public int CollectionId { get; set; }

    }
}
