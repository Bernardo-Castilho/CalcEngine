using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalcEngineDemo
{
    class DataGridCalcEngine : CalcEngine.CalcEngine
    {
        // ** fields
        DataGridCalc _grid;

        // ** ctor

        /// <summary>
        /// Initializes a new instance of a DataGridCalcEngine.
        /// </summary>
        /// <param name="grid">Grid that provides data for the engine.</param>
        public DataGridCalcEngine(DataGridCalc grid)
        {
            // save reference to parent grid
            _grid = grid;

            // parse multi-cell range references ($A2:B$4)
            IdentifierChars = "$:";
        }

        // ** object model

        /// <summary>
        /// Exposes the grid's DataContext to the CalcEngine.
        /// </summary>
        public override object DataContext
        {
            get { return _grid != null ? _grid.DataContext : base.DataContext; }
            set 
            {
                if (_grid != null)
                {
                    _grid.DataContext = value;
                }
                else
                {
                    base.DataContext = value;
                }
            }
        }
        /// <summary>
        /// Parses references to cell ranges.
        /// </summary>
        /// <param name="identifier">String representing a cell range (e.g. "A1" or "A1:B12".</param>
        /// <returns>A <see cref="CellRange"/> object that represents the given range.</returns>
        public override object GetExternalObject(string identifier)
        {
            // check that we have a grid
            if (_grid != null)
            {
                var cells = identifier.Split(':');
                if (cells.Length > 0 && cells.Length < 3)
                {
                    CellRange rng = GetRange(cells[0]);
                    if (cells.Length > 1)
                    {
                        rng = MergeRanges(rng, GetRange(cells[1]));
                    }
                    if (rng.IsValid)
                    {
                        return new CellRangeReference(_grid, rng);
                    }
                }
            }

            // this doesn't look like a range
            return null;
        }

        // ** implementation
        CellRange GetRange(string cell)
        {
            int index = 0;

            // parse column
            int col = -1;
            bool absCol = false;
            for (; index < cell.Length; index++)
            {
                var c = cell[index];
                if (c == '$' && !absCol)
                {
                    absCol = true;
                    continue;
                }
                if (!char.IsLetter(c))
                {
                    break;
                }
                if (col < 0) col = 0;
                col = 26 * col + (char.ToUpper(c) - 'A' + 1);
            }

            // parse row
            int row = -1;
            bool absRow = false;
            for (; index < cell.Length; index++)
            {
                var c = cell[index];
                if (c == '$' && !absRow)
                {
                    absRow = true;
                    continue;
                }
                if (!char.IsDigit(c))
                {
                    break;
                }
                if (row < 0) row = 0;
                row = 10 * row + (c - '0');
            }

            // sanity
            if (index < cell.Length)
            {
                throw new Exception("Invalid cell reference.");
            }

            // done
            return new CellRange(row - 1, col - 1);
        }
        CellRange MergeRanges(CellRange rng1, CellRange rng2)
        {
            return new CellRange(
                Math.Min(rng1.TopRow, rng2.TopRow),
                Math.Min(rng1.LeftCol, rng2.LeftCol),
                Math.Max(rng1.BottomRow, rng2.BottomRow),
                Math.Max(rng1.RightCol, rng2.RightCol));
        }
        /// <summary>
        /// Represents cell ranges and returns the cell values to the calc engine.
        /// </summary>
        class CellRangeReference : CalcEngine.IValueObject, IEnumerable
        {
            // ** fields
            DataGridCalc _grid;
            CellRange _rng;
            bool _evaluating;

            // ** ctor
            public CellRangeReference(DataGridCalc grid, CellRange rng)
            {
                _grid = grid;
                _rng = rng;
            }

            // ** IValueObject
            public object GetValue()
            {
                return GetValue(_rng);
            }

            // ** IEnumerable
            public IEnumerator GetEnumerator()
            {
                for (int r = _rng.TopRow; r <= _rng.BottomRow; r++)
                {
                    for (int c = _rng.LeftCol; c <= _rng.RightCol; c++)
                    {
                        var rng = new CellRange(r, c);
                        yield return GetValue(rng);
                    }
                }
            }

            // ** implementation
            object GetValue(CellRange rng)
            {
                if (_evaluating)
                {
                    throw new Exception("Circular Reference");
                }
                try
                {
                    _evaluating = true;
                    return _grid.Evaluate(rng.r1, rng.c1);
                }
                finally
                {
                    _evaluating = false;
                }
            }
        }
    }

    public struct CellRange
    {
        public int r1, c1, r2, c2;
        public CellRange(int row, int col)
            : this(row, col, row, col)
        {
        }
        public CellRange(int row1, int col1, int row2, int col2)
        {
            r1 = row1;
            c1 = col1;
            r2 = row2;
            c2 = col2;
        }
        public CellRange(System.Windows.Forms.DataGridViewSelectedCellCollection sel)
        {
            // assume invalid range
            r1 = r2 = c1 = c2 = -1;

            // build CellRange using the first and last cells in the 
            // DataGridViewSelectedCellCollection
            if (sel.Count > 0)
            {
                var cell1 = sel[0];
                var cell2 = sel[sel.Count - 1];
                r1 = cell1.RowIndex;
                c1 = cell1.ColumnIndex;
                r2 = cell2.RowIndex;
                c2 = cell2.ColumnIndex;
            }
        }
        public int TopRow { get { return Math.Min(r1, r2); } }
        public int BottomRow { get { return Math.Max(r1, r2); } }
        public int LeftCol { get { return Math.Min(c1, c2); } }
        public int RightCol { get { return Math.Max(c1, c2); } }
        public bool IsValid { get { return r1 > -1 && c1 > -1 && r2 > -1 && c2 > -1; } }
        public bool IsSingleCell { get { return r1 == r2 && c1 == c2; } }
    }
}
