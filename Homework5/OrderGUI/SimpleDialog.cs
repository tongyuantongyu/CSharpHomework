using System;
using System.Windows.Forms;

namespace OrderGUI {
  public partial class SimpleDialog : Form {
    private SimpleDialog() {
      InitializeComponent();
    }

    public string InputValue => inputBox.Text;

    public SimpleDialog(string title, string hint) : this() {
      Text = title;
      labelHint.Text = hint;
      ActiveControl = inputBox;
      buttonOK.DialogResult = DialogResult.OK;
    }

    private void buttonOK_Click(object sender, EventArgs e) {
      Close();
    }

    private void inputBox_KeyUp(object sender, KeyEventArgs e) {
      if (e.KeyCode == Keys.Enter) {
        buttonOK.PerformClick();
      }
    }
  }
}