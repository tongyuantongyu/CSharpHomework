using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Homework12.Models {
  public class OrderContext : DbContext{
    public OrderContext(DbContextOptions<OrderContext> options)
      : base(options){
      this.Database.EnsureCreated(); //自动建库建表
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<OrderItem>()
        .HasKey(item => new {item.Name, item.OrderId});
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
  }
}
