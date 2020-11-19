using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PTCG_Tracker.Models.Card
{
    public class CardEdit
    {
            public string ID { get; set; }

            public string Name { get; set; }

            public string ImageURL { get; set; }

            public string Type { get; set; }

            public string SuperType { get; set; }

            public string SubType { get; set; }

            public int HP { get; set; }

            public int RetreatCost { get; set; }

            public int SetNumber { get; set; }

            public string Series { get; set; }

            public string Set { get; set; }

            public int WeaknessId { get; set; }

            public int ResistanceId { get; set; }

            public int AbilityId { get; set; }

            public string Artist { get; set; }

            public string Rarity { get; set; }
    }
}
