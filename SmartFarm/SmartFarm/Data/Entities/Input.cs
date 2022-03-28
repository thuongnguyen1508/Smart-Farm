using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFarm.Data.Entities
{
    public class Input
    {
        public int Id { get; set; }
        public string LoaiThietBi { get; set; }
        public float Max { get; set; }
        public float Min { get; set; }
        public TimeSpan ThoiGianTruyXuat { get; set; }
        public String FeedName { get; set; }
        public Equipment Equipment { get; set; }
    }
}
