using FluentAssertions;
using NUnit.Framework;
using System.Linq;

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
            public void HasFourParameters()
            {
                argument.Parameters.Should().Be(4);
            }

            [Test]
            [TestCase(0, "add")]
            [TestCase(1, "README")]
            [TestCase(2, "test.rb")]
            [TestCase(3, "LICENSE")]
            public void HasRequestedParameter(int index, string parameter)
            {
                argument[index].Should().Be(parameter);
            }

            [Test]
            public void HasNoOption()
            {
                argument.Options.Should().Be(0);
            }

            [Test]
            public void HasNoTail()
            {
                argument.Tail.Should().Be(0);
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
            public void HasOneParameter()
            {
                argument.Parameters.Should().Be(1);
            }

            [Test]
            public void HasRequestedParameter()
            {
                argument[0].Should().Be("log");
            }

            [Test]
            public void HasTwoOptions()
            {
                argument.Options.Should().Be(2);
            }

            [Test]
            [TestCase("--oneline")]
            [TestCase("--decorate")]
            public void HasRequestedOptions(string option)
            {
                argument[option].Should().NotBeNull();
            }

            [Test]
            [TestCase("--oneline")]
            [TestCase("--decorate")]
            public void HasNotRequestedData(string option)
            {
                argument[option].Should().BeEmpty();
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
            public void HasOneParameter()
            {
                argument.Parameters.Should().Be(1);
            }

            [Test]
            public void HasRequestedParameter()
            {
                argument[0].Should().Be("commit");
            }

            [Test]
            public void HasTwoOptions()
            {
                argument.Options.Should().Be(2);
            }

            [Test]
            [TestCase("-a")]
            [TestCase("-m")]
            public void HasRequestedOptions(string option)
            {
                argument[option].Should().NotBeNull();
            }

            [Test]
            [TestCase("-a", 0)]
            [TestCase("-m", 1)]
            public void HasNotRequestedData(string option, int index)
            {
                argument[option].ElementAtOrDefault(index).Should().BeNull();
            }

            [Test]
            [TestCase("-m", 0)]
            public void HasRequestedData(string option, int index)
            {
                argument[option].ElementAtOrDefault(index).Should().NotBeNull();
            }

            [Test]
            public void HasRequestedValue()
            {
                argument["-m"].Should().Contain("made a change");
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
            public void HasOneParameter()
            {
                argument.Parameters.Should().Be(1);
            }

            [Test]
            public void HasRequestedParameter()
            {
                argument[0].Should().Be("checkout");
            }

            [Test]
            public void HasOneOption()
            {
                argument.Options.Should().Be(1);
            }

            [Test]
            public void HasRequestedOption()
            {
                argument["--track"].Should().NotBeNull();
                argument["--track"].Should().HaveCount(1);
            }

            [Test]
            public void HasRequestedData()
            {
                argument["--track"].Should().Contain("origin/serverfix");
            }
        }
    }
}