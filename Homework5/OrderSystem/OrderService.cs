﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OrderSystem {
  internal class OrderService {
    private List<Order> orders = new List<Order>();

    public void Add(Order order) {
      if (orders.Exists(x => x.Equals(order))) {
        throw new InvalidDataException("Order already exist.");
      }

      orders.Add(order);
    }

    public IEnumerable<Order> Query(string query) {
      var e = orders.AsEnumerable();
      if (e == null) {
        return Enumerable.Empty<Order>();
      }

      foreach (var term in query.Split(',').AsEnumerable().Select(x => x.Split(':'))) {
        if (term[0] == "*" && term.Length == 1) {
          return e;
        }
        if (term.Length != 2) {
          throw new InvalidOperationException("Bad query term.");
        }

        var field = term[0];
        var condition = term[1];

        switch (field) {
          case "id":
            e = e.Where(x => x.ID.StartsWith(condition));
            break;
          case "customer":
            e = e.Where(x => x.Customer == condition);
            break;
          case "price":
            if (double.TryParse(condition, out var number)) {
              e = e.Where(x => Math.Abs(x.Total - number) < 0.01);
            }
            else if (condition.Length > 1 && double.TryParse(condition.Substring(1), out var number2)) {
              switch (condition[0]) {
                case '<':
                  e = e.Where(x => x.Total < number2);
                  break;
                case '>':
                  e = e.Where(x => x.Total > number2);
                  break;
                default:
                  throw new InvalidOperationException("Bad query term.");
              }
            }
            else if (condition.Length > 2 && double.TryParse(condition.Substring(2), out var number3)) {
              switch (condition.Substring(0, 2)) {
                case "<=":
                  e = e.Where(x => x.Total <= number3);
                  break;
                case ">=":
                  e = e.Where(x => x.Total >= number3);
                  break;
                default:
                  throw new InvalidOperationException("Bad query term.");
              }
            }
            else {
              throw new InvalidOperationException("Bad query term.");
            }

            break;
          case "good":
            e = e.Where(x => x.HasItem(y => y.Name.Contains(condition)));
            break;
          default:
            throw new InvalidOperationException("Bad query term.");
        }
      }

      return e;
    }

    public void Delete(IEnumerable<Order> items) {
      orders = orders.Except(items).ToList();
    }

    public void Get(string idPrefix, out Order order, out int index) {
      index = orders.FindIndex(x => x.ID.StartsWith(idPrefix));
      order = index != -1 ? orders[index] : null;
    }

    public void Update(Order order, int index) {
      if (index > orders.Count) {
        throw new IndexOutOfRangeException();
      }

      if (orders[index].ID != order.ID && orders.Exists(x => x.ID == order.ID)) {
        throw new InvalidOperationException("Can't duplicate order.");
      }

      orders[index] = order;
    }

    public void ForEach(Action<Order> f) {
      orders.ForEach(f);
    }

    public IEnumerable<Order> Sorted() {
      var tmp = orders.ToList();
      tmp.Sort();
      return tmp;
    }

    public IEnumerable<Order> Sorted(IComparer<Order> ic) {
      var tmp = orders.ToList();
      tmp.Sort(ic);
      return tmp;
    }

    public IEnumerable<Order> Sorted(Comparison<Order> f) {
      var tmp = orders.ToList();
      tmp.Sort(f);
      return tmp;
    }
  }
}