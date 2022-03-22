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
        public DateTime ThoiGianTruyXuat { get; set; }
        public string ViTriTrangTrai { get; set; }
        public Equipment Equipment { get; set; }
        public InputData InputData { get; set; }
        public List<InputOutput> InputOutputs { get; set; }
    }
}
