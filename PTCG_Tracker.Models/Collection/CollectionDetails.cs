﻿using PTCG_Tracker.Models.Card;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PTCG_Tracker.Models.Collection
{
    public class CollectionDetails
    {
        [Key]
        public int CollectionId { get; set; }

        public string Name { get; set; }

        public bool Public { get; set; }
        //can be determined by the number of cardsincollection compared to cards until complete
        public bool Complete {

            get
            {
                if (CardsInCollection == CardsUntilComplete)
                {
                    return true;
                }
                return false;
            }
        }

        //a calculation can be done based on List<Card> prop
        public int CardsInCollection { 
            
                get
                {
                    var cardsInCollection = Cards.Count();
                    return cardsInCollection;
                }
            
        }

        public int CardsUntilComplete { get; set; }

        public ICollection<CardDetails> Cards { get; set; }

    }
}
