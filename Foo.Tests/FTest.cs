namespace Foo.Tests
{
    using System;

    using TestCoverageProject;

    using Xunit;

    public class FTest
    {
        [Fact]
        public void FTest_Ctor()
        {
            Assert.Throws<ArgumentNullException>(() => new Foo(null));
        }
    }
}
