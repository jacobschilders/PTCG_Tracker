﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Data
{
    public class Collection
    {
        [Key]
        public int CollectionId { get; set; }

        public string Name { get; set; }

        public bool Public { get; set; }
        //can be determined by the number of cardsincollection compared to cards until complete
        public bool Complete 
        { 
            get 
            {
                if(CardsInCollection == CardsUntilComplete)
                {
                    return true;
                }
                return false;
            } 
        }


        public int CardsUntilComplete { get; set; }

        public DateTimeOffset ModifiedAt { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
       
        //a calculation can be done based on List<Card> prop
        public int? CardsInCollection
        {
            get
            {
                var cardsInCollection = Cards.Count();
                return cardsInCollection;
            }
        }

    }
}
