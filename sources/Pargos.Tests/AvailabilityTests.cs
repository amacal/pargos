using FluentAssertions;
using NUnit.Framework;

namespace Pargos.Tests
{
    [TestFixture]
    public class AvailabilityTests
    {
        [Test]
        public void CheckingArgumentByIndexShouldReturnTrue()
        {
            string[] args = { "abc", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool result = collection.Has(0);

            result.Should().BeTrue();
        }

        [Test]
        public void CheckingArgumentByIndexShouldReturnFalse()
        {
            string[] args = { "abc", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool result = collection.Has(2);

            result.Should().BeFalse();
        }

        [Test]
        public void CheckingArgumentByShortNameShouldReturnTrue()
        {
            string[] args = { "-ab", "abc", "--be", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool result = collection.Has("b");

            result.Should().BeTrue();
        }

        [Test]
        public void CheckingArgumentByFirstShortNameShouldReturnTrue()
        {
            string[] args = { "-ab", "abc", "--be", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool result = collection.Has("a");

            result.Should().BeTrue();
        }

        [Test]
        public void CheckingArgumentByLongNameShouldReturnTrue()
        {
            string[] args = { "-ab", "abc", "--be", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool result = collection.Has("be");

            result.Should().BeTrue();
        }

        [Test]
        public void CheckingArgumentByLongNameShouldReturnFalse()
        {
            string[] args = { "-ab", "abc", "--be", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool result = collection.Has("ce");

            result.Should().BeFalse();
        }

        [Test]
        public void CheckingArgumentByLongNameWithoutValuesShouldReturnTrue()
        {
            string[] args = { "-ab", "abc", "--be" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool result = collection.Has("be");

            result.Should().BeTrue();
        }

        [Test]
        public void CheckingArgumentByNameAndIndexShouldReturnFalseWhenNameIsNotAvailable()
        {
            string[] args = { "-ab", "abc", "--be", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool result = collection.Has("ce", 0);

            result.Should().BeFalse();
        }

        [Test]
        public void CheckingArgumentByNameAndIndexShouldReturnTrueWhenIndexIsAvailable()
        {
            string[] args = { "-ab", "abc", "--be", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool result = collection.Has("be", 0);

            result.Should().BeTrue();
        }

        [Test]
        public void CheckingArgumentByNameAndIndexShouldReturnFalseWhenIndexIsNotAvailable()
        {
            string[] args = { "-ab", "abc", "--be", "cde" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            bool result = collection.Has("be", 1);

            result.Should().BeFalse();
        }
    }
}