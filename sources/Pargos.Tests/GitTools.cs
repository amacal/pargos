using FluentAssertions;
using NUnit.Framework;

namespace Pargos.Tests
{
    public static class GitTools
    {
        public class BranchesInANutshell
        {
            private readonly Argument argument;

            public BranchesInANutshell()
            {
                argument = Argument.Parse("--git", "a/lib/simplegit.rb", "b/lib/simplegit.rb");
            }

            [Test]
            public void HasNoVerb()
            {
                argument.HasVerbs().Should().BeFalse();
            }

            [Test]
            public void HasOptions()
            {
                argument.HasOptions().Should().BeTrue();
            }

            [Test]
            public void HasTwoOptions()
            {
                argument.CountOptions("git").Should().Be(2);
            }

            [Test]
            public void HasRequestedOption()
            {
                argument.HasOptions("git").Should().BeTrue();
            }

            [Test]
            [TestCase(0, "a/lib/simplegit.rb")]
            [TestCase(1, "b/lib/simplegit.rb")]
            public void HasRequestedValue(int index, string value)
            {
                argument.GetOption("git", index).Should().Be(value);
            }
        }
    }
}