﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTCG_Tracker.Models.Collection
{
    public class CollectionCreate
    {
        [Key]
        public int CollectionId { get; set; }
        public string Name { get; set; }

        public bool Public { get; set; }

        public int CardsUntilComplete { get; set; }
    }
}
