using System.Collections.Generic;
using System.Threading.Tasks;
using SmartFarm.Data;
using SmartFarm.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace SmartFarm.Services
{
    public class InputService:IInputService
    {
        private readonly AppDbContext _context;
        public InputService(AppDbContext context){
            _context = context;
        }

        public async Task<InputModel> GetInputIdAsync(int id)
        {
            var result = await (from i in _context.Input
                                join e in _context.Equipment on i.Id equals e.Id
                                where i.Id==id
                                select new InputModel
                                {
                                    id = i.Id,
                                    name = e.Ten,
                                    feedName = i.FeedName,
                                    thuocVeTrangTrai = e.ThuocVeTrangTrai,
                                    trangThai = e.TrangThai,
                                    viTri = e.ViTriDat,
                                    image = e.Image,
                                    thongTin=e.ThongTin,
                                    loaiThietBi=i.LoaiThietBi
                                }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<InputModel>> GetInputsAsync(){
            var result = await (from i in _context.Input
                                join e in _context.Equipment on i.Id equals e.Id
                                select new InputModel
                                {
                                    id = i.Id,
                                    name = e.Ten,
                                    feedName = i.FeedName,
                                    thuocVeTrangTrai = e.ThuocVeTrangTrai,
                                    trangThai = e.TrangThai,
                                    viTri = e.ViTriDat,
                                    image = e.Image,
                                    thongTin=e.ThongTin,
                                }).ToListAsync();
            return result;
        }
    }
}