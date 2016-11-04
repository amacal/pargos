using FluentAssertions;
using NUnit.Framework;

namespace Pargos.Tests
{
    public class EchoExamples
    {
        public class StartDefaultServer
        {
            private readonly EchoOptions options;

            public StartDefaultServer()
            {
                options = Argument.Parse<EchoOptions>("server");
            }

            [Test]
            public void IsNotNull()
            {
                options.Should().NotBeNull();
            }

            [Test]
            public void HasServerOptions()
            {
                options.Server.Should().NotBeNull();
            }

            [Test]
            public void HasNoPort()
            {
                options.Server.Port.HasValue.Should().BeFalse();
            }
        }

        public class StartDefaultBenchmark
        {
            private readonly EchoOptions options;

            public StartDefaultBenchmark()
            {
                options = Argument.Parse<EchoOptions>("benchmark");
            }

            [Test]
            public void IsNotNull()
            {
                options.Should().NotBeNull();
            }

            [Test]
            public void HasServerOptions()
            {
                options.Benchmark.Should().NotBeNull();
            }

            [Test]
            public void HasNoPort()
            {
                options.Benchmark.Port.HasValue.Should().BeFalse();
            }
        }

        public class StartRemoteBenchmark
        {
            private readonly EchoOptions options;

            public StartRemoteBenchmark()
            {
                options = Argument.Parse<EchoOptions>("benchmark", "--port", "3001", "--message-size", "16384");
            }

            [Test]
            public void IsNotNull()
            {
                options.Should().NotBeNull();
            }

            [Test]
            public void HasServerOptions()
            {
                options.Benchmark.Should().NotBeNull();
            }

            [Test]
            public void HasRequestedPort()
            {
                options.Benchmark.Port.Should().Be(3001);
            }

            [Test]
            public void HasRequestedMessageSize()
            {
                options.Benchmark.Size.Should().Be(16384);
            }
        }

        public class EchoOptions
        {
            [Parameter, At(0)]
            [Match("server")]
            public EchoServerOptions Server { get; set; }

            [Parameter, At(0)]
            [Match("benchmark")]
            public EchoBenchmarkOptions Benchmark { get; set; }
        }

        public class EchoServerOptions
        {
            [Option("--port")]
            public int? Port { get; set; }
        }

        public class EchoBenchmarkOptions
        {
            [Option("--host")]
            public string Host { get; set; }

            [Option("--port")]
            public int? Port { get; set; }

            [Option("--message-size")]
            public int? Size { get; set; }

            [Option("--workers")]
            public int? Workers { get; set; }
        }
    }
}