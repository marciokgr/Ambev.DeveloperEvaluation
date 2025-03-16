﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {

            builder.HasKey(si => si.Id);
            builder.Property(si => si.ProductId).IsRequired();
            builder.Property(si => si.Quantity).IsRequired();
            builder.Property(si => si.UnitPrice).HasColumnType("decimal(18,2)");
            builder.Property(si => si.Discount).HasColumnType("decimal(18,2)");
            builder.Property(si => si.TotalPrice).HasColumnType("decimal(18,2)");

            // Restrições da tabela
            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(si => si.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
