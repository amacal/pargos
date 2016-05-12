using FluentAssertions;
using NUnit.Framework;

namespace Pargos.Tests
{
    [TestFixture]
    public class NamedIndexTests
    {
        [Test]
        public void GetValueByFirstShortNameShouldReturnNull()
        {
            string[] args = { "-ab", "abc", "--be", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value("a");

            argument.Value.Should().BeNull();
        }

        [Test]
        public void GetValueBySecondShortNameShouldReturnIt()
        {
            string[] args = { "-ab", "abc", "--be", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value("b");

            argument.Value.Should().Be("abc");
        }

        [Test]
        public void GetValueByLongNameShouldReturnIt()
        {
            string[] args = { "-a", "abc", "--be", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value("be");

            argument.Value.Should().Be("cde");
        }

        [Test]
        public void GetValueByNameAndIndexShouldReturnIt()
        {
            string[] args = { "-a", "abc", "--be", "cde", "efg" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value("be", 1);

            argument.Value.Should().Be("efg");
        }

        [Test]
        public void GetValueByNameAndIndexShouldReturnNullWhenIndexIsNotAvailable()
        {
            string[] args = { "-a", "abc", "--be" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value("be", 0);

            argument.Should().BeNull();
        }

        [Test]
        public void GetValueByNameAndIndexShouldReturnNull()
        {
            string[] args = { "-a", "abc", "--be", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value("be", 2);

            argument.Should().BeNull();
        }

        [Test]
        public void getValueByNegativeIndexShouldReturnIt()
        {
            string[] args = { "-a", "abc", "--be", "cde", "efg" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value("be", -1);

            argument.Value.Should().Be("efg");
        }

        [Test]
        public void GetValueByNameAndNegativeIndexShouldReturnNull()
        {
            string[] args = { "-a", "abc", "--be", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value("be", -3);

            argument.Should().BeNull();
        }
    }
}