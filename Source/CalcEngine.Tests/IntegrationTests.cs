using Xunit;

namespace CalcEngine.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void should_test_all_classes_functionality_calculations()
        {
            MathTrig.Test(new CalcEngine());
            Logical.Test(new CalcEngine());
            Statistical.Test(new CalcEngine());
            Text.Test(new CalcEngine());
            new CalcEngine().Test();
        }
    }
}
