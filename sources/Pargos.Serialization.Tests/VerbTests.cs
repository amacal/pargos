using FluentAssertions;
using NUnit.Framework;
using Pargos.Attributes;
using Pargos.Core;

namespace Pargos.Serialization.Tests
{
    [TestFixture]
    public class VerbTests
    {
        public class GitOptions
        {
            [Verb("diff")]
            public DiffOptions Diff { get; set; }
        }

        public class DiffOptions
        {
            [NamedOption("cached")]
            public bool Cached { get; set; }
        }

        [Test]
        public void ShouldFindVerb()
        {
            ArgumentCollection arguments = ArgumentFactory.Parse("diff");
            GitOptions options = arguments.Deserialize<GitOptions>();

            options.Should().NotBeNull();
            options.Diff.Should().NotBeNull();
        }

        [Test]
        public void ShouldSetOption()
        {
            ArgumentCollection arguments = ArgumentFactory.Parse("diff", "--cached");
            GitOptions options = arguments.Deserialize<GitOptions>();

            options.Diff.Cached.Should().BeTrue();
        }
    }
}