using FluentAssertions;
using NUnit.Framework;

namespace Pargos.Tests
{
    public static class GitBranching
    {
        public class BranchesInANutshell
        {
            private readonly Argument argument;
            private readonly ArgumentView view;

            public BranchesInANutshell()
            {
                argument = new Argument("add", "README", "test.rb", "LICENSE");
                view = new ArgumentView(argument);
            }

            [Test]
            [TestCase(0)]
            [TestCase(1)]
            [TestCase(2)]
            [TestCase(3)]
            public void HasVerb(int index)
            {
                view.HasVerbs(index).Should().BeTrue();
            }

            [Test]
            public void HasFourVerbs()
            {
                view.CountVerbs().Should().Be(4);
            }

            [Test]
            [TestCase(0, "add")]
            [TestCase(1, "README")]
            [TestCase(2, "test.rb")]
            [TestCase(3, "LICENSE")]
            public void HasRequestedVerb(int index, string verb)
            {
                view.GetVerb(index).Should().Be(verb);
            }
        }

        public class CreatingANewBranch
        {
            private readonly Argument argument;
            private readonly ArgumentView view;

            public CreatingANewBranch()
            {
                argument = new Argument("log", "--oneline", "--decorate");
                view = new ArgumentView(argument);
            }

            [Test]
            public void HasAnyVerb()
            {
                view.HasVerbs().Should().BeTrue();
            }

            [Test]
            public void HasOneVerb()
            {
                view.CountVerbs().Should().Be(1);
            }

            [Test]
            public void HasRequestedVerb()
            {
                view.GetVerb().Should().Be("log");
            }

            [Test]
            public void HasOptions()
            {
                view.HasOptions().Should().BeTrue();
            }

            [Test]
            public void HasTwoOptions()
            {
                view.CountOptions().Should().Be(2);
            }

            [Test]
            [TestCase("oneline")]
            [TestCase("decorate")]
            public void HasRequestedOptions(string name)
            {
                view.HasOptions(name).Should().BeTrue();
            }

            [Test]
            [TestCase("oneline")]
            [TestCase("decorate")]
            public void HasNotRequestedData(string name)
            {
                view.HasOptions(name, 0).Should().BeFalse();
            }
        }

        public class SwitchingBranches
        {
            private readonly Argument argument;
            private readonly ArgumentView view;

            public SwitchingBranches()
            {
                argument = new Argument("commit", "-am", "made a change");
                view = new ArgumentView(argument);
            }

            [Test]
            public void HasAnyVerb()
            {
                view.HasVerbs().Should().BeTrue();
            }

            [Test]
            public void HasOneVerb()
            {
                view.CountVerbs().Should().Be(1);
            }

            [Test]
            public void HasRequestedVerb()
            {
                view.GetVerb().Should().Be("commit");
            }

            [Test]
            public void HasOptions()
            {
                view.HasOptions().Should().BeTrue();
            }

            [Test]
            public void HasTwoOptions()
            {
                view.CountOptions().Should().Be(2);
            }

            [Test]
            [TestCase("a")]
            [TestCase("m")]
            public void HasRequestedOptions(string name)
            {
                view.HasOptions(name).Should().BeTrue();
            }

            [Test]
            [TestCase("a", 0)]
            [TestCase("m", 1)]
            public void HasNotRequestedData(string name, int index)
            {
                view.HasOptions(name, index).Should().BeFalse();
            }

            [Test]
            [TestCase("m", 0)]
            public void HasRequestedData(string name, int index)
            {
                view.HasOptions(name, index).Should().BeTrue();
            }

            [Test]
            public void HasRequestedValue()
            {
                view.GetOption("m").Should().Be("made a change");
            }
        }

        public class TrackingBranches
        {
            private readonly Argument argument;
            private readonly ArgumentView view;

            public TrackingBranches()
            {
                argument = new Argument("checkout", "--track", "origin/serverfix");
                view = new ArgumentView(argument);
            }

            [Test]
            public void HasAnyVerb()
            {
                view.HasVerbs().Should().BeTrue();
            }

            [Test]
            public void HasOneVerb()
            {
                view.CountVerbs().Should().Be(1);
            }

            [Test]
            public void HasRequestedVerb()
            {
                view.GetVerb().Should().Be("checkout");
            }

            [Test]
            public void HasOptions()
            {
                view.HasOptions().Should().BeTrue();
            }

            [Test]
            public void HasRequestedOption()
            {
                view.HasOptions("track").Should().BeTrue();
            }

            [Test]
            public void HasRequestedData()
            {
                view.HasOptions("track", 0).Should().BeTrue();
            }

            [Test]
            public void HasRequestedValue()
            {
                view.GetOption("track").Should().Be("origin/serverfix");
            }
        }
    }
}