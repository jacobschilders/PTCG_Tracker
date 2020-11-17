using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Data
{//Joining Table
    public class CardCollection
    {
        [ForeignKey(nameof(CardId))]
        public string CardId { get; set; }
        public Card Card { get; set; }

        [ForeignKey(nameof(CollectionId))]
        public int CollectionId { get; set; }
        public Collection Collection { get; set; }

    }
}
