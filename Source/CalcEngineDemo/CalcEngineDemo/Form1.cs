using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalcEngineDemo
{
    public partial class Form1 : Form
    {
        DataTable _table;

        public Form1()
        {
            InitializeComponent();

            // create DataTable used as grid storage
            _table = new DataTable();
            for (int c = 0; c < 50; c++)
            {
                var colHeader = DataGridCalc.GetAlphaColumnHeader(c);
                _table.Columns.Add(colHeader.ToString(), typeof(object));
            }
            for (int r = 0; r < 50; r++)
            {
                _table.Rows.Add(_table.NewRow());
            }

            // add some formulas to the table
            for (int r = 0; r < _table.Rows.Count - 2; r++)
            {
                var row = _table.Rows[r];
                for (int c = 0; c < _table.Columns.Count; c++)
                {
                    row[c] = string.Format("={0}*{1}", r + 1, c + 1);
                }
            }

            // add a total row
            var totRowIndex = _table.Rows.Count - 1;
            var totRow = _table.Rows[totRowIndex];
            for (int c = 0; c < _table.Columns.Count; c++)
            {
                totRow[c] = string.Format("=sum({0}:{1})",
                    _grid.GetAddress(1, c),
                    _grid.GetAddress(totRowIndex - 2, c));
            }

            // bind table to grid
            _grid.DataSource = _table;

            // update address and status bar when selection changes
            _grid.SelectionChanged += _grid_SelectionChanged;

            // update content in formula bar
            _txtFormula.Validating += _txtFormula_Validating;
            _txtFormula.KeyPress += _txtFormula_KeyPress;

            // show list of available functions
            _lblFunctions.MouseDown += _lblFunctions_MouseDown;
        }

        // show menu with available functions
        void _lblFunctions_MouseDown(object sender, MouseEventArgs e)
        {
            var menu = new FunctionMenu();
            menu.ItemClicked += (ss, ee) =>
            {
                var fn = ee.ClickedItem.Text;
                _txtFormula.SelectedText = fn;
            };
            menu.Show(Control.MousePosition);
        }

        // show current address and cell content when selection changes
        void _grid_SelectionChanged(object sender, EventArgs e)
        {
            // show cell content above grid
            string address = null;
            string text = null;
            string status = "Ready";
            int row = _grid.CurrentCellAddress.Y;
            int col = _grid.CurrentCellAddress.X;
            if (row > -1 && col > -1)
            {
                var cell = _grid.Rows[row].Cells[col];
                var val = cell.Value;
                text = val != null ? val.ToString() : null;
                address = _grid.GetAddress(row, col);
                var selection = new CellRange(_grid.SelectedCells);
                if (!selection.IsSingleCell)
                {
                    var sel = _grid.GetAddress(selection);
                    try
                    {
                        var avg = _grid.Evaluate(string.Format("Average({0})", sel));
                        var count = _grid.Evaluate(string.Format("Count({0})", sel));
                        var sum = _grid.Evaluate(string.Format("Sum({0})", sel));
                        if ((double)count > 0)
                        {
                            status = string.Format("Average: {0:#,##0.##} Count: {1:n0} Sum: {2:#,##0.##}",
                                avg, count, sum);
                        }
                    }
                    catch
                    {
                        // the selection contains errors...
                    }
                }
            }
            _lblAddress.Text = address;
            _txtFormula.Text = text;
            _txtFormula.SelectAll();
            _lblStatus.Text = status;
        }

        // update grid when user types into content textbox
        void _txtFormula_Validating(object sender, CancelEventArgs e)
        {
            var pt = _grid.CurrentCellAddress;
            var row = pt.Y;
            var col = pt.X;
            if (row > -1 && col > -1)
            {
                var cell = _grid.Rows[row].Cells[col];
                cell.Value = _txtFormula.Text;
            }
        }
        void _txtFormula_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch ((int)e.KeyChar)
            {
                case 13: // enter
                    e.Handled = true;
                    _grid.Focus();
                    break;
                case 27: // escape
                    e.Handled = true;
                    _grid_SelectionChanged(sender, e);
                    break;
            }
        }
    }
}
