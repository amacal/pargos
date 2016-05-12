using FluentAssertions;
using NUnit.Framework;

namespace Pargos.Tests
{
    [TestFixture]
    public class ScopeTests
    {
        [Test]
        public void ScopeFromNothingShouldHaveNoArguments()
        {
            string[] args = { };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            ArgumentCollection scope = collection.Scope("abc");
            bool any = scope.Any();

            any.Should().BeFalse();
        }

        [Test]
        public void ScopeFromNotAvailableNameShouldHaveNoArguments()
        {
            string[] args = { "abc", "-a", "--ab" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            ArgumentCollection scope = collection.Scope("abc");
            bool any = scope.Any();

            any.Should().BeFalse();
        }

        [Test]
        public void ScopeFromNameWithoutValuesShouldHaveNoArguments()
        {
            string[] args = { "abc", "--abc", "--ab" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            ArgumentCollection scope = collection.Scope("abc");
            bool any = scope.Any();

            any.Should().BeFalse();
        }

        [Test]
        public void ScopeFromNameWithValuesShouldHaveTwoArguments()
        {
            string[] args = { "abc", "--abc", "1", "2", "--ab" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            ArgumentCollection scope = collection.Scope("abc");
            int count = scope.Count();

            count.Should().Be(2);
        }

        [Test]
        public void ScopeFromNestedNamesShouldContainIt()
        {
            string[] args = { "abc", "--abc", "1", "--abc-test", "--ab" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            ArgumentCollection scope = collection.Scope("abc");
            string[] names = scope.Names();

            names.Should().ContainSingle("test");
        }

        [Test]
        public void ScopeFromNestedNamesShouldNotConsiderNamesWithoutDash()
        {
            string[] args = { "abc", "--abc", "1", "--abctest", "--ab" };
            ArgumentCollection collection = ArgumentFactory.Parse(args);

            ArgumentCollection scope = collection.Scope("abc");
            string[] names = scope.Names();

            names.Should().BeEmpty();
        }
    }
}