namespace TestCoverageProject
{
    using System;

    public class Foo
    {
        public Foo(string bar)
        {
            if (bar == null)
            {
                throw new ArgumentNullException(nameof(bar));
            }

            if (bar == string.Empty)
            {
                throw new ArgumentException(nameof(bar));
            }

            Bar = bar;
        }

        public string Bar { get; }
    }
}
