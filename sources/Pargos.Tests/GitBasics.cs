using FluentAssertions;
using NUnit.Framework;

namespace Pargos.Tests
{
    public class GitBasics
    {
        public class InitializeRepositoryInAnExistingDirectory
        {
            private readonly Argument argument;

            public InitializeRepositoryInAnExistingDirectory()
            {
                argument = Argument.Parse("init");
            }

            [Test]
            public void HasAnyVerb()
            {
                argument.Verbs.Should().NotBeEmpty();
            }

            [Test]
            public void HasOneVerb()
            {
                argument.Verbs.Should().HaveCount(1);
            }

            [Test]
            public void HasRequestedVerb()
            {
                argument.Verbs.Should().Contain("init");
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
            public void HasAnyVerb()
            {
                argument.Verbs.Should().NotBeEmpty();
            }

            [Test]
            public void HasThreeVerbs()
            {
                argument.Verbs.Should().HaveCount(3);
            }

            [Test]
            [TestCase(0, "clone")]
            [TestCase(1, "https://github.com/libgit2/libgit2")]
            [TestCase(2, "mylibgit")]
            public void HasRequestedVerb(int index, string verb)
            {
                argument.Verbs.Should().HaveElementAt(index, verb);
            }
        }

        public class CheckingTheStatusOfYourFiles
        {
            private readonly Argument argument;

            public CheckingTheStatusOfYourFiles()
            {
                argument = Argument.Parse("status");
            }

            [Test]
            public void HasAnyVerb()
            {
                argument.Verbs.Should().NotBeEmpty();
            }

            [Test]
            public void HasOneVerb()
            {
                argument.Verbs.Should().HaveCount(1);
            }

            [Test]
            public void HasRequestedVerb()
            {
                argument.Verbs.Should().Contain("status");
            }
        }

        public class TrackingNewFiles
        {
            private readonly Argument argument;

            public TrackingNewFiles()
            {
                argument = Argument.Parse("add", "README");
            }

            [Test]
            public void HasAnyVerb()
            {
                argument.Verbs.Should().NotBeEmpty();
            }

            [Test]
            public void HasTwoVerbs()
            {
                argument.Verbs.Should().HaveCount(2);
            }

            [Test]
            [TestCase(0, "add")]
            [TestCase(1, "README")]
            public void HasRequestedVerb(int index, string verb)
            {
                argument.Verbs.Should().HaveElementAt(index, verb);
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
            public void HasAnyVerb()
            {
                argument.Verbs.Should().NotBeEmpty();
            }

            [Test]
            public void HasOneVerbs()
            {
                argument.Verbs.Should().HaveCount(1);
            }

            [Test]
            public void HasOneShortOption()
            {
                argument.Short.Should().HaveCount(1);
            }

            [Test]
            public void HasRequestedShortOption()
            {
                argument.Short.Should().Contain("s");
            }
        }

        public class ViewingYourStagedAndUnstagedChanges
        {
            private readonly Argument argument;

            public ViewingYourStagedAndUnstagedChanges()
            {
                argument = Argument.Parse("diff", "--staged");
            }

            [Test]
            public void HasAnyVerb()
            {
                argument.Verbs.Should().NotBeEmpty();
            }

            [Test]
            public void HasOneVerbs()
            {
                argument.Verbs.Should().HaveCount(1);
            }

            [Test]
            public void HasNoShortOption()
            {
                argument.Short.Should().BeEmpty();
            }

            [Test]
            public void HasOneLongOption()
            {
                argument.Long.Should().HaveCount(1);
            }

            [Test]
            public void HasRequestedLongOption()
            {
                argument.Long.Should().Contain("staged");
            }
        }

        public class CommittingYourChanges
        {
            private readonly Argument argument;

            public CommittingYourChanges()
            {
                argument = Argument.Parse("commit", "-m", @"""Story 182: Fix benchmarks for speed""");
            }

            [Test]
            public void HasAnyVerb()
            {
                argument.Verbs.Should().NotBeEmpty();
            }

