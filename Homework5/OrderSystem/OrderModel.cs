﻿namespace OrderSystem {
  using System;
  using System.Data.Entity;
  using System.Linq;

  public class OrderModel : DbContext {
    public OrderModel()
        : base("name=OrderDB") {
    }

    public DbSet<Order> OrderList { get; set; }
    public DbSet<OrderItem> ItemList { get; set; }
    // public virtual DbSet<MyEntity> MyEntities { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
      modelBuilder.Configurations.Add(new OrderItemMap());
    }
  }
}