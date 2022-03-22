using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFarm.Data.Entities
{
    public class Output
    {
        public int Id { get; set; }
        public bool TrangThaiHoatDong { get; set; }
        public string ViTriTrangTrai { get; set; }
        public Equipment Equipment { get; set; }
        public List<OutputData> OutputDatas { get; set; }
        public List<InputOutput> InputOutputs { get; set; }
    }
}
