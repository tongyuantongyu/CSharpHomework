using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using OrderSystem;

namespace OrderGUI {
  public sealed partial class OrderItemWindow : Form {
    private readonly BindingSource itemsList = new BindingSource();
    private readonly Order order;
    private OrderItemWindow() {
      InitializeComponent();
    }

    public OrderItemWindow(Order o) : this() {
      order = o;
      Text = $"Edit Order: ID={o.Id}, Customer={o.Customer}";
      itemsList.DataSource = order.Items;
      itemsView.AutoGenerateColumns = false;
      itemsView.DataSource = itemsList;
      itemsView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      var itemColName = new DataGridViewTextBoxColumn {
        DisplayIndex = 0,
        DataPropertyName = "Name",
        HeaderText = "ItemName"
      };
      itemsView.Columns.Add(itemColName);
      var itemColPrice = new DataGridViewTextBoxColumn {
        DisplayIndex = 1,
        DataPropertyName = "Price",
        HeaderText = "Price"
      };
      itemsView.Columns.Add(itemColPrice);
      var itemColAmount = new DataGridViewTextBoxColumn {
        DisplayIndex = 2,
        DataPropertyName = "Amount",
        HeaderText = "Amount"
      };
      itemsView.Columns.Add(itemColAmount);
      var itemColTotal = new DataGridViewTextBoxColumn {
        DisplayIndex = 3,
        ReadOnly = false,
        DataPropertyName = "Total",
        HeaderText = "Total"
      };
      itemsView.Columns.Add(itemColTotal);
      ActiveControl = operationInput;
      buttonCommit.DialogResult = DialogResult.OK;
      statusLabel.Text = "Ready.";
    }

    private void buttonCommit_Click(object sender, EventArgs e) {
      Close();
    }

    private void ProcessOperation(string op) {
      switch (op[0]) {
        // create
        case 'c':
          if (op.Length < 3) {
            statusLabel.Text = "Missing order item initializer.";
          }
          else {
            try {
              order.AddItem(new OrderItem(op.Substring(2)));
              statusLabel.Text = "Item added.";
            }
            catch (Exception exc) {
              statusLabel.Text = $"Error: {exc.Message}";
            }
          }

          break;
        // delete
        case 'd':
          if (op.Length < 3) {
            statusLabel.Text = "Missing item selector.";
          }
          else {
            order.RemoveItem(op.Substring(2));
            statusLabel.Text = "Related items removed.";
          }

          break;
        case 'q':
          Close();
          return;
        default:
          statusLabel.Text = "Bad operation.";
          break;
      }
    }

    private void operationInput_KeyUp(object sender, KeyEventArgs e) {
      if (e.KeyCode != Keys.Enter) {
        return;
      }
      var op = operationInput.Text;
      if (string.IsNullOrEmpty(op)) {
        buttonCommit.PerformClick();
        return;
      }

      ProcessOperation(op);

      operationInput.Text = "";
      itemsList.DataSource = order.Items.ToList();
    }

    private void itemsView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
      ProcessOperation($"d {e.Row.Cells[0].Value}");
    }
  }
}