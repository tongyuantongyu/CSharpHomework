using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using OrderSystem;
using System.Windows.Forms;

namespace OrderGUI {
  public partial class MainWindow : Form {
    private readonly DBOrderService service;
    private readonly BindingSource current = new BindingSource();
    public MainWindow() {
      InitializeComponent();
      service = new DBOrderService();
      // var o = new Order("cus");
      // o.AddItem(new OrderItem("s 1 1"));
      // service.Add(o);
      allView.AutoGenerateColumns = false;
      allView.DataSource = service.db.OrderList.Local;
      allView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      var allColID = new DataGridViewTextBoxColumn {
        DisplayIndex = 0,
        ReadOnly = true,
        DataPropertyName = "ID",
        HeaderText = "OrderID"
      };
      allView.Columns.Add(allColID);
      var allColCName = new DataGridViewTextBoxColumn {
        DisplayIndex = 1,
        DataPropertyName = "Customer",
        HeaderText = "CustomerName"
      };
      allView.Columns.Add(allColCName);
      var allColTotal = new DataGridViewTextBoxColumn {
        DisplayIndex = 2,
        ReadOnly = true,
        DataPropertyName = "Total",
        HeaderText = "Total"
      };
      allView.Columns.Add(allColTotal);

      // current.DataSource = new List<Order>();
      currentView.AutoGenerateColumns = false;
      current.DataSource = new List<Order>();
      currentView.DataSource = current;
      currentView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      var curColID = new DataGridViewTextBoxColumn {
        DisplayIndex = 0,
        ReadOnly = true,
        DataPropertyName = "ID",
        HeaderText = "OrderID"
      };
      currentView.Columns.Add(curColID);
      var curColCName = new DataGridViewTextBoxColumn {
        DisplayIndex = 1,
        DataPropertyName = "Customer",
        HeaderText = "CustomerName"
      };
      currentView.Columns.Add(curColCName);
      var curColTotal = new DataGridViewTextBoxColumn {
        DisplayIndex = 2,
        ReadOnly = true,
        DataPropertyName = "Total",
        HeaderText = "Total"
      };
      currentView.Columns.Add(curColTotal);
      ActiveControl = operationInput;
      statusLabel.Text = "Ready.";
    }

    private void ProcessOperation(string op) {
            switch (op[0]) {
        //create
        case 'c':
          if (op.Length < 3) {
            statusLabel.Text = "Missing customer";
          }
          else {
            current.Clear();
            var o = new Order(op.Substring(2));
            statusLabel.Text = "New order created.";
            var editor = new OrderItemWindow(o, service);
            if (editor.ShowDialog() == DialogResult.OK) {
              service.Add(o);
            };
            RefreshAllView();
          }

          break;
        // read
        case 'r':
          if (op.Length < 3) {
            statusLabel.Text = "Missing query statement";
          }
          else {
            try {
              current.DataSource = service.Query(op.Substring(2)).ToList();
              statusLabel.Text = current.Count == 0 ? "No order found." : "Query executed.";
            }
            catch (Exception exp) {
              statusLabel.Text = $"Error: {exp.Message}";
            }
          }

          break;
        // update
        case 'u':
          if (op.Length < 3) {
            statusLabel.Text = "Missing order id";
          }
          else {
            current.Clear();
            service.Get(op.Substring(2), out var o, out var i);
            if (i == -1) {
              statusLabel.Text = "No satisfied order.";
            }
            else {
              var editor = new OrderItemWindow(o, service);
              editor.ShowDialog();
              // if (editor.ShowDialog() != DialogResult.OK) {
              //   return;
              // }
              try {
                service.Update(o, i);
                statusLabel.Text = "Order updated";
              }
              catch (Exception exp) {
                statusLabel.Text = $"Error: {exp.Message}";
              }
            }
          }

          break;
        // delete
        case 'd':
          service.Delete((List<Order>)current.DataSource);
          statusLabel.Text = "Related order deleted.";
          current.Clear();
          break;
        case 'e':
          service.Export(op.Substring(2));
          break;
        default:
          statusLabel.Text = "Bad operation.";
          break;
      }
    }

    private void RefreshAllView() {
      // allView.DataSource = typeof(List<Order>);
      // allView.DataSource = service.Orders;
    }

    private void allView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
      operationInput.Text = $"r id:{allView.Rows[e.RowIndex].Cells[0].Value}";
      ActiveControl = operationInput;
    }

    private void operationInput_KeyUp(object sender, KeyEventArgs e) {
      if (e.KeyCode != Keys.Enter) {
        return;
      }
      var op = operationInput.Text;
      if (string.IsNullOrEmpty(op)) {
        return;
      }

      ProcessOperation(op);
      operationInput.Text = "";
      RefreshAllView();
    }

    private void buttonCreate_Click(object sender, EventArgs e) {
      var input = new SimpleDialog("Create Order", "Input customer name:");
      if (input.ShowDialog() == DialogResult.OK) {
        ProcessOperation($"c {input.InputValue}");
      }
      ActiveControl = operationInput;
      RefreshAllView();
    }

    private void buttonDelete_Click(object sender, EventArgs e) {
      ProcessOperation("d");
      ActiveControl = operationInput;
      RefreshAllView();
    }

    private void buttonUpdate_Click(object sender, EventArgs e) {
      var input = new SimpleDialog("Select Order", "Input ID prefix of Order to edit:");
      if (input.ShowDialog() == DialogResult.OK) {
        ProcessOperation($"u {input.InputValue}");
      }
      ActiveControl = operationInput;
      RefreshAllView();
    }

    private void buttonQuery_Click(object sender, EventArgs e) {
      var input = new QueryWindow();
      if (input.ShowDialog() == DialogResult.OK) {
        ProcessOperation($"r {input.QueryString}");
      }
      ActiveControl = operationInput;
      RefreshAllView();
    }

    private void currentView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
      ProcessOperation($"u {allView.Rows[e.RowIndex].Cells[0].Value}");
      ActiveControl = operationInput;
      RefreshAllView();
    }

    private void buttonImport_Click(object sender, EventArgs e) {
      var file = new OpenFileDialog {
        CheckFileExists = true,
        Filter = "XML File|*.xml|All Files|*.*",
        FilterIndex = 0
      };
      if (file.ShowDialog() == DialogResult.OK) {
        service.Import(file.FileName);
      }
      RefreshAllView();
    }

    private void buttonExport_Click(object sender, EventArgs e) {
      var file = new SaveFileDialog {
        CheckFileExists = false,
        Filter = "XML File|*.xml|All Files|*.*",
        FilterIndex = 0
      };
      if (file.ShowDialog() == DialogResult.OK) {
        service.Export(file.FileName);
      }
    }
  }
}