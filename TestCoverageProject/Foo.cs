namespace TestCoverageProject
{
    using System;

    public class Foo
    {
        public Foo(string bar)
        {
            if (string.IsNullOrEmpty(bar))
            {
                throw new ArgumentNullException(nameof(bar));
            }

            Bar = bar;
        }

        public string Bar { get; }
    }
}
