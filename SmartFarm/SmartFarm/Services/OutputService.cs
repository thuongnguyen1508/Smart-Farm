using SmartFarm.Data;
using Microsoft.EntityFrameworkCore;
using SmartFarm.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SmartFarm.Services
{
    public class OutputService:IOutputService
    {
        private readonly AppDbContext _context;
        public OutputService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<OutputModel>> GetOutputAsync()
        {
            var result =  await (from o in _context.Output
                           join e in _context.Equipment on o.Id equals e.Id
                            select new OutputModel
                            {
                                id=o.Id,
                            name=e.Ten,
                            trangThaiHoatDong=o.TrangThaiHoatDong,
                            feedName=o.FeedName,
                            thuocVeTrangTrai=e.ThuocVeTrangTrai,
                            trangThai=e.TrangThai,
                            viTri=e.ViTriDat,
                            img=e.Img
                            }).ToListAsync();
                return result;
        }
    }

}