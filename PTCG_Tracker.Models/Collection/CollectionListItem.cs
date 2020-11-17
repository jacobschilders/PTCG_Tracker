using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Models.Collection
{
    public class CollectionListItem
    {
        public int Id { get; set; }

        [Display(Name = "Collection Name")]
        public string Name { get; set; }
        [Display(Name = "Number of Cards in Collection")]
        public int CardsInCollection { get; set; }
    }
}
