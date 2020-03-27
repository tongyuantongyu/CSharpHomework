using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable once CheckNamespace
namespace OrderSystem.Tests {
  [TestClass]
  public class OrderServiceTests {
    [TestMethod]
    public void AddTest() {
      var s = OneOrderOrderService(out _);
      Assert.AreEqual(1, s.Orders.Count);
    }

    private static OrderService OneOrderOrderService(out Order o) {
      var s = new OrderService();
      o = new Order("c");
      o.AddItem(new OrderItem("c 1 1"));
      s.Add(o);
      return s;
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidDataException))]
    public void AddTestNoDuplicate() {
      var s = OneOrderOrderService(out var o);
      s.Add(o);
    }

    [TestMethod]
    public void QueryTest() {
      var s = TwoOrderOrderService(out var o, out var firstId);
      var result = s.Query($"id:{o.Id}").ToList();
      Assert.AreEqual(1, result.Count);
      Assert.AreEqual(o.Id, result[0].Id);
      result = s.Query("customer:c").ToList();
      Assert.AreEqual(1, result.Count);
      Assert.AreEqual(firstId, result[0].Id);
      result = s.Query("price:>1.5").ToList();
      Assert.AreEqual(1, result.Count);
      Assert.AreEqual(o.Id, result[0].Id);
      result = s.Query("good:aa").ToList();
      Assert.AreEqual(1, result.Count);
      Assert.AreEqual(o.Id, result[0].Id);
      result = s.Query("*").ToList();
      Assert.AreEqual(2, result.Count);
      result = s.Query($"id:{o.Id.Substring(0, 6)},customer:d,price:>1.5,good:aa").ToList();
      Assert.AreEqual(1, result.Count);
      Assert.AreEqual(o.Id, result[0].Id);
    }

    private static OrderService TwoOrderOrderService(out Order o, out string firstId) {
      var s = new OrderService();
      o = new Order("c");
      o.AddItem(new OrderItem("c 1 1"));
      s.Add(o);
      firstId = o.Id;
      o = new Order("d");
      o.AddItem(new OrderItem("saaa 1 2"));
      s.Add(o);
      return s;
    }

    [TestMethod]
    public void DeleteTest() {
      var s = OneOrderOrderService(out _);
      Assert.AreEqual(1, s.Orders.Count);
      s.Delete(s.Query("*"));
      Assert.AreEqual(0, s.Orders.Count);
    }

    [TestMethod]
    public void GetTest() {
      var s = OneOrderOrderService(out var o);
      s.Get(o.Id.Substring(0, 6), out var order, out var i);
      Assert.AreEqual(0, i);
      Assert.AreEqual(o.Id, order.Id);
    }

    [TestMethod]
    public void UpdateTest() {
      var s = OneOrderOrderService(out var o);
      s.Get(o.Id.Substring(0, 6), out var order, out var i);
      order.Customer = "d";
      s.Update(order, i);
      Assert.AreEqual("d", s.Orders[0].Customer);
    }

    [TestMethod]
    public void ForEachTest() {
      var s = OneOrderOrderService(out var o);
      s.ForEach(_o => Assert.AreEqual("c", _o.Customer));
    }

    [TestMethod]
    public void SortedTest() {
      var s = TwoOrderOrderService(out var o, out var firstId);
      var sorted = s.Sorted().ToList();
      var sortedCostumer = s.Sorted(or=>or.Customer).ToList();
      if (string.Compare(o.Id, firstId, StringComparison.Ordinal) >= 0) {
        Assert.AreEqual(firstId, sorted[0].Id);
        Assert.AreEqual(o.Id, sorted[1].Id);
      }
      else {
        Assert.AreEqual(firstId, sorted[1].Id);
        Assert.AreEqual(o.Id, sorted[0].Id);
      }
      Assert.AreEqual(firstId, sortedCostumer[0].Id);
      Assert.AreEqual(o.Id, sortedCostumer[1].Id);
    }

    [TestMethod]
    public void ImportExportTest() {
      var s = OneOrderOrderService(out var o);
      s.Export($"{Path.GetTempPath()}__order_service_import_export_test_file.xml");
      s.Delete(s.Query("*"));
      s.Import($"{Path.GetTempPath()}__order_service_import_export_test_file.xml");
      Assert.AreEqual(o.Id, s.Orders[0].Id);
    }

    [TestCleanup]
    public void RemoveTempFile() {
      try {
        File.Delete($"{Path.GetTempPath()}__order_service_import_export_test_file.xml");
      }
      catch (FileNotFoundException) { }
    }
  }
}