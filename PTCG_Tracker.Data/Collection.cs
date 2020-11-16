using System;
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
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Card> cards { get; set; }

        public bool Public { get; set; }

        public bool Complete { get; set; }

        //a calculation can be done based on List<Card> prop
        public int CardsInCollection { get; set; }

        public int CardsUntilComplete { get; set; }
    }
}
