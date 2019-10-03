using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHDesktopUI
{
    public static class TableLayoutHelper
    {
        public static void ClearTable(TableLayoutPanel panel)
        {
            panel.Controls.Clear();
            panel.RowStyles.Clear();

            panel.RowCount = 1;
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panel.Controls.Add(new Label() { Text = "ID", Font = new Font("Century Gothic", 12, FontStyle.Bold), ForeColor = Color.LightGray }, 0, panel.RowCount - 1);
            panel.Controls.Add(new Label() { Text = "NAME", Font = new Font("Century Gothic", 12, FontStyle.Bold), ForeColor = Color.LightGray }, 1, panel.RowCount - 1);
            panel.Controls.Add(new Label() { Text = "Actions", Font = new Font("Century Gothic", 12, FontStyle.Bold), ForeColor = Color.LightGray }, 2, panel.RowCount - 1);
            panel.Controls.Add(new Label() { Text = "", Font = new Font("Century Gothic", 12, FontStyle.Bold), ForeColor = Color.LightGray }, 3, panel.RowCount - 1);
        }


        public static void RemoveArbitraryRow(TableLayoutPanel panel, int rowIndex)
        {
            if (rowIndex >= panel.RowCount)
            {
                return;
            }

            // delete all controls of row that we want to delete
            for (int i = 0; i < panel.ColumnCount; i++)
            {
                var control = panel.GetControlFromPosition(i, rowIndex);
                panel.Controls.Remove(control);
            }

            // move up row controls that comes after row we want to remove
            //for (int i = rowIndex + 1; i < panel.RowCount; i++)
            //{
            //    for (int j = 0; j < panel.ColumnCount; j++)
            //    {
            //        var control = panel.GetControlFromPosition(j, i);
            //        if (control != null)
            //        {
            //            panel.SetRow(control, i - 1);
            //        }
            //    }
            //}

            //var removeStyle = panel.RowCount - 1;

            //if (panel.RowStyles.Count > removeStyle)
            //    panel.RowStyles.RemoveAt(removeStyle);

            //panel.RowCount--;
        }
    }
}
