using System;
using System.Collections.Generic;

namespace CalcEngine.Functions
{
    public class ExtendedTally : Tally
    {
        List<double> _vals;

        public ExtendedTally(bool numbersOnly) : base(numbersOnly)
        {
            _vals = new List<double>();
        }

        public ExtendedTally() : base()
        {
            _vals = new List<double>();
        }

        public override void AddValue(object value)
        {
            // conversions
            if (!_numbersOnly)
            {
                // arguments that contain text evaluate as 0 (zero). 
                // empty text ("") evaluates as 0 (zero).
                if (value == null || value is string)
                {
                    value = 0;
                }
                // arguments that contain TRUE evaluate as 1; 
                // arguments that contain FALSE evaluate as 0 (zero).
                if (value is bool)
                {
                    value = (bool)value ? 1 : 0;
                }
            }

            // convert all numeric values to doubles
            if (value != null)
            {
                var typeCode = Type.GetTypeCode(value.GetType());
                if (typeCode >= TypeCode.Char && typeCode <= TypeCode.Decimal)
                {
                    value = Convert.ChangeType(value, typeof(double), System.Globalization.CultureInfo.CurrentCulture);
                    _vals.Add((double)value);
                }
            }

            // tally
            if (value is double)
            {
                var dbl = (double)value;
                _sum += dbl;
                _sum2 += dbl * dbl;
                _cnt++;
                if (_cnt == 1 || dbl < _min)
                {
                    _min = dbl;
                }
                if (_cnt == 1 || dbl > _max)
                {
                    _max = dbl;
                }
            }
        }

        public double Median()
        {
            var assessments = _vals.ToArray();

            if (_vals.Count <= 0)
            {
                return 0;
            }

            Array.Sort(assessments);

            var arrayLength = assessments.Length;

            if (arrayLength % 2 == 0)
            {
                return (assessments[(arrayLength / 2) - 1] + assessments[arrayLength / 2]) / 2;
            }

            return assessments[(int)Math.Floor((decimal)arrayLength / 2)];
        }
    }
}
