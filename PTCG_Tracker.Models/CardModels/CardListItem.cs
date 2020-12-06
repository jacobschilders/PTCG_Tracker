using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Models.Card
{
    public class CardListItem
    {
        public string CardId { get; set; }

        public string Name { get; set; }

        public string Rarity { get; set; }

        public string SuperType { get; set; }

        public string Series { get; set; }

        public string Set { get; set; }
    }
}
