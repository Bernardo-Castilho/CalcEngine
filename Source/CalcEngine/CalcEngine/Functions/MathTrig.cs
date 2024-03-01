﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CalcEngine
{
    public static class MathTrig
    {
        public static void Register(CalcEngine ce)
        {
            ce.RegisterFunction("ABS", 1, Abs);
            ce.RegisterFunction("ACOS", 1, Acos);
            //ce.RegisterFunction("ACOSH", Acosh, 1);
            ce.RegisterFunction("ASIN", 1, Asin);
            //ce.RegisterFunction("ASINH", Asinh, 1);
            ce.RegisterFunction("ATAN", 1, Atan);
            ce.RegisterFunction("ATAN2", 2, Atan2);
            //ce.RegisterFunction("ATANH", Atanh, 1);
            ce.RegisterFunction("CEILING", 1, 2, Ceiling);
            //ce.RegisterFunction("COMBIN", Combin, 1);
            ce.RegisterFunction("COS", 1, Cos);
            ce.RegisterFunction("COSH", 1, Cosh);
            //ce.RegisterFunction("DEGREES", Degrees, 1);
            //ce.RegisterFunction("EVEN", Even, 1);
            ce.RegisterFunction("EXP", 1, Exp);
            //ce.RegisterFunction("FACT", Fact, 1);
            //ce.RegisterFunction("FACTDOUBLE", FactDouble, 1);
            ce.RegisterFunction("FLOOR", 1, 2, Floor);
            //ce.RegisterFunction("GCD", Gcd, 1);
            ce.RegisterFunction("INT", 1, Int);
            //ce.RegisterFunction("LCM", Lcm, 1);
            ce.RegisterFunction("LN", 1, Ln);
            ce.RegisterFunction("LOG", 1, 2, Log);
            ce.RegisterFunction("LOG10", 1, Log10);
            //ce.RegisterFunction("MDETERM", MDeterm, 1);
            //ce.RegisterFunction("MINVERSE", MInverse, 1);
            //ce.RegisterFunction("MMULT", MMult, 1);
            //ce.RegisterFunction("MOD", Mod, 2);
            //ce.RegisterFunction("MROUND", MRound, 1);
            //ce.RegisterFunction("MULTINOMIAL", Multinomial, 1);
            //ce.RegisterFunction("ODD", Odd, 1);
            ce.RegisterFunction("PI", 0, Pi);
            ce.RegisterFunction("POWER", 2, Power);
            //ce.RegisterFunction("PRODUCT", Product, 1);
            //ce.RegisterFunction("QUOTIENT", Quotient, 1);
            //ce.RegisterFunction("RADIANS", Radians, 1);
            ce.RegisterFunction("RAND", 0, Rand);
            ce.RegisterFunction("RANDBETWEEN", 2, RandBetween);
            //ce.RegisterFunction("ROMAN", Roman, 1);
            ce.RegisterFunction("ROUND", 1, int.MaxValue, Round);
            //ce.RegisterFunction("ROUNDDOWN", RoundDown, 1);
            //ce.RegisterFunction("ROUNDUP", RoundUp, 1);
            //ce.RegisterFunction("SERIESSUM", SeriesSum, 1);
            ce.RegisterFunction("SIGN", 1, Sign);
            ce.RegisterFunction("SIN", 1, Sin);
            ce.RegisterFunction("SINH", 1, Sinh);
            ce.RegisterFunction("SQRT", 1, Sqrt);
            //ce.RegisterFunction("SQRTPI", SqrtPi, 1);
            //ce.RegisterFunction("SUBTOTAL", Subtotal, 1);
            ce.RegisterFunction("SUM", 1, int.MaxValue, Sum);
            ce.RegisterFunction("SUMIF", 2, 3, SumIf);
            //ce.RegisterFunction("SUMPRODUCT", SumProduct, 1);
            //ce.RegisterFunction("SUMSQ", SumSq, 1);
            //ce.RegisterFunction("SUMX2MY2", SumX2MY2, 1);
            //ce.RegisterFunction("SUMX2PY2", SumX2PY2, 1);
            //ce.RegisterFunction("SUMXMY2", SumXMY2, 1);
            ce.RegisterFunction("TAN", 1, Tan);
            ce.RegisterFunction("TANH", 1, Tanh);
            ce.RegisterFunction("TRUNC", 1, Trunc);
			ce.RegisterFunction("WEIGHTED", 2, Weighted);
        }
#if DEBUG
        public static void Test(CalcEngine ce)
        {
            ce.Test("ABS(-12)", 12.0);
            ce.Test("ABS(+12)", 12.0);
            ce.Test("ACOS(.23)", Math.Acos(.23));
            ce.Test("ASIN(.23)", Math.Asin(.23));
            ce.Test("ATAN(.23)", Math.Atan(.23));
            ce.Test("ATAN2(1,2)", Math.Atan2(1, 2));
            ce.Test("CEILING(1.8)", Math.Ceiling(1.8));
            ce.Test("COS(1.23)", Math.Cos(1.23));
            ce.Test("COSH(1.23)", Math.Cosh(1.23));
            ce.Test("EXP(1)", Math.Exp(1));
            ce.Test("FLOOR(1.8)", Math.Floor(1.8));
            ce.Test("INT(1.8)", 1);
            ce.Test("LOG(1.8)", Math.Log(1.8, 10)); // default base is 10
            ce.Test("LOG(1.8, 4)", Math.Log(1.8, 4)); // custom base
            ce.Test("LN(1.8)", Math.Log(1.8)); // real log
            ce.Test("LOG10(1.8)", Math.Log10(1.8)); // same as Log(1.8)
            ce.Test("PI()", Math.PI);
            ce.Test("POWER(2,4)", Math.Pow(2, 4));
            //ce.Test("RAND") <= 1.0);
            //ce.Test("RANDBETWEEN(4,5)") <= 5);
            ce.Test("SIGN(-5)", -1);
            ce.Test("SIGN(+5)", +1);
            ce.Test("SIGN(0)", 0);
            ce.Test("SIN(1.23)", Math.Sin(1.23));
            ce.Test("SINH(1.23)", Math.Sinh(1.23));
            ce.Test("SQRT(144)", Math.Sqrt(144));
            ce.Test("SUM(1, 2, 3, 4)", 1 + 2 + 3 + 4.0);
            ce.Test("TAN(1.23)", Math.Tan(1.23));
            ce.Test("TANH(1.23)", Math.Tanh(1.23));
            ce.Test("TRUNC(1.23)", 1.0);
            ce.Test("PI()", Math.PI);
            ce.Test("PI", Math.PI);
            ce.Test("LN(10)", Math.Log(10));
            ce.Test("LOG(10)", Math.Log10(10));
            ce.Test("EXP(10)", Math.Exp(10));
            ce.Test("SIN(PI()/4)", Math.Sin(Math.PI / 4));
            ce.Test("ASIN(PI()/4)", Math.Asin(Math.PI / 4));
            ce.Test("SINH(PI()/4)", Math.Sinh(Math.PI / 4));
            ce.Test("COS(PI()/4)", Math.Cos(Math.PI / 4));
            ce.Test("ACOS(PI()/4)", Math.Acos(Math.PI / 4));
            ce.Test("COSH(PI()/4)", Math.Cosh(Math.PI / 4));
            ce.Test("TAN(PI()/4)", Math.Tan(Math.PI / 4));
            ce.Test("ATAN(PI()/4)", Math.Atan(Math.PI / 4));
            ce.Test("ATAN2(1,2)", Math.Atan2(1, 2));
            ce.Test("TANH(PI()/4)", Math.Tanh(Math.PI / 4));
        }
#endif
        static object Abs(List<Expression> p)
        {
            return Math.Abs((double)p[0]);
        }
        static object Acos(List<Expression> p)
        {
            return Math.Acos((double)p[0]);
        }
        static object Asin(List<Expression> p)
        {
            return Math.Asin((double)p[0]);
        }
        static object Atan(List<Expression> p)
        {
            return Math.Atan((double)p[0]);
        }
        static object Atan2(List<Expression> p)
        {
            return Math.Atan2((double)p[0], (double)p[1]);
        }
        static object Ceiling(List<Expression> p)
        {
            var value = (double)p[0];

            if (p.Count == 1)
            {
                return Math.Ceiling(value);
            }

            var significance = (double)p[1];

            if (value > 0 && significance < 0)
            {
                throw new ArgumentException("Value is positive and significance is negative!");
            }

            return Math.Ceiling(value / significance) * significance;
        }
        static object Cos(List<Expression> p)
        {
            return Math.Cos((double)p[0]);
        }
        static object Cosh(List<Expression> p)
        {
            return Math.Cosh((double)p[0]);
        }
        static object Exp(List<Expression> p)
        {
            return Math.Exp((double)p[0]);
        }
        static object Floor(List<Expression> p)
        {
            var value = (double)p[0];

            if (p.Count == 1)
            {
                return Math.Floor(value);
            }

            var significance = (double)p[1];

            if (value > 0 && significance < 0)
            {
                throw new ArgumentException("Value is positive and significance is negative!");
            }

            return Math.Floor(value / significance) * significance;
        }
        static object Int(List<Expression> p)
        {
            return Math.Truncate((double)p[0]);
        }
        static object Ln(List<Expression> p)
        {
            return Math.Log((double)p[0]);
        }
        static object Log(List<Expression> p)
        {
            var lbase = p.Count > 1 ? (double)p[1] : 10;
            return Math.Log((double)p[0], lbase);
        }
        static object Log10(List<Expression> p)
        {
            return Math.Log10((double)p[0]);
        }
        static object Pi(List<Expression> p)
        {
            return Math.PI;
        }
        static object Power(List<Expression> p)
        {
            return Math.Pow((double)p[0], (double)p[1]);
        }
        static readonly Random _rnd = new Random();
        static object Rand(List<Expression> p)
        {
            return _rnd.NextDouble();
        }
        static object RandBetween(List<Expression> p)
        {
            return _rnd.Next((int)(double)p[0], (int)(double)p[1]);
        }
        static object Round(List<Expression> p)
        {
            var toDecimals = 0;
            if (p.Count > 1)
            {
                toDecimals = (int)p[p.Count - 1];
            }
            return Math.Round(p[0], toDecimals, MidpointRounding.AwayFromZero);
        }
        static object Sign(List<Expression> p)
        {
            return Math.Sign((double)p[0]);
        }
        static object Sin(List<Expression> p)
        {
            return Math.Sin((double)p[0]);
        }
        static object Sinh(List<Expression> p)
        {
            return Math.Sinh((double)p[0]);
        }
        static object Sqrt(List<Expression> p)
        {
            return Math.Sqrt((double)p[0]);
        }
        static object Sum(List<Expression> p)
        {
            var tally = new Tally();
            foreach (Expression e in p)
            {
                tally.Add(e);
            }
            return tally.Sum();
        }
        static object SumIf(List<Expression> p)
        {
            // get parameters
            IEnumerable range = p[0] as IEnumerable;
            IEnumerable sumRange = p.Count < 3 ? range : p[2] as IEnumerable;
            var criteria = p[1].Evaluate();

            // build list of values in range and sumRange
            var rangeValues = new List<object>();
            foreach (var value in range)
            {
                rangeValues.Add(value);
            }
            var sumRangeValues = new List<object>();
            foreach (var value in sumRange)
            {
                sumRangeValues.Add(value);
            }

            // compute total
            var ce = new CalcEngine();
            var tally = new Tally();
            for (int i = 0; i < Math.Min(rangeValues.Count, sumRangeValues.Count); i++)
            {
                if (ValueSatisfiesCriteria(rangeValues[i], criteria, ce))
                {
                    tally.AddValue(sumRangeValues[i]);
                }
            }

            // done
            return tally.Sum();
        }
        static bool ValueSatisfiesCriteria(object value, object criteria, CalcEngine ce)
        {
            // safety...
            if (value == null)
            {
                return false;
            }

            // if criteria is a number, straight comparison
            if (criteria is double)
            {
                return (double)value == (double)criteria;
            }

            // convert criteria to string
            var cs = criteria as string;
            if (!string.IsNullOrEmpty(cs))
            {
                // if criteria is an expression (e.g. ">20"), use calc engine
                if (cs[0] == '=' || cs[0] == '<' || cs[0] == '>')
                {
                    // build expression
                    var expression = string.Format("{0}{1}", value, cs);

                    // add quotes if necessary
                    var pattern = @"(\w+)(\W+)(\w+)";
                    var m = Regex.Match(expression, pattern);
                    if (m.Groups.Count == 4)
                    {
                        double d;
                        if (!double.TryParse(m.Groups[1].Value, out d) ||
                            !double.TryParse(m.Groups[3].Value, out d))
                        {
                            expression = string.Format("\"{0}\"{1}\"{2}\"",
                                m.Groups[1].Value,
                                m.Groups[2].Value,
                                m.Groups[3].Value);
                        }
                    }

                    // evaluate
                    return (bool)ce.Evaluate(expression);
                }

                // if criteria is a regular expression, use regex
                if (cs.IndexOf('*') > -1)
                {
                    var pattern = cs.Replace(@"\", @"\\");
                    pattern = pattern.Replace(".", @"\");
                    pattern = pattern.Replace("*", ".*");
                    return Regex.IsMatch(value.ToString(), pattern, RegexOptions.IgnoreCase);
                }

                // straight string comparison 
                return string.Equals(value.ToString(), cs, StringComparison.OrdinalIgnoreCase);
            }

            // should never get here?
            System.Diagnostics.Debug.Assert(false, "failed to evaluate criteria in SumIf");
            return false;
        }
        static object Tan(List<Expression> p)
        {
            return Math.Tan((double)p[0]);
        }
        static object Tanh(List<Expression> p)
        {
            return Math.Tanh((double)p[0]);
        }
        static object Trunc(List<Expression> p)
        {
            return (double)Math.Truncate((double)p[0]);
        }
        static object Weighted(List<Expression> p)
        {
            return p[0] * p[1];
        }
    }
}
