using FluentAssertions;
using NUnit.Framework;

namespace Pargos.Tests
{
    public static class GitBasics
    {
        public class InitializeRepositoryInAnExistingDirectory
        {
            private readonly Argument argument;

            public InitializeRepositoryInAnExistingDirectory()
            {
                argument = Argument.Parse("init");
            }

            [Test]
            public void HasOneParameter()
            {
                argument.Parameters.Should().Be(1);
            }

            [Test]
            public void HasRequestedParameter()
            {
                argument[0].Should().Be("init");
            }

            [Test]
            public void HasNoOptions()
            {
                argument.Options.Should().Be(0);
            }

            [Test]
            public void HasNoTail()
            {
                argument.Tail.Should().Be(0);
            }
        }

        public class CloningAnExistingRepository
        {
            private readonly Argument argument;

            public CloningAnExistingRepository()
            {
                argument = Argument.Parse("clone", "https://github.com/libgit2/libgit2", "mylibgit");
            }

            [Test]
            public void HasThreeParameters()
            {
                argument.Parameters.Should().Be(3);
            }

            [Test]
            [TestCase(0, "clone")]
            [TestCase(1, "https://github.com/libgit2/libgit2")]
            [TestCase(2, "mylibgit")]
            public void HasRequestedParameters(int index, string parameter)
            {
                argument[index].Should().Be(parameter);
            }

            [Test]
            public void HasNoOptions()
            {
                argument.Options.Should().Be(0);
            }

            [Test]
            public void HasNoTail()
            {
                argument.Tail.Should().Be(0);
            }
        }

        public class CheckingTheStatusOfYourFiles
        {
            private readonly Argument argument;

            public CheckingTheStatusOfYourFiles()
            {
                argument = Argument.Parse("status", "--cached");
            }

            [Test]
            public void HasOneParameter()
            {
                argument.Parameters.Should().Be(1);
            }

            [Test]
            public void HasRequestedParameter()
            {
                argument[0].Should().Be("status");
            }

            [Test]
            public void HasOneOption()
            {
                argument.Options.Should().Be(1);
            }

            [Test]
            public void HasRequestedOption()
            {
                argument["--cached"].Should().NotBeNull();
                argument["--cached"].Should().BeEmpty();
            }

            [Test]
            public void HasNoTail()
            {
                argument.Tail.Should().Be(0);
            }
        }

        public class ShortStatus
        {
            private readonly Argument argument;

            public ShortStatus()
            {
                argument = Argument.Parse("status", "-s");
            }

            [Test]
            public void HasOneParameter()
            {
                argument.Parameters.Should().Be(1);
            }

            [Test]
            public void HasRequestedParameter()
            {
                argument[0].Should().Be("status");
            }

            [Test]
            public void HasOneOption()
            {
                argument.Options.Should().Be(1);
            }

            [Test]
            public void HasRequestedOption()
            {
                argument["-s"].Should().NotBeNull();
                argument["-s"].Should().BeEmpty();
            }

            [Test]
            public void HasNoTail()
            {
                argument.Tail.Should().Be(0);
            }
        }

        public class CommittingYourChanges
        {
            private readonly Argument argument;

            public CommittingYourChanges()
            {
                argument = Argument.Parse("commit", "-m", "Story 182: Fix benchmarks for speed");
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
            public void HasOneOption()
            {
                argument.Options.Should().Be(1);
            }

            [Test]
            public void HasRequestedOption()
            {
                argument["-m"].Should().NotBeNull();
                argument["-m"].Should().HaveCount(1);
                argument["-m"].Should().Contain("Story 182: Fix benchmarks for speed");
            }

            [Test]
            public void HasNoTail()
            {
                argument.Tail.Should().Be(0);
            }
        }

        public class ViewingTheCommitHistory
        {
            private readonly Argument argument;

            public ViewingTheCommitHistory()
            {
                argument = Argument.Parse("log", "--pretty", @"format:""%h - %an, %ar : %s""");
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
            public void HasOneOption()
            {
                argument.Options.Should().Be(1);
            }

            [Test]
            public void HasRequestedOption()
            {
                argument["--pretty"].Should().NotBeNull();
                argument["--pretty"].Should().HaveCount(1);
                argument["--pretty"].Should().Contain(@"format:""%h - %an, %ar : %s""");
            }

            [Test]
            public void HasNoTail()
            {
                argument.Tail.Should().Be(0);
            }
        }

        public class UnmodifyingAModifiedFile
        {
            private readonly Argument argument;

            public UnmodifyingAModifiedFile()
            {
                argument = Argument.Parse("checkout", "--", "CONTRIBUTING.md");
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
            public void HasNoOption()
            {
                argument.Options.Should().Be(0);
            }

            [Test]
            public void HasOneTail()
            {
                argument.Tail.Should().Be(1);
            }

            [Test]
            public void HasRequestedTail()
            {
                argument[-1].Should().Be("CONTRIBUTING.md");
            }
        }
    }
}