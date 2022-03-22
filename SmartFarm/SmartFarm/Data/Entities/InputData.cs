using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFarm.Data.Entities
{
    public class InputData
    {
        public int Id { get; set; }
        public float ThongSo { get; set; }
        public DateTime ThoiGianThem { get; set; }
        public string Unit { get; set; }
        public Input Input { get; set; }
    }
}
