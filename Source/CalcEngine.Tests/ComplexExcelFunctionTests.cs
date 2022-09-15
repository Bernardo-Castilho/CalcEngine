﻿using System;
using Xunit;

namespace CalcEngine.Tests
{
    public class ComplexExcelFunctionTests
    {
        CalcEngine calcEngine = new CalcEngine();

        [Fact]
        public void supported_functions()
        {
            calcEngine.Test("=SUM(1,2,AVERAGE(1,2) + 3)", 7.5);
        }

        public void Eval(string expression, double expectedValue)
        {
            calcEngine.Test(expression, expectedValue);
        }

        [Fact]
        public void EvaluatesSumFunction()
        {
            Eval("=SUM(1,2,3,4,5)", 15.0d);
            Eval("=SUM(10,5)", 15.0d);
            Eval("=SUM(1)", 1d);
            Assert.Throws<Exception>(() => Eval("=SUM()", 0.0d));
        }

        [Fact]
        public void EvaluatesAverageFunction()
        {
            Eval("=AVERAGE(1,2,3,4,5)", 3.0d);
            Eval("=AVERAGE(10,5)", 7.5d);
            Eval("=AVERAGE(1)", 1d);
            Assert.Throws<Exception>(() => Eval("=AVERAGE()", 0d));
        }

        [Fact]
        public void EvaluatesRoundFunction()
        {
            Eval("=ROUND(1.20,2)", 1.2d);
            Eval("=ROUND(1.20)", 1d);
            Eval("=ROUND(1.50)", 2d);
            Assert.Throws<Exception>(() => Eval("=ROUND()", 0d));
        }

        [Fact]
        public void EvaluatesWEIGHTEDFunction()
        {
            Eval("=WEIGHTED(5, 5)", 25d);
            Eval("=WEIGHTED(5, 0)", 0d);
            Assert.Throws<Exception>(() => Eval("=WEIGHTED()", 0d));
            Assert.Throws<Exception>(() => Eval("=WEIGHTED(1)", 0d));
        }

        [Fact]
        public void EvaluatesSumProductFunction()
        {
            Eval("=ROUND(SUM(4*3,2*2,3*1)/SUM(4+2+3), 2)", 2.11d);
        }

        [Fact]
        public void EvaluatesCustomFunction1()
        {
            Eval("=(2*SUM(2,4)+AVERAGE(1,2,3))/2", 7);
        }

        [Fact]
        public void EvaluatesMedianFunction()
        {
            Eval("=MEDIAN(1,2,5)", 2);
            Eval("=MEDIAN(2,6)", 4);
            Eval("=MEDIAN(17)", 17);
        }

        [Fact]
        public void EvaluatesFloorFunction()
        {
            Eval("=FLOOR(2.45)", 2);
            Eval("=FLOOR(2.45, 1)", 2);
            Eval("=FLOOR(2.45, 2)", 2);
            Eval("=FLOOR(-2.45, -2)", -2);

            Assert.Throws<Exception>(() => Eval("=FLOOR(2.45, -2)", 0));
        }

        [Fact]
        public void EvaluatesCeilingFunction()
        {
            Eval("=CEILING(2.45)", 3);
            Eval("=CEILING(2.45, 1)", 3);
            Eval("=CEILING(2.45, 2)", 4);
            Eval("=CEILING(-2.45, -2)", -4);
            Eval("=CEILING(2.45, 0.2)", 2.6);

            Assert.Throws<Exception>(() => Eval("=CEILING(2.45, -2)", 0));
        }
    }
}
