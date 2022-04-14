using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartFarm.Data;
using SmartFarm.Data.Entities;
using SmartFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartFarm.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly SignInManager<Customer> _signInManager;
        private readonly UserManager<Customer> _userManager;
        private readonly AppDbContext _context;
        public CustomerService(
            SignInManager<Customer> signInManager,
            UserManager<Customer> userManager,
            AppDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }
        public async Task<bool> LoginAsync(string username, string password)
        {
            var customer = await _userManager.FindByNameAsync(username);
            if (customer == null)
            {
                return false;
            }
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            return result.Succeeded;
        }
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public UserInforViewModel InforUser(string UserName)
        {
            var user = (from a in _context.Customer
                              where a.UserName == UserName
                              select new UserInforViewModel
                              {
                                  UserName = a.UserName,
                                  Ho = a.Ho,
                                  Ten = a.Ten,
                                  Address = a.DiaChi,
                                  Email = a.Email,
                                  ImgUrl=a.Image
                              }).FirstOrDefault();
            return user;
        }
        public void PostEditAccount(UserInforViewModel account)
        {
            var user = (from a in _context.Customer
                        where a.UserName == account.UserName
                        select a).FirstOrDefault();
            user.Ho = account.Ho;
            user.Ten = account.Ten;
            user.Email = account.Email;
            user.DiaChi = account.Address;
            _context.SaveChanges();
        }
        public async Task<bool> PostPassword(UserInforViewModel account)
        {
            var customer = (from a in _context.Customer
                            where a.UserName == account.UserName
                            select a.Id).FirstOrDefault();
            var customerID = customer.ToString();
            var user = await _userManager.FindByIdAsync(customerID);
            var result = await _userManager.ChangePasswordAsync(user, account.CurentPassword, account.Password);
            return result.Succeeded;
        }
        public async Task<List<EquipmentViewModel>> GetEquipmentAsync(int idFarm)
        {
            var equip = await (from e in _context.Equipment
                               where e.ThuocVeTrangTrai==idFarm && e.TrangThai==true
                                   select new EquipmentViewModel 
                                   {
                                       id=e.Id,
                                       image=e.Image,
                                       loaiThietBi=e.Loai,
                                       name=e.Ten,
                                       thongTin=e.ThongTin,
                                       thuocVeTrangTrai=e.ThuocVeTrangTrai,
                                       trangThai=e.TrangThai,
                                       viTri=e.ViTriDat,
                                       
                                   }).ToListAsync();
            return equip;
        }
        public async Task InsertEquipment(InsertEquipmentViewModel equipment,ClaimsPrincipal User)
        {
            var customer = await _userManager.GetUserAsync(User);
            var Idcustomer = customer.Id;
            var IdFarm = await (from a in _context.Customer
                                where a.Id == Idcustomer
                                select a.SoHuuTrangTrai).FirstOrDefaultAsync();
            var viTri = equipment.X +" "+ equipment.Y;
            if (equipment.loaiThietBi=="output")
            {
                var newEquipment = new Equipment()
                {
                    Ten = equipment.nameOut,
                    Loai = equipment.loaiThietBi,
                    ThuocVeTrangTrai = IdFarm,
                    Image = equipment.image,
                    TrangThai = true,
                    ViTriDat = viTri,
                    ThongTin = equipment.thongTin
                };
                _context.Equipment.Add(newEquipment);
                _context.SaveChanges();
                var IdOutput = (from i in _context.Equipment
                               select i.Id).Max();
                var valueOpen = -1;
                var countValue = (from v in _context.Output
                                  join e in _context.Equipment on v.Id equals e.Id
                                  where e.ThuocVeTrangTrai == IdFarm
                                  select v.ValueOpen).Count();
                if(countValue>0)
                {
                    valueOpen = (from v in _context.Output
                                 join e in _context.Equipment on v.Id equals e.Id
                                 where e.ThuocVeTrangTrai == IdFarm
                                 select v.ValueOpen).Max();
                }
                var newOutput = new Output()
                {
                    Id = IdOutput,
                    TrangThaiHoatDong = true,
                    ValueOpen=valueOpen+2
                };
                _context.Output.Add(newOutput);
                _context.SaveChanges();
            }
            else
            {
                var newEquipment = new Equipment()
                {
                    Ten = equipment.nameIn,
                    Loai = equipment.loaiThietBi,
                    ThuocVeTrangTrai = IdFarm,
                    Image = equipment.image,
                    TrangThai = true,
                    ViTriDat = viTri,
                    ThongTin = equipment.thongTin
                };
                _context.Equipment.Add(newEquipment);
                _context.SaveChanges();
                var IdInput = (from i in _context.Equipment
                              select i.Id).Max();
                var newInput = new Input()
                {
                    Id = IdInput,
                    LoaiThietBi=equipment.nameIn
                };
                _context.Input.Add(newInput);
                _context.SaveChanges();
                var newInOut = new InputOutput()
                {
                    IdInput = IdInput,
                    IdOutput = equipment.idOutput,
                    LoaiThietBiInput = equipment.nameIn
                };
                _context.InputOutput.Add(newInOut);
                _context.SaveChanges();
            }
            
        }
        public void DeleteEquipment(int id)
        {
            var equipment = (from e in _context.Equipment
                             where e.Id == id
                             select e).FirstOrDefault();
            equipment.TrangThai = false;
            _context.SaveChanges();
        }
        public EditEquipmentViewModel GetEquipmentDetail(int id)
        {
            var equipment = (from e in _context.Equipment
                             where e.Id == id
                             select new EditEquipmentViewModel
                             {
                                 id=e.Id,
                                 image=e.Image,
                                 thongTin=e.ThongTin,
                                 thuocVeTrangTrai=e.ThuocVeTrangTrai,
                                 viTri=e.ViTriDat,
                                 name=e.Ten
                             }).FirstOrDefault();
            return equipment;

        }
        public void PostEditEquipment(EditEquipmentViewModel equipment)
        {
            var equip = (from e in _context.Equipment
                           where e.Id == equipment.id
                           select e).FirstOrDefault();
            equip.Image = equipment.image;
            equip.ThongTin = equipment.thongTin;
            equip.ThuocVeTrangTrai = equipment.thuocVeTrangTrai;
            equip.ViTriDat = equipment.viTri;
            _context.SaveChanges();
        }
    }
}