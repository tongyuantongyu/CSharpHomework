using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Serialization;

namespace OrderSystem {
  public class DBOrderService : IDisposable {
    private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(List<Order>));
    public OrderModel db;

    public DBOrderService() {
      db = new OrderModel();
    }

    public void Dispose() {
      db.Dispose();
    }

    public void Add(Order order) {
      if (db.OrderList.Any(o => o.Id.Equals(order.Id))) {
        throw new InvalidDataException("Order already exist.");
      }

      db.OrderList.Add(order);
    }

    public IEnumerable<Order> Query(string query) {
      IEnumerable<Order> e = db.OrderList;
      if (e == null) {
        return Enumerable.Empty<Order>();
      }

      foreach (var term in query.Split(',').AsEnumerable().Select(x => x.Split(':'))) {
        if (term[0] == "*" && term.Length == 1) {
          continue;
        }
        if (term.Length != 2) {
          throw new InvalidOperationException("Bad query term.");
        }

        var field = term[0];
        var condition = term[1];

        switch (field) {
          case "id":
            e = e.Where(x => x.Id.StartsWith(condition));
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
      db.OrderList.RemoveRange(items);
    }

    public void Get(string idPrefix, out Order order, out int index) {
      var tmp = db.OrderList.Local.ToList();
      index = tmp.FindIndex(x => x.Id.StartsWith(idPrefix));
      order = index != -1 ? tmp[index] : null;
    }

    public void Update(Order order, int index) {
      if (index > db.OrderList.Local.Count) {
        throw new IndexOutOfRangeException();
      }

      if (db.OrderList.Local[index].Id != order.Id && db.OrderList.Any(x => x.Id == order.Id)) {
        throw new InvalidOperationException("Can't duplicate order.");
      }

      db.OrderList.Local[index] = order;
    }

    public void ForEach(Action<Order> f) {
      foreach (var order in db.OrderList) {
        f(order);
      }
    }

    public IEnumerable<Order> Sorted() {
      var tmp = db.OrderList.OrderBy(o => o.Id);
      return tmp;
    }

    public IEnumerable<Order> Sorted<T>(Func<Order, T> keySelector) {
      var tmp = db.OrderList.OrderBy(keySelector);
      return tmp;
    }

    private static void AttachOrder(ref Order order, ref OrderItem item) {
      item.Order = order;
      item.OrderId = order.Id;
    }

    public IEnumerable<OrderItem> GetItem(Order order) {
      return db.ItemList.Local.ToBindingList().Where(item => item.OrderId == order.Id);
    }

    public void AddItem(Order order, OrderItem item) {
      AttachOrder(ref order, ref item);
      var index = order.Items.FindIndex(x => x.Equals(item));
      if (index == -1) {
        order.Items.Add(item);
        db.ItemList.Add(item);
      }
      else {
        db.ItemList.Remove(order.Items[index]);
        order.Items[index] += item;
        db.ItemList.Add(order.Items[index]);
      }
    }

    public bool HasItem(Order order, Predicate<OrderItem> predicate) {
      return db.ItemList.Any(item => item.OrderId == order.Id && predicate(item));
    }

    public void RemoveItem(Order order, string namePrefix) {
      db.ItemList.RemoveRange(db.ItemList.Where(x => !x.Name.StartsWith(namePrefix)));
    }

    // public IEnumerable<Order> Sorted(Comparison<Order> f) {
    //   var tmp = orders.ToList();
    //   tmp.Sort(f);
    //   return tmp;
    // }

    public void Export(string filename) {
      using (var w = new StreamWriter(filename)) {
        Serializer.Serialize(w, db.OrderList);
      }
    }

    public void Import(string filename) {
      List<Order> orderTemp;
      using (var r = new StreamReader(filename)) {
        orderTemp = Serializer.Deserialize(r) as List<Order>;
      }

      orderTemp?.ForEach(Add);
    }
  }
}