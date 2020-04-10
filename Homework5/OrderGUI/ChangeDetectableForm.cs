using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OrderGUI {
  [Obsolete("Unused.")]
  public abstract class ChangeDetectableForm : Form {
    protected ChangeDetectableForm(string querySelector) {
      // FormType#FormName.FormTag
      var selectorStrings = querySelector.Split(new[] {",", ", "}, StringSplitOptions.None);
      var selectors = selectorStrings.Select(s => new Selector(s)).ToList();
      foreach (Control control in Controls) {
        foreach (var selector in selectors) {
          if (selector.Match(control)) {
            var ev = control.GetType().GetEvent(selector.Event, BindingFlags.FlattenHierarchy);
            ev?.AddEventHandler(control, Delegate.CreateDelegate(ev.EventHandlerType, control, GetType().GetMethod("Refresher") ?? throw new InvalidOperationException()));
          }
        }
      }
    }

    protected abstract void Refresher(object o, EventArgs e);
  }

  public class Selector {
    public readonly string Event;
    private string Type = "";
    private List<string> Name = new List<string>();
    private List<string> Tag = new List<string>();

    public Selector(string query) {
      var t = query.Split(':');
      Event = t[0];
      var selector = t[1];
      var status = 0;
      var temp = "";
      foreach (var c in selector) {
        switch (c) {
          case '#':
            AddRestrict(temp, status);
            temp = "";
            status = 1;
            break;
          case '.':
            AddRestrict(temp, status);
            temp = "";
            status = 2;
            break;
          case ' ':
            break;
          default:
            temp += c;
            break;
        }
      }

      if (!string.IsNullOrWhiteSpace(temp)) {
        AddRestrict(temp, status);
      }
    }

    private void AddRestrict(string temp, int status) {
      switch (status) {
        case 0:
          Type = temp;
          break;
        case 1:
          Name.Add(temp);
          break;
        case 2:
          Tag.Add(temp);
          break;
      }
    }

    public bool Match(Control control) {
      return (string.IsNullOrWhiteSpace(Type) || control.GetType().Name == Type) &&
             control.GetType().GetEvent(Event, BindingFlags.FlattenHierarchy) != null &&
             !Name.Distinct().Except(control.Name.Split(' ')).Any() &&
             !(control.Tag is string tag && Tag.Distinct().Except(tag.Split(' ')).Any());
    }
  }
}