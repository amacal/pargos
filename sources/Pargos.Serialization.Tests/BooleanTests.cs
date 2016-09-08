using FluentAssertions;
using NUnit.Framework;
using Pargos.Attributes;
using Pargos.Core;

namespace Pargos.Serialization.Tests
{
    [TestFixture]
    public class BooleanTests
    {
        public class Options
        {
            [NamedOption("enabled")]
            [BooleanOption("yes", "no")]
            public bool Enabled { get; set; }
        }

        [Test]
        public void ShouldUseTrueOption()
        {
            ArgumentCollection arguments = ArgumentFactory.Parse("--enabled", "yes");
            Options options = arguments.Deserialize<Options>();

            options.Should().NotBeNull();
            options.Enabled.Should().BeTrue();
        }

        [Test]
        public void ShouldUseFalseOption()
        {
            ArgumentCollection arguments = ArgumentFactory.Parse("--enabled", "no");
            Options options = arguments.Deserialize<Options>();

            options.Should().NotBeNull();
            options.Enabled.Should().BeFalse();
        }

        [Test]
        public void ShouldUseDefaultOption()
        {
            ArgumentCollection arguments = ArgumentFactory.Parse("--enabled");
            Options options = arguments.Deserialize<Options>();

            options.Should().NotBeNull();
            options.Enabled.Should().BeTrue();
        }

        [Test]
        public void ShouldUseNoneOption()
        {
            ArgumentCollection arguments = ArgumentFactory.Parse();
            Options options = arguments.Deserialize<Options>();

            options.Should().NotBeNull();
            options.Enabled.Should().BeFalse();
        }

        [Test]
        public void ShouldIgnoreOption()
        {
            ArgumentCollection arguments = ArgumentFactory.Parse("--enabled", "nothing");
            Options options = arguments.Deserialize<Options>();

            options.Should().NotBeNull();
            options.Enabled.Should().BeFalse();
        }
    }
}