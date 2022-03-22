using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartFarm.Data.Entities;

namespace SmartFarm.Data.Configurations
{
    public class InputDataConfiguration : IEntityTypeConfiguration<InputData>
    {
        public void Configure(EntityTypeBuilder<InputData> builder)
        {
            builder.ToTable("INPUTDATA");
            builder.HasKey(data => new {data.Id,data.ThoiGianThem,data.Unit});
            builder.Property(data => data.ThongSo);
            builder.HasOne(input => input.Input)
                .WithOne(data => data.InputData)
                .HasForeignKey<InputData>(data => data.Id);
        }
    }
}
