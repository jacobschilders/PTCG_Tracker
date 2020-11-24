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
        [Key]
        public int CollectionId { get; set; }

        [Display(Name = "Collection Name")]
        public string Name { get; set; }
        [Display(Name = "Number of Cards in Collection")]
        public int CardsInCollection { get; set; }

        [Display(Name = "Number of Cards needed to complete collection")]
        public int CardsUntilComplete { get; set; }

        [Display(Name = "The Collection is Public")]
        public bool Public { get; set; }

        [Display(Name = "The Collection is Complete")]
        public bool Complete { get; set; }

        public DateTimeOffset ModifiedAt { get; set; }
    }
}
