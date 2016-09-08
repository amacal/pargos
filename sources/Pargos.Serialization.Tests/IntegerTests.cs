using FluentAssertions;
using NUnit.Framework;
using Pargos.Attributes;
using Pargos.Core;

namespace Pargos.Serialization.Tests
{
    [TestFixture]
    public class IntegerTests
    {
        public class StandardOptions
        {
            [NamedOption("port")]
            public int Port { get; set; }
        }

        [Test]
        public void ShouldSetValueInOption()
        {
            ArgumentCollection arguments = ArgumentFactory.Parse("--port", "12345");
            StandardOptions standardOptions = arguments.Deserialize<StandardOptions>();

            standardOptions.Should().NotBeNull();
            standardOptions.Port.Should().Be(12345);
        }

        [Test]
        public void ShouldHaveDefaultValue()
        {
            ArgumentCollection arguments = ArgumentFactory.Parse("--port");
            StandardOptions standardOptions = arguments.Deserialize<StandardOptions>();

            standardOptions.Should().NotBeNull();
            standardOptions.Port.Should().Be(0);
        }
    }
}