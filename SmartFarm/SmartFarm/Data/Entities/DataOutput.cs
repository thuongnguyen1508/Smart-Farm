using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SmartFarm.Data.Entities
{
    public class DataOutput
    {
        public int Id { get; set; }
        public int OutputId { get; set; }
        public string UserName { get; set; }
        public bool ThongSo{ get; set;}
        public DateTime Time { get; set; }

        public Customer Customer { get; set; }
        public Output Output { get; set; }
    }
}