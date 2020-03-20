using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderSystem {
  internal static class Terminal {
    private static void editOrder(ref Order order) {
      Console.WriteLine("Enter order editor.");

      while (true) {
        Console.Write("O>> ");
        Console.Out.Flush();
        var op = Console.ReadLine();
        if (string.IsNullOrEmpty(op)) {
          continue;
        }

        switch (op[0]) {
          // create
          case 'c':
            if (op.Length < 3) {
              Console.WriteLine("Missing order item initializer.");
            }
            else {
              try {
                order.AddItem(op.Substring(2));
                Console.WriteLine("Item added.");
              }
              catch (Exception e) {
                Console.Write($"Error: {e.Message}\n");
              }
            }

            break;
          // delete
          case 'd':
            if (op.Length < 3) {
              Console.WriteLine("Missing item selector.");
            }
            else {
              order.RemoveItem(op.Substring(2));
              Console.WriteLine("Related items removed.");
            }

            break;
          // list all
          case 'a':
            Console.Write(order.Table());
            break;
          case 'q':
            Console.WriteLine("Exit order editor.");
            return;
          default:
            Console.WriteLine("Bad operation.");
            break;
        }
      }
    }

    public static void run() {
      var current = new List<Order>();
      var service = new OrderService();
      Console.WriteLine("Order Administration System.");

      while (true) {
        Console.Write("S>> ");
        Console.Out.Flush();
        var op = Console.ReadLine();
        if (op.Length == 0) {
          continue;
        }

        switch (op[0]) {
          // list
          case 'l':
            if (current.Count == 0) {
              Console.WriteLine("No selected order.");
            }
            else {
              Console.WriteLine("Selected orders:");
              current.ForEach(x => Console.Write(x.Table()));
            }

            break;
          // list all
          case 'a':
            Console.WriteLine("All orders:");
            service.ForEach(x => Console.Write(x.Table()));
            break;
          //create
          case 'c':
            if (op.Length < 3) {
              Console.WriteLine("Missing customer");
            }
            else {
              current.Clear();
              var o = new Order(op.Substring(2));
              Console.WriteLine("New order created.");
              editOrder(ref o);
              service.Add(o);
            }

            break;
          // read
          case 'r':
            if (op.Length < 3) {
              Console.WriteLine("Missing query statement");
            }
            else {
              try {
                current = service.Query(op.Substring(2)).ToList();
                Console.WriteLine(current.Count == 0 ? "No order found." : "Query executed.");
              }
              catch (Exception e) {
                Console.Write($"Error: {e.Message}\n");
              }
            }

            break;
          // update
          case 'u':
            if (op.Length < 3) {
              Console.WriteLine("Missing order id");
            }
            else {
              current.Clear();
              service.Get(op.Substring(2), out var o, out var i);
              if (i == -1) {
                Console.WriteLine("No satisfied order.");
              }
              else {
                editOrder(ref o);
                try {
                  service.Update(o, i);
                  Console.WriteLine("Order updated");
                }
                catch (Exception e) {
                  Console.Write($"Error: {e.Message}\n");
                }
              }
            }

            break;
          // delete
          case 'd':
            service.Delete(current);
            Console.WriteLine("Related order deleted.");
            current.Clear();
            break;
          default:
            Console.WriteLine("Bad operation.");
            break;
        }
      }
    }
  }
}