using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartFarm.Data.Entities;

namespace SmartFarm.Data
{
    public class DataOutputConfiguration : IEntityTypeConfiguration<DataOutput>
    {

        public void Configure(EntityTypeBuilder<DataOutput> builder)
        {
            builder.ToTable("DataOutput");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Time);
            builder.Property(d => d.ThongSo);

            builder.HasOne(d => d.Output)
                    .WithMany(output => output.DataOutputs)
                    .HasForeignKey(d => d.OutputId);
            builder.HasOne(d => d.Customer)
                    .WithMany(customer => customer.DataOutputs)
                    .HasForeignKey(d => d.UserName);
        }
    }
}
