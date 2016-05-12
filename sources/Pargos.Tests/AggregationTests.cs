using FluentAssertions;
using NUnit.Framework;

namespace Pargos.Tests
{
    [TestFixture]
    public class AggregationTests
    {
        [Test]
        public void AnyShouldReturnFalse()
        {
            string[] args = { };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool any = collection.Any();

            any.Should().BeFalse();
        }

        [Test]
        public void AnyShouldReturnTrue()
        {
            string[] args = { "abc", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool any = collection.Any();

            any.Should().BeTrue();
        }

        [Test]
        public void CountShouldReturnZero()
        {
            string[] args = { };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            int count = collection.Count();

            count.Should().Be(0);
        }

        [Test]
        public void CountShouldReturnTwo()
        {
            string[] args = { "abc", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            int count = collection.Count();

            count.Should().Be(2);
        }

        [Test]
        public void CountShouldIgnoreNamedArguments()
        {
            string[] args = { "-ab", "abc", "--be", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            int count = collection.Count();

            count.Should().Be(0);
        }

        [Test]
        public void CountNamesShouldReturnZeroWhenNameIsNotAvailable()
        {
            string[] args = { "-ab", "abc", "--be", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            int count = collection.Count("ce");

            count.Should().Be(0);
        }

        [Test]
        public void CountNamesShouldReturnOne()
        {
            string[] args = { "-ab", "abc", "--be", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            int count = collection.Count("b");

            count.Should().Be(1);
        }

        [Test]
        public void CountNamesShouldReturnTwo()
        {
            string[] args = { "-ab", "abc", "--be", "cde", "efg" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            int count = collection.Count("be");

            count.Should().Be(2);
        }

        [Test]
        public void CountNamesShouldConsiderSplits()
        {
            string[] args = { "-ab", "abc", "--be", "cde", "-g", "--be", "efg" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            int count = collection.Count("be");

            count.Should().Be(2);
        }
    }
}