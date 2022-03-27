using System;

namespace SmartFarm.Models{
    public class OutputModel {
        public int id{ get; set;}
        public bool trangThaiHoatDong { get; set; }
        public String feedName{ get; set; }
        public String name{ get; set; }
        public int thuocVeTrangTrai{ get; set;}
        public bool trangThai{get; set; }
        public String viTri { get; set; }
        public String img { get; set; }
    }
}