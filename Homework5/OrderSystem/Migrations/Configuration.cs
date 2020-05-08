namespace OrderSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OrderSystem.OrderModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OrderSystem.OrderModel context) {
          if (context.OrderList.Any()) {
            return;
          }
          var order = new Order("example");
          if (!context.OrderList.Any()) {
            context.OrderList.Add(order);
          }

          var item = new OrderItem("item 1 1") {Order = order, OrderId = order.Id};
          context.ItemList.Add(item);
        }
    }
}
