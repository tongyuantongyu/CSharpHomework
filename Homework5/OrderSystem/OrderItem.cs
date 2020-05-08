using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;
using System.IO;
using System.Security.Policy;

namespace OrderSystem {
  [Serializable]
  public class OrderItem {
    private double _amount;

    private double _price;

    public Order Order { get; set; }
    public string OrderId { get; set; }

    public OrderItem(string initializer) {
      var parameters = initializer.Split(' ');
      if (parameters.Length < 2) {
        throw new InvalidDataException("Bad initializer");
      }

      Name = parameters[0];
      if (!double.TryParse(parameters[1], out var price)) {
        throw new InvalidDataException("Invalid price");
      }

      Price = price;
      var amount = 1;
      if (parameters.Length > 2) {
        if (!int.TryParse(parameters[2], out amount)) {
          throw new InvalidDataException("Invalid amount");
        }
      }

      Amount = amount;
    }

    public OrderItem() {}

    [Required]
    public string Name { get; set; }

    [Required]
    public double Price {
      get => _price;
      set {
        if (value > 0) {
          _price = value;
        }
        else {
          throw new InvalidDataException("Price can't be negative");
        }
      }
    }

    [Required]
    public double Amount {
      get => _amount;
      set {
        if (value > 0) {
          _amount = value;
        }
        else {
          throw new InvalidDataException("Amount can't be negative");
        }
      }
    }

    [NotMapped]
    public double Total => Price * Amount;

    public string TableItem() {
      var name = Name.Length > 20 ? Name.Substring(0, 17) + "..." : Name;
      var price = $"{Price:0.00}";
      var amount = $"{Amount:0.00}";
      var total = $"{Total:0.00}";
      return $"{name,-20} {price,8} {amount,8} {total,12}";
    }

    public override string ToString() {
      return $"OrderItem<Name={Name},Price={Price:0.00},Amount={Amount:0.00}>";
    }

    public override bool Equals(object obj) {
      if (obj is OrderItem item)
        // items with same name are considered equal and should be collapsed
      {
        return Name == item.Name;
      }

      return base.Equals(obj);
    }

    public override int GetHashCode() {
      return (Name, Price).GetHashCode();
    }

    public static OrderItem operator +(OrderItem a, OrderItem b) {
      if (a.Name != b.Name || a.Price != b.Price) {
        throw new InvalidOperationException("Incompatible items.");
      }

      a.Amount += b.Amount;
      return a;
    }
  }
}