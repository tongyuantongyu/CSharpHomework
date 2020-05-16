using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12.Models {
  public class Order {
    private static int count;

    [Required]
    public string Customer { get; set; }
    [Key, Column(Order = 1)]
    public string Id { get; set; }
    public List<OrderItem> Items { get; set; }

    public static string genID() {
      var tmp = new StringBuilder(12);
      foreach (var b in BitConverter.GetBytes(DateTime.Now.ToFileTime())) tmp.AppendFormat("{0:x2}", b);
      foreach (var b in BitConverter.GetBytes(count)) tmp.AppendFormat("{0:x2}", b);

      count++;
      return tmp.ToString();
    }
  }
}
