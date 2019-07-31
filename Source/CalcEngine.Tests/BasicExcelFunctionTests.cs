using System;
using Xunit;

namespace CalcEngine.Tests
{
    public class BasicExcelFunctionTests
    {
        [Fact]
        public void supported_functions()
        {
            CalcEngine calcEngine = new CalcEngine();
            calcEngine.Test("=SUM(1,2,3)", 6);
            calcEngine.Test("=SUM(6)", 6);
            calcEngine.Test("=ABS(-1)", 1);
            calcEngine.Test("=ABS(1)", 1);
            calcEngine.Test("=AVERAGE(1,2)", 1.5);
            calcEngine.Test("CEILING(1.8)", Math.Ceiling(1.8));
            calcEngine.Test("=COUNT(1,2,3)", 3);
            calcEngine.Test("=ROUND(1,1)", 1);
        }

        [Fact(Skip = "Should not be run, this if only done for doc purpose")]
        public void not_supported_functions()
        {
            CalcEngine calcEngine = new CalcEngine();
            calcEngine.Test("=ARABIC(\"VII\")", 7);
            calcEngine.Test("=BASE(10,2)", "1010");
        }
    }
}
