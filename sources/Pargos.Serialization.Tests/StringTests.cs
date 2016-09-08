using FluentAssertions;
using NUnit.Framework;
using Pargos.Attributes;
using Pargos.Core;

namespace Pargos.Serialization.Tests
{
    [TestFixture]
    public class StringTests
    {
        public class GrepOptions
        {
            [IndexOption(0)]
            public string Pattern { get; set; }

            [RangeOption(1)]
            public string[] Files { get; set; }
        }

        [Test]
        public void ShouldFindPatternOption()
        {
            ArgumentCollection arguments = ArgumentFactory.Parse("boo", "/etc/password");
            GrepOptions options = arguments.Deserialize<GrepOptions>();

            options.Should().NotBeNull();
            options.Pattern.Should().Be("boo");
        }

        [Test]
        public void ShouldFindFilesOption()
        {
            ArgumentCollection arguments = ArgumentFactory.Parse("boo", "/etc/password", "/etc/secret");
            GrepOptions options = arguments.Deserialize<GrepOptions>();

            options.Should().NotBeNull();
            options.Files.Should().Equal("/etc/password", "/etc/secret");
        }

        [Test]
        public void ShouldFindNoFilesOption()
        {
            ArgumentCollection arguments = ArgumentFactory.Parse("boo");
            GrepOptions options = arguments.Deserialize<GrepOptions>();

            options.Should().NotBeNull();
            options.Files.Should().BeNull();
        }
    }
}