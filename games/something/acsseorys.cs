﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace games.something
{
    public class Acsseorys
    {
        public string peripheral_name { get; set; }

        public int peripheral_id { get; set; }

        public string peripheral_supplier { get; set; }
        public Acsseorys(string AcsseorysName, int AcsseorysId, string AcsseorysSupplier)
        {

            peripheral_id = AcsseorysId;

            peripheral_name = AcsseorysName;

            peripheral_supplier = AcsseorysSupplier;
        }
    }
}