            [Test]
            public void HasOneVerbs()
            {
                argument.Verbs.Should().HaveCount(1);
            }

            [Test]
            public void HasOneShortOption()
            {
                argument.Short.Should().HaveCount(1);
            }

            [Test]
            public void HasRequestedShortOption()
            {
                argument.Short.Should().Contain("m");
            }

            [Test]
            public void HasNoLongOption()
            {
                argument.Long.Should().BeEmpty();
            }

            [Test]
            public void HasOneValue()
            {
                argument["m"].Should().HaveCount(1);
            }

            [Test]
            public void HasRequestedValue()
            {
                argument["m"].Should().Contain(@"""Story 182: Fix benchmarks for speed""");
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
            public void HasAnyVerb()
            {
                argument.Verbs.Should().NotBeEmpty();
            }

            [Test]
            public void HasOneVerbs()
            {
                argument.Verbs.Should().HaveCount(1);
            }

            [Test]
            public void HasNoShortOption()
            {
                argument.Short.Should().BeEmpty();
            }

            [Test]
            public void HasOneLongOption()
            {
                argument.Long.Should().HaveCount(1);
            }

            [Test]
            public void HasRequestedLongOption()
            {
                argument.Long.Should().Contain("pretty");
            }

            [Test]
            public void HasOneValue()
            {
                argument["pretty"].Should().HaveCount(1);
            }

            [Test]
            public void HasRequestedValue()
            {
                argument["pretty"].Should().Contain(@"format:""%h - %an, %ar : %s""");
            }
        }

        public class LimitingTheOutput
        {
            private readonly Argument argument;

            public LimitingTheOutput()
            {
                argument = Argument.Parse("log", "--since", "2.weeks");
            }

            [Test]
            public void HasAnyVerb()
            {
                argument.Verbs.Should().NotBeEmpty();
            }

            [Test]
            public void HasOneVerbs()
            {
                argument.Verbs.Should().HaveCount(1);
            }

            [Test]
            public void HasNoShortOption()
            {
                argument.Short.Should().BeEmpty();
            }

            [Test]
            public void HasOneLongOption()
            {
                argument.Long.Should().HaveCount(1);
            }

            [Test]
            public void HasRequestedLongOption()
            {
                argument.Long.Should().Contain("since");
            }

            [Test]
            public void HasOneValue()
            {
                argument["since"].Should().HaveCount(1);
            }

            [Test]
            public void HasRequestedValue()
            {
                argument["since"].Should().Contain("2.weeks");
            }
        }

        public class UndoingThings
        {
            private readonly Argument argument;

            public UndoingThings()
            {
                argument = Argument.Parse("commit", "--amend");
            }

            [Test]
            public void HasAnyVerb()
            {
                argument.Verbs.Should().NotBeEmpty();
            }

            [Test]
            public void HasOneVerbs()
            {
                argument.Verbs.Should().HaveCount(1);
            }

            [Test]
            public void HasNoShortOption()
            {
                argument.Short.Should().BeEmpty();
            }

            [Test]
            public void HasOneLongOption()
            {
                argument.Long.Should().HaveCount(1);
            }

            [Test]
            public void HasRequestedLongOption()
            {
                argument.Long.Should().Contain("amend");
            }

            [Test]
            public void HasNoValue()
            {
                argument["amend"].Should().BeEmpty();
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
            public void HasAnyVerb()
            {
                argument.Verbs.Should().NotBeEmpty();
            }

            [Test]
            public void HasOneVerbs()
            {
                argument.Verbs.Should().HaveCount(1);
            }

            [Test]
            public void HasNoShortOption()
            {
                argument.Short.Should().BeEmpty();
            }

            [Test]
            public void HasNoLongOption()
            {
                argument.Long.Should().BeEmpty();
            }

            [Test]
            public void HasOneTail()
            {
                argument.Tail.Should().HaveCount(1);
            }

            [Test]
            public void HasRequestedTail()
            {
                argument.Tail.Should().Contain("CONTRIBUTING.md");
            }
        }
    }
}