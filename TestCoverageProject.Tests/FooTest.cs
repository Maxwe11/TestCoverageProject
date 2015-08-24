namespace TestCoverageProject.Tests
{
    using System;
    using System.IO.Ports;
    using System.Threading;

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

        [Fact]
        public static void SerialPort_Test()
        {
            const string expected = "FooBar";
            string actual = null;
            var port = new SerialPort("COM1");
            var port2 = new SerialPort("COM1");
            var mres = new ManualResetEventSlim();
            port2.DataReceived += (sender, e) =>
            {
                actual = port2.ReadExisting();
                mres.Set();
            };

            port.Open();
            port2.Open();
            port.Write(expected);

            Assert.True(mres.Wait(TimeSpan.FromSeconds(2)), "Timedout");
            Assert.Equal(expected, actual);
        }
    }
}
