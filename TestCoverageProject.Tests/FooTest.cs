namespace TestCoverageProject.Tests
{
    using Xunit;

    public class FooTest
    {
        [Fact]
        public void Ctor_Success()
        {
            new Foo("test");
        }
    }
}
