using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.EntityConfigurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(od => new { od.OrderId, od.ProductId });

            builder.Property(od => od.OrderId)
                .IsRequired();

            builder.Property(od => od.ProductId)
                .IsRequired();

            builder.Property(od => od.Quantity)
                .IsRequired();

            builder.ToTable("OrderDetails");

            builder.Ignore(od => od.TotalPrice);

            builder.ToTable("OrderDetails");
            builder.HasCheckConstraint("CK_OrderDetail_Quantity", "Quantity > 0");

            builder.HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_OrderDetails_Orders");

            builder.HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_OrderDetails_Products");
        }
    }
}
