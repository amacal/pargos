using FluentAssertions;
using NUnit.Framework;

namespace Pargos.Tests
{
    [TestFixture]
    public class AvailabilityTests
    {
        [Test]
        public void HasOnGitUsageShouldReturnFalse()
        {
            string[] args = GitFixture.Usage;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool result = collection.Has(0);

            result.Should().BeFalse();
        }

        [Test]
        public void HasOnGitPullShouldReturnTrue()
        {
            string[] args = GitFixture.Pull;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool result = collection.Has(0);

            result.Should().BeTrue();
        }

        [Test]
        public void HasOnGitPullShouldReturnFalse()
        {
            string[] args = GitFixture.Pull;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool result = collection.Has(3);

            result.Should().BeFalse();
        }

        [Test]
        public void HasOnGitCommitShouldReturnTrue()
        {
            string[] args = GitFixture.Commit;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool result = collection.Has("a");

            result.Should().BeTrue();
        }

        [Test]
        public void HasOnGitCommitShouldReturnTrueWhenCalledOnAmend()
        {
            string[] args = GitFixture.Commit;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool result = collection.Has("amend");

            result.Should().BeTrue();
        }

        [Test]
        public void HasOnGitResetShouldReturnTrue()
        {
            string[] args = GitFixture.Reset;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool result = collection.Has("hard");

            result.Should().BeTrue();
        }

        [Test]
        public void HasOnGitResetShouldReturnFalse()
        {
            string[] args = GitFixture.Reset;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool result = collection.Has("soft");

            result.Should().BeFalse();
        }

        [Test]
        public void HasOnGitCommitShouldReturnFalseWhenCalledOnAmendWithIndex()
        {
            string[] args = GitFixture.Commit;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool result = collection.Has("amend", 0);

            result.Should().BeFalse();
        }

        [Test]
        public void HasOnGitCommitShouldReturnTrueWhenCalledOnMessageWithIndex()
        {
            string[] args = GitFixture.Commit;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool result = collection.Has("m", 0);

            result.Should().BeTrue();
        }

        [Test]
        public void HasOnGitCommitShouldReturnFalseWhenCalledOnAddWithIndex()
        {
            string[] args = GitFixture.Commit;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool result = collection.Has("a", 0);

            result.Should().BeFalse();
        }
    }
}