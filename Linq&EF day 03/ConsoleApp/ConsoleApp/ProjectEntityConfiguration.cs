using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class ProjectEntityConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {

            builder.Property(p => p.Id)
            .UseIdentityColumn(seed: 10, increment: 10);

            builder.Property(p => p.Name)
            .HasMaxLength(50)
            .HasDefaultValue("OurProject")
            .IsRequired();

            builder.Property(p => p.Cost)
            .HasColumnType("money");
            builder.ToTable("Projects");
            builder.HasCheckConstraint("CK_Project_Cost_Range",
            "[Cost] >= 500000 AND [Cost] <= 3500000"
            );
        }
    }
}
