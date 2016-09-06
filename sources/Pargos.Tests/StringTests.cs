using FluentAssertions;
using NUnit.Framework;

namespace Pargos.Core.Tests
{
    [TestFixture]
    public class StringTests
    {
        [Test]
        public void StringOnUsageShouldReturnNull()
        {
            string[] args = GitFixture.Usage;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            string value = collection.GetString(0);

            value.Should().BeNull();
        }

        [Test]
        public void StringOnGitCommitShouldReturnNull()
        {
            string[] args = GitFixture.Commit;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            string value = collection.GetString("amend");

            value.Should().BeNull();
        }

        [Test]
        public void StringOnGitCommitShouldReturnCommandName()
        {
            string[] args = GitFixture.Commit;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            string value = collection.GetString(0);

            value.Should().Be("commit");
        }

        [Test]
        public void StringOnGitCommitShouldReturnMessage()
        {
            string[] args = GitFixture.Commit;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            string value = collection.GetString("m");

            value.Should().Be("Great feature");
        }

        [Test]
        public void StringByGitConfigShouldReturnEmail()
        {
            string[] args = GitFixture.Config;
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            string value = collection.GetString("add", 1);

            value.Should().Be("me@example.com");
        }
    }
}