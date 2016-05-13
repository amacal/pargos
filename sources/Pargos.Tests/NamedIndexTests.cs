using FluentAssertions;
using NUnit.Framework;

namespace Pargos.Tests
{
    [TestFixture]
    public class NamedIndexTests
    {
        [Test]
        public void ValueOnGitCommitShouldReturnNullWhenCalledOnAdd()
        {
            string[] args = GitFixture.Commit;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value("a");

            argument.Value.Should().BeNull();
        }

        [Test]
        public void ValueOnGitCommitShouldReturnItWhenCalledOnMessage()
        {
            string[] args = GitFixture.Commit;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value("m");

            argument.Value.Should().Be("Great feature");
        }

        [Test]
        public void ValueOnGitConfigShouldReturnIt()
        {
            string[] args = GitFixture.Config;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value("add");

            argument.Value.Should().Be("user.email");
        }

        [Test]
        public void ValueOnGitConfigShouldReturnItWhenCalledWithIndex()
        {
            string[] args = GitFixture.Config;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value("add", 1);

            argument.Value.Should().Be("me@example.com");
        }

        [Test]
        public void ValueOnGitConfigShouldReturnNullWhenNotAvailable()
        {
            string[] args = GitFixture.Config;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value("add", 2);

            argument.Should().BeNull();
        }

        [Test]
        public void ValueOnGitConfigShouldReturnNullWhenNotAvailableWithNegativeIndex()
        {
            string[] args = GitFixture.Config;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value("add", -3);

            argument.Should().BeNull();
        }

        [Test]
        public void ValueOnGitConfigShouldReturnItWhenCalledNegativeIndex()
        {
            string[] args = GitFixture.Config;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value("add", -1);

            argument.Value.Should().Be("me@example.com");
        }
    }
}