﻿using System;
using System.IO;

namespace OrderSystem {
  public class OrderItem {
    private double _amount;

    private double _price;

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

    public string Name { get; }

    private double Price {
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

    private double Amount {
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

    public double Total => Price * Amount;

    public string TableItem() {
      var name = Name.Length > 20 ? Name.Substring(0, 17) + "..." : Name;
      var price = $"{Price:0.00}";
      var amount = $"{Amount}";
      var total = $"{Total:0.00}";
      return $"{name,-20} {price,8} {amount,8} {total,12}";
    }

    public override string ToString() {
      return $"OrderItem<Name={Name},Price={Price},Amount={Amount}>";
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
      return ToString().GetHashCode();
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