using FluentAssertions;
using NUnit.Framework;

namespace Pargos.Tests
{
    public static class GitBranching
    {
        public class BranchesInANutshell
        {
            private readonly Argument argument;

            public BranchesInANutshell()
            {
                argument = Argument.Parse("add", "README", "test.rb", "LICENSE");
            }

            [Test]
            [TestCase(0)]
            [TestCase(1)]
            [TestCase(2)]
            [TestCase(3)]
            public void HasVerb(int index)
            {
                argument.HasVerbs(index).Should().BeTrue();
            }

            [Test]
            public void HasFourVerbs()
            {
                argument.CountVerbs().Should().Be(4);
            }

            [Test]
            [TestCase(0, "add")]
            [TestCase(1, "README")]
            [TestCase(2, "test.rb")]
            [TestCase(3, "LICENSE")]
            public void HasRequestedVerb(int index, string verb)
            {
                argument.GetVerb(index).Should().Be(verb);
            }
        }

        public class CreatingANewBranch
        {
            private readonly Argument argument;

            public CreatingANewBranch()
            {
                argument = Argument.Parse("log", "--oneline", "--decorate");
            }

            [Test]
            public void HasAnyVerb()
            {
                argument.HasVerbs().Should().BeTrue();
            }

            [Test]
            public void HasOneVerb()
            {
                argument.CountVerbs().Should().Be(1);
            }

            [Test]
            public void HasRequestedVerb()
            {
                argument.GetVerb().Should().Be("log");
            }

            [Test]
            public void HasOptions()
            {
                argument.HasOptions().Should().BeTrue();
            }

            [Test]
            public void HasTwoOptions()
            {
                argument.CountOptions().Should().Be(2);
            }

            [Test]
            [TestCase("oneline")]
            [TestCase("decorate")]
            public void HasRequestedOptions(string name)
            {
                argument.HasOptions(name).Should().BeTrue();
            }

            [Test]
            [TestCase("oneline")]
            [TestCase("decorate")]
            public void HasNotRequestedData(string name)
            {
                argument.HasOptions(name, 0).Should().BeFalse();
            }
        }

        public class SwitchingBranches
        {
            private readonly Argument argument;

            public SwitchingBranches()
            {
                argument = Argument.Parse("commit", "-am", "made a change");
            }

            [Test]
            public void HasAnyVerb()
            {
                argument.HasVerbs().Should().BeTrue();
            }

            [Test]
            public void HasOneVerb()
            {
                argument.CountVerbs().Should().Be(1);
            }

            [Test]
            public void HasRequestedVerb()
            {
                argument.GetVerb().Should().Be("commit");
            }

            [Test]
            public void HasOptions()
            {
                argument.HasOptions().Should().BeTrue();
            }

            [Test]
            public void HasTwoOptions()
            {
                argument.CountOptions().Should().Be(2);
            }

            [Test]
            [TestCase("a")]
            [TestCase("m")]
            public void HasRequestedOptions(string name)
            {
                argument.HasOptions(name).Should().BeTrue();
            }

            [Test]
            [TestCase("a", 0)]
            [TestCase("m", 1)]
            public void HasNotRequestedData(string name, int index)
            {
                argument.HasOptions(name, index).Should().BeFalse();
            }

            [Test]
            [TestCase("m", 0)]
            public void HasRequestedData(string name, int index)
            {
                argument.HasOptions(name, index).Should().BeTrue();
            }

            [Test]
            public void HasRequestedValue()
            {
                argument.GetOption("m").Should().Be("made a change");
            }
        }

        public class TrackingBranches
        {
            private readonly Argument argument;

            public TrackingBranches()
            {
                argument = Argument.Parse("checkout", "--track", "origin/serverfix");
            }

            [Test]
            public void HasAnyVerb()
            {
                argument.HasVerbs().Should().BeTrue();
            }

            [Test]
            public void HasOneVerb()
            {
                argument.CountVerbs().Should().Be(1);
            }

            [Test]
            public void HasRequestedVerb()
            {
                argument.GetVerb().Should().Be("checkout");
            }

            [Test]
            public void HasOptions()
            {
                argument.HasOptions().Should().BeTrue();
            }

            [Test]
            public void HasRequestedOption()
            {
                argument.HasOptions("track").Should().BeTrue();
            }

            [Test]
            public void HasRequestedData()
            {
                argument.HasOptions("track", 0).Should().BeTrue();
            }

            [Test]
            public void HasRequestedValue()
            {
                argument.GetOption("track").Should().Be("origin/serverfix");
            }
        }
    }
}