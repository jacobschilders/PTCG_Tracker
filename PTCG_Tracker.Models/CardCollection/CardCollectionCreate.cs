using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Models.CardCollection
{
    public class CardCollectionCreate
    {
        public ICollection<string> CardId { get; set; }

        public ICollection<int> CollectionId { get; set; }

    }
}
