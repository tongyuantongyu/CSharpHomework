using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderGUI {
  public partial class QueryWindow : Form {
    private readonly BindingList<QueryItem> querys = new BindingList<QueryItem>();

    public string QueryString => querys.Count == 0 ? "*" : string.Join(",", querys.Select(x => x.Query));

    public QueryWindow() {
      InitializeComponent();
      queryList.DataSource = querys;
      queryList.DisplayMember = "Query";
      buttonAppend.DataBindings.Add("Enabled", this, "EnableAppend");
      buttonDown.DataBindings.Add("Enabled", this, "EnableDown");
      buttonUp.DataBindings.Add("Enabled", this, "EnableUp");
      buttonRemove.DataBindings.Add("Enabled", this, "EnableRemove");
      radioID.Checked = true;
      buttonOK.DialogResult = DialogResult.OK;
    }

    public bool EnableAppend =>
    radioID.Checked && !string.IsNullOrWhiteSpace(condID.Text) ||
    radioCustomer.Checked && !string.IsNullOrWhiteSpace(condCustomer.Text) ||
    radioTotal.Checked && !string.IsNullOrWhiteSpace(condPrice.Text) ||
    radioItemName.Checked && !string.IsNullOrWhiteSpace(condItem.Text);

  public bool EnableRemove => queryList.SelectedIndex != -1;

  public bool EnableDown => queryList.SelectedIndex != querys.Count - 1;

  public bool EnableUp => queryList.SelectedIndex > 1;

  // private void condID_KeyUp(object sender, KeyEventArgs e) {
  //     if (radioID.Checked) {
  //       buttonAppend.Enabled = !string.IsNullOrWhiteSpace(condID.Text);
  //     }
  //   }
  //
  //   private void condCustomer_KeyUp(object sender, KeyEventArgs e) {
  //     if (radioCustomer.Checked) {
  //       buttonAppend.Enabled = !string.IsNullOrWhiteSpace(condCustomer.Text);
  //     }
  //   }
  //
  //   private void condPrice_KeyUp(object sender, KeyEventArgs e) {
  //     if (radioTotal.Checked) {
  //       buttonAppend.Enabled = !string.IsNullOrWhiteSpace(condPrice.Text);
  //     }
  //   }
  //
  //   private void condItem_KeyUp(object sender, KeyEventArgs e) {
  //     if (radioItemName.Checked) {
  //       buttonAppend.Enabled = !string.IsNullOrWhiteSpace(condItem.Text);
  //     }
  //   }

    private void buttonAppend_Click(object sender, EventArgs e) {
      if (radioID.Checked) {
        querys.Add(new QueryItem {
          Type = "id",
          Condition = condID.Text
        });
      } else if (radioCustomer.Checked) {
        querys.Add(new QueryItem {
          Type = "customer",
          Condition = condCustomer.Text
        });
      } else if (radioTotal.Checked) {
        querys.Add(new QueryItem {
          Type = "price",
          Condition = condPrice.Text
        });
      } else if (radioItemName.Checked) {
        querys.Add(new QueryItem {
          Type = "name",
          Condition = condItem.Text
        });
      }
    }

    private void buttonOK_Click(object sender, EventArgs e) {
      Close();
    }
  }

  internal class QueryItem {
    public string Type { get; set; }
    public string Condition { get; set; }
    public string Query => $"{Type}:{Condition}";
  }
}
