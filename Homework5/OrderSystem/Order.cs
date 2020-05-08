using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OrderSystem {
  [Serializable]
  public class Order : IComparable<Order> {
    private static int count;

    [Required]
    public string Customer { get; set; }
    [Key, Column(Order = 1)]
    public string Id { get; set; }

    public List<OrderItem> Items { get; set; } = new List<OrderItem>();

    public Order(string customer) {
      Customer = customer;
      Id = genID();
    }

    public Order() {}

    [NotMapped]
    public double Total {
      get {
        return Items.Select(item => item.Total).Sum();
      }
    }

    public int CompareTo(Order other) {
      return string.Compare(Id, other.Id, StringComparison.Ordinal);
    }

    private static string genID() {
      var tmp = new StringBuilder(12);
      foreach (var b in BitConverter.GetBytes(DateTime.Now.ToFileTime())) tmp.AppendFormat("{0:x2}", b);
      foreach (var b in BitConverter.GetBytes(count)) tmp.AppendFormat("{0:x2}", b);

      count++;
      return tmp.ToString();
    }

    [Obsolete("Use AddItem with OrderItem instance instead.")]
    public void AddItem(string initializer) {
      var item = new OrderItem(initializer);
      var index = Items.FindIndex(x => x.Equals(item));
      if (index == -1) {
        Items.Add(item);
      }
      else {
        Items[index] += item;
      }
    }

    public void AddItem(OrderItem item) {
      var index = Items.FindIndex(x => x.Equals(item));
      if (index == -1) {
        Items.Add(item);
      }
      else {
        Items[index] += item;
      }
    }

    public bool HasItem(Predicate<OrderItem> predicate) {
      return Items.Exists(predicate);
    }

    public void RemoveItem(string namePrefix) {
      Items = Items.Where(x => !x.Name.StartsWith(namePrefix)).ToList();
    }

    public override string ToString() {
      return $"Order<ID={Id},Customer={Customer}>";
    }

    public override int GetHashCode() {
      return Id.GetHashCode();
    }

    public override bool Equals(object obj) {
      if (obj is Order order) {
        return Id == order.Id;
      }

      return base.Equals(obj);
    }

    public string Table() {
      var tmp = new StringBuilder($"Order #{Id} Customer: {Customer}\n");
      if (Items.Count == 0) {
        tmp.Append("Empty Order.");
        return tmp.ToString();
      }

      tmp.AppendFormat("{0,-20} {1,8} {2,8} {3,12}\n", "Name", "Price", "Amount", "Total");
      Items.ForEach(x => tmp.AppendLine(x.TableItem()));
      tmp.AppendLine($"Total Price: {Total:0.00}");
      return tmp.ToString();
    }
  }
}