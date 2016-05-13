using FluentAssertions;
using NUnit.Framework;

namespace Pargos.Tests
{
    [TestFixture]
    public class ScopeTests
    {
        [Test]
        public void ScopeOnGitUsageShouldBeEmpty()
        {
            string[] args = GitFixture.Usage;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            ArgumentCollection scope = collection.Scope("abc");
            bool any = scope.Any();

            any.Should().BeFalse();
        }

        [Test]
        public void ScopeOnGitCommitShouldHaveSomething()
        {
            string[] args = GitFixture.Commit;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            ArgumentCollection scope = collection.Scope("no");
            bool any = scope.Any();

            any.Should().BeTrue();
        }
    }
}