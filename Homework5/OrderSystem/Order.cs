using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderSystem {
  public class Order : IComparable<Order> {
    private static int count;

    public readonly string Customer;
    public readonly string ID;
    private List<OrderItem> items;

    public Order(string customer) {
      Customer = customer;
      ID = genID();
      items = new List<OrderItem>();
    }

    public double Total => items.ConvertAll(x => x.Total).Sum();

    public int CompareTo(Order other) {
      return string.Compare(ID, other.ID, StringComparison.Ordinal);
    }

    private static string genID() {
      var tmp = new StringBuilder(12);
      foreach (var b in BitConverter.GetBytes(DateTime.Now.ToFileTime())) tmp.AppendFormat("{0:x2}", b);
      foreach (var b in BitConverter.GetBytes(count)) tmp.AppendFormat("{0:x2}", b);

      count++;
      return tmp.ToString();
    }

    public void AddItem(string initializer) {
      var item = new OrderItem(initializer);
      var index = items.FindIndex(x => x.Equals(item));
      if (index == -1) {
        items.Add(item);
      }
      else {
        items[index] += item;
      }
    }

    public bool HasItem(Predicate<OrderItem> predicate) {
      return items.Exists(predicate);
    }

    public void RemoveItem(string namePrefix) {
      items = items.Where(x => !x.Name.StartsWith(namePrefix)).ToList();
    }

    public override string ToString() {
      return $"Order<ID={ID},Customer={Customer}>";
    }

    public override int GetHashCode() {
      return ID.GetHashCode();
    }

    public override bool Equals(object obj) {
      if (obj is Order order) {
        return ID == order.ID;
      }

      return base.Equals(obj);
    }

    public string Table() {
      var tmp = new StringBuilder($"Order #{ID} Customer: {Customer}\n");
      if (items.Count == 0) {
        tmp.Append("Empty Order.");
        return tmp.ToString();
      }

      tmp.AppendFormat("{0,-20} {1,8} {2,8} {3,12}\n", "Name", "Price", "Amount", "Total");
      items.ForEach(x => tmp.AppendLine(x.TableItem()));
      tmp.AppendLine($"Total Price: {Total:0.00}");
      return tmp.ToString();
    }
  }
}