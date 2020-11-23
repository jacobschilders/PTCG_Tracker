
using PTCG_Tracker.Models.Card;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Models.Collection
{
    public class CollectionDetails
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Public { get; set; }
        //can be determined by the number of cardsincollection compared to cards until complete
        public bool Complete { get; set; }

        //a calculation can be done based on List<Card> prop
        public int CardsInCollection { get; set; }

        public int CardsUntilComplete { get; set; }

        public ICollection<CardDetails> Cards { get; set; }

    }
}
