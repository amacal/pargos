using FluentAssertions;
using NUnit.Framework;

namespace Pargos.Tests
{
    [TestFixture]
    public class NumericIndexTests
    {
        [Test]
        public void GetValueByIndexShouldReturnIt()
        {
            string[] args = { "abc", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value(0);

            argument.Value.Should().Be("abc");
        }

        [Test]
        public void GetValueByIndexShouldReturnNull()
        {
            string[] args = { "abc", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value(2);

            argument.Should().BeNull();
        }

        [Test]
        public void GetValueByNegativeIndexShouldReturnIt()
        {
            string[] args = { "abc", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value(-1);

            argument.Value.Should().Be("cde");
        }

        [Test]
        public void GetValueByNegativeIndexShouldReturnNull()
        {
            string[] args = { "abc", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            Argument argument = collection.Value(-3);

            argument.Should().BeNull();
        }
    }
}