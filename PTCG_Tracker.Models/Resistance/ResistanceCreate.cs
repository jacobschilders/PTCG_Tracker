using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Models.Resistance
{
    public class ResistanceCreate
    {
        [Key]
        public int ResistanceId { get; set; }
        public string Type { get; set; }

        public string Value { get; set; }

    }
}
