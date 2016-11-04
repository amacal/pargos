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
            public void HasNoParameter()
            {
                argument.Parameters.Should().Be(0);
            }

            [Test]
            public void HasOneOption()
            {
                argument.Options.Should().Be(1);
            }

            [Test]
            [TestCase("--git", "a/lib/simplegit.rb")]
            [TestCase("--git", "b/lib/simplegit.rb")]
            public void HasRequestedOptions(string index, string option)
            {
                argument[index].Should().Contain(option);
            }
        }
    }
}