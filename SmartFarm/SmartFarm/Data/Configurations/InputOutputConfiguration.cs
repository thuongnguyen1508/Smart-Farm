using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartFarm.Data.Entities;

namespace SmartFarm.Data.Configurations
{
    public class InputOutputConfiguration : IEntityTypeConfiguration<InputOutput>
    {
        public void Configure(EntityTypeBuilder<InputOutput> builder)
        {
            builder.ToTable("INPUTOUTPUT");
            builder.HasKey(data => data.IdLink);
            builder.Property(a => a.IdInput);
            builder.Property(a => a.IdOutput);

            builder.HasOne(input => input.Input)
                .WithMany(a => a.InputOutputs)
                .HasForeignKey(input => input.IdInput)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(output => output.Output)
                .WithMany(a => a.InputOutputs)
                .HasForeignKey(output => output.IdOutput)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
