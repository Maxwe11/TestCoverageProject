namespace TestCoverageProject.Tests
{
    using System;

    using Xunit;

    public class FooTest
    {
        [Fact]
        public void Ctor_Success()
        {
            new Foo("test");
        }

        [Fact]
        public void Ctor_Fail()
        {
            Assert.Throws<ArgumentException>(() => new Foo(string.Empty));
        }
    }
}
