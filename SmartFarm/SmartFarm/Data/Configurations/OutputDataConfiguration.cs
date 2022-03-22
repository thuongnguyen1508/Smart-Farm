using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartFarm.Data.Entities;

namespace SmartFarm.Data.Configurations
{
    public class OutputDataConfiguration : IEntityTypeConfiguration<OutputData>
    {
        public void Configure(EntityTypeBuilder<OutputData> builder)
        {
            builder.ToTable("OUTPUTDATA");
            builder.HasKey(data => new {data.Id,data.ThoiGianThem,data.CustomerId });
            builder.Property(data => data.ThongSo);
            builder.HasOne(output => output.Output)
                .WithMany(data => data.OutputDatas)
                .HasForeignKey(data => data.Id)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(data => data.Customer)
                .WithMany(customer => customer.OutputDatas)
                .HasForeignKey(data => data.CustomerId);
        }
    }
}
