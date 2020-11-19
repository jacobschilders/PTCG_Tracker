using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Models.CardCollection
{
    public class CardCollectionDetails
    {
        public int Id { get; set; }

        public string CardId { get; set; }

        public string CardName { get; set; }

        public int CollectionId { get; set; }

        public string CollectionName { get; set; }


    }
}
