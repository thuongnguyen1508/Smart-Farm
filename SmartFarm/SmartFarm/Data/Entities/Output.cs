﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFarm.Data.Entities
{
    public class Output
    {
        public int Id { get; set; }
        public bool TrangThaiHoatDong { get; set; }
        public String FeedName{ get; set;}
        public Equipment Equipment { get; set; }
    }
}