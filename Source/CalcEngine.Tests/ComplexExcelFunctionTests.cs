using Xunit;

namespace CalcEngine.Tests
{
    public class ComplexExcelFunctionTests
    {
        [Fact]
        public void supported_functions()
        {
            CalcEngine calcEngine = new CalcEngine();
            calcEngine.Test("=SUM(1,2,AVERAGE(1,2) + 3)", 7.5);
            
        }
    }
}
