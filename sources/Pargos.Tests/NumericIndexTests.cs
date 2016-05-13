using FluentAssertions;
using NUnit.Framework;

namespace Pargos.Tests
{
    [TestFixture]
    public class NumericIndexTests
    {
        [Test]
        public void GetValueOnGitCommitShouldReturnIt()
        {
            string[] args = GitFixture.Commit;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value(0);

            argument.Value.Should().Be("commit");
        }

        [Test]
        public void GetValueOnGitCommitShouldReturnNull()
        {
            string[] args = GitFixture.Commit;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value(2);

            argument.Should().BeNull();
        }

        [Test]
        public void GetValueOnGitPullShouldReturnIt()
        {
            string[] args = GitFixture.Pull;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value(-1);

            argument.Value.Should().Be("master");
        }

        [Test]
        public void GetValueOnGitPullShouldReturnNull()
        {
            string[] args = GitFixture.Pull;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value(-4);

            argument.Should().BeNull();
        }
    }
}