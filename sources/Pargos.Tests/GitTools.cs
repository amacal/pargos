using FluentAssertions;
using NUnit.Framework;

namespace Pargos.Tests
{
    public static class GitTools
    {
        public class BranchesInANutshell
        {
            private readonly Argument argument;
            private readonly ArgumentView view;

            public BranchesInANutshell()
            {
                argument = new Argument("--git", "a/lib/simplegit.rb", "b/lib/simplegit.rb");
                view = new ArgumentView(argument);
            }

            [Test]
            public void HasNoVerb()
            {
                view.HasVerbs().Should().BeFalse();
            }

            [Test]
            public void HasOptions()
            {
                view.HasOptions().Should().BeTrue();
            }

            [Test]
            public void HasTwoOptions()
            {
                view.CountOptions("git").Should().Be(2);
            }

            [Test]
            public void HasRequestedOption()
            {
                view.HasOptions("git").Should().BeTrue();
            }

            [Test]
            [TestCase(0, "a/lib/simplegit.rb")]
            [TestCase(1, "b/lib/simplegit.rb")]
            public void HasRequestedValue(int index, string value)
            {
                view.GetOption("git", index).Should().Be(value);
            }
        }
    }
}