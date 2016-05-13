using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CalcEngineDemo
{
    public class DataGridCalc : DataGridView
    {
        // fields
        DataGridCalcEngine _ce;
        DataGridViewCellStyle _styleNumber, _styleDate;
        const string FORMAT_NUMBER = "#,##0.#########";
        const string FORMAT_DATE = "d";

        // ctor
        public DataGridCalc()
        {
            // create calc engine
            _ce = new DataGridCalcEngine(this);

            // row headers must be wider to show the row number
            this.RowHeadersWidth = 50;

            // center-align row and column headers
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // define the format to use for showing calculated numbers
            _styleNumber = new DataGridViewCellStyle(this.DefaultCellStyle);
            _styleNumber.Format = FORMAT_NUMBER;
            _styleNumber.Alignment = DataGridViewContentAlignment.MiddleRight;
            _styleDate = new DataGridViewCellStyle(this.DefaultCellStyle);
            _styleDate.Format = FORMAT_DATE;

            // make grid lines more subtle
            this.GridColor = Color.FromArgb(0xf0, 0xf0, 0xf0);
        }

        // ** object model

        // expose arbitrary objects to calc engine
        public object DataContext { get; set; }

        // gets the value in a cell
        public object Evaluate(int rowIndex, int colIndex)
        {
            // get the value
            var val = this.Rows[rowIndex].Cells[colIndex].Value;
            var text = val as string;
            if (!string.IsNullOrEmpty(text) && text[0] == '=')
            {
                val = Evaluate(text);
            }
            return val;
        }

        // evaluates an expression
        public object Evaluate(string expression)
        {
            return _ce.Evaluate(expression);
        }

        // gets the address of a cell using Excel notation (e.g. A1)
        public string GetAddress(int row, int col)
        {
            return string.Format("{0}{1}",
                GetAlphaColumnHeader(col),
                row + 1);
        }

        // gets the address of a cell range using Excel notation (e.g. A1:B10)
        public string GetAddress(CellRange rng)
        {
            return rng.IsSingleCell
                ? GetAddress(rng.r1, rng.c1)
                : string.Format("{0}:{1}", GetAddress(rng.r1, rng.c1), GetAddress(rng.r2, rng.c2));
        }

        // gets an alpha numeric header for a column (e.g. A, B, C, AA, AB, AC, etc)
        public static string GetAlphaColumnHeader(int i)
        {
            return GetAlphaColumnHeader(i, string.Empty);
        }
        static string GetAlphaColumnHeader(int i, string s)
        {
            var rem = i % 26;
            s = (char)((int)'A' + rem) + s;
            i = i / 26 - 1;
            return i < 0 ? s : GetAlphaColumnHeader(i, s);
        }

        // ** overrides

        // show row numbers in row headers
        protected override void OnRowPrePaint(DataGridViewRowPrePaintEventArgs e)
        {
            var cell = this.Rows[e.RowIndex].HeaderCell;
            var label = (e.RowIndex + 1).ToString();
            if (!object.Equals(cell.Value, label))
            {
                cell.Value = label;
            }
            base.OnRowPrePaint(e);
        }

        // evaluate expressions when showing cells
        protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        {
            // get the cell
            var cell = this.Rows[e.RowIndex].Cells[e.ColumnIndex];

            // if not in edit mode, calculate value
            if (cell != null && !cell.IsInEditMode)
            {
                var val = e.Value as string;
                if (!string.IsNullOrEmpty(val))
                {
                    if (val[0] == '=')
                    {
                        try
                        {
                            e.Value = Evaluate(val);
                        }
                        catch (Exception x)
                        {
                            e.Value = "** ERR: " + x.Message;
                        }
                    }
                    else if (val[0] == '\'')
                    {
                        e.Value = val.Substring(1);
                    }
                }
            }

            // apply default numeric formatting
            if (object.Equals(this.DefaultCellStyle, e.CellStyle))
            {
                if (e.Value is double)
                {
                    e.CellStyle = _styleNumber;
                }
                else if (e.Value is DateTime)
                {
                    e.CellStyle = _styleDate;
                }
            }

            // fire event as usual
            base.OnCellFormatting(e);
        }

        // invalidate cells with formulas after editing
        protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        {
            // try converting strings into doubles after editing
            double dbl;
            var cell = this.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var str = cell.Value as string;
            if (!string.IsNullOrEmpty(str) && double.TryParse(str, out dbl))
            {
                cell.Value = dbl;
            }

            // invalidate grid to update formulas
            this.Invalidate();

            // fire event as usual
            base.OnCellEndEdit(e);
        }

        // update the grid styles to use the current font
        protected override void OnFontChanged(EventArgs e)
        {
            // update default number style
            this.DefaultCellStyle.Font = this.Font;
            _styleNumber.Font = this.DefaultCellStyle.Font;

            // fire event as usual
            base.OnFontChanged(e);
        }
    }
}
