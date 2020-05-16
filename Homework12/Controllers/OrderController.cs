using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Homework12.Controllers {
  [ApiController]
  [Route("api/[controller]")]
  public class OrderController : ControllerBase {

    private readonly ILogger<OrderController> _logger;
    private readonly OrderContext _db;

    public OrderController(ILogger<OrderController> logger, OrderContext db) {
      _logger = logger;
      _db = db;
    }

    // POST: api/order/create
    [HttpPost("create")]
    public async Task<ActionResult<Order>> CreateOrder(Order order) {
      try {
        order.Id = Order.genID();
        order.Items.ForEach(item => item.OrderId = order.Id);
        await _db.Orders.AddAsync(order);
        await _db.OrderItems.AddRangeAsync(order.Items);
        await _db.SaveChangesAsync();
      }
      catch (Exception e) {
        return BadRequest(e.InnerException?.Message ?? e.Message);
      }

      return order;
    }

    // DELETE: api/order/delete/{id}
    [HttpDelete("delete/{id}")]
    public ActionResult DeleteOrder(string id) {
      var order = _db.Orders.Find(id);
      if (order == null) {
        return NotFound();
      }
      order.Items = _db.OrderItems.Where(item => item.OrderId == order.Id).ToList();
      _db.OrderItems.RemoveRange(order.Items);
      _db.Orders.Remove(order);
      _db.SaveChanges();
      return Ok();
    }

    // POST: api/order/update
    [HttpPost("update")]
    public async Task<ActionResult<Order>> UpdateOrder(Order order) {
      if (string.IsNullOrWhiteSpace(order.Id)) {
        return BadRequest("Missing Id.");
      }

      try {
        var current = _db.Orders.Find(order.Id);
        if (current == null) {
          return NotFound();
        }
        current.Items = _db.OrderItems.Where(item => item.OrderId == current.Id).ToList();
        _db.OrderItems.RemoveRange(current.Items);
        _db.Orders.Remove(current);
        _db.SaveChanges();
        order.Items.ForEach(item => item.OrderId = order.Id);
        await _db.Orders.AddAsync(order);
        await _db.OrderItems.AddRangeAsync(order.Items);
        await _db.SaveChangesAsync();
      }
      catch (Exception e) {
        return BadRequest(e.InnerException?.Message ?? e.Message);
      }

      return order;
    }

    [HttpGet("find")]
    public ActionResult<List<Order>> FindOrders(string query) {
      IEnumerable<Order> e = _db.Orders;

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
            static double GetTotal(Order order) {
              return order.Items.Select(item => item.Price * item.Amount).Sum();
            }
            if (double.TryParse(condition, out var number)) {
              e = e.Where(x => Math.Abs(GetTotal(x) - number) < 0.01);
            }
            else if (condition.Length > 1 && double.TryParse(condition.Substring(1), out var number2)) {
              e = condition.Substring(0, 2) switch {
                "lt" => e.Where(x => GetTotal(x) < number2),
                "gt" => e.Where(x => GetTotal(x) > number2),
                _ => throw new InvalidOperationException("Bad query term."),
              };
            }
            else if (condition.Length > 2 && double.TryParse(condition.Substring(2), out var number3)) {
              e = condition.Substring(0, 2) switch {
                "leq" => e.Where(x => GetTotal(x) <= number3),
                "geq" => e.Where(x => GetTotal(x) >= number3),
                _ => throw new InvalidOperationException("Bad query term.")
              };
            }
            else {
              throw new InvalidOperationException("Bad query term.");
            }

            break;
          case "good":
            e = e.Where(x => x.Items.Exists(y => y.Name.Contains(condition)));
            break;
          default:
            throw new InvalidOperationException("Bad query term.");
        }
      }

      var result = e.ToList();
      result.ForEach(order => order.Items = _db.OrderItems.Where(item => item.OrderId == order.Id).ToList());
      return result;
    }

  }
}
