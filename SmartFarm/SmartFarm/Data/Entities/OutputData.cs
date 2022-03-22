using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFarm.Data.Entities
{
    public class OutputData
    {
        public int Id { get; set; }
        public bool ThongSo { get; set; }
        public DateTime ThoiGianThem { get; set; }
        public Guid CustomerId { get; set; }
        public Output Output { get; set; }
        public Customer Customer { get; set; }
    }
}
