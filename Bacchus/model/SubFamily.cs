﻿using System;

namespace Bacchus.model
{
    class SubFamily
    {
        public String RefSubFamily { get; set; }
        public Family RefFamily { get; set; }
        public String NameSubFamily { get; set; }

        public SubFamily()
        {

        }
    }
}