using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Models.Card
{
    public class CardSearchParams
    {
        public string CardId { get; set; }

        public bool ShowOnlyPokemon { get; set; } = false;

        public bool ShowOnlyTrainers { get; set; } = false;

        public bool ShowOnlyEnergy { get; set; } = false;

        public string SuperType { get; set; }
    }
}
