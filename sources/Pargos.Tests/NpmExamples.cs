using FluentAssertions;
using NUnit.Framework;

namespace Pargos.Tests
{
    public class NpmExamples
    {
        public class UpdateNpm
        {
            private readonly NpmOptions options;

            public UpdateNpm()
            {
                options = Argument.Parse<NpmOptions>("install", "npm@latest", "-g");
            }

            [Test]
            public void IsNotNull()
            {
                options.Should().NotBeNull();
            }

            [Test]
            public void HasInstallOptions()
            {
                options.Install.Should().NotBeNull();
            }

            [Test]
            public void HasGlobalMode()
            {
                options.Install.IsGlobalMode.Should().BeTrue();
            }

            [Test]
            public void HasOneDependency()
            {
                options.Install.Dependencies.Should().HaveCount(1);
            }

            [Test]
            public void HasPackageDependency()
            {
                options.Install.Dependencies.Should().Contain("npm@latest");
            }
        }

        public class FindNpmDirectory
        {
            private readonly NpmOptions options;

            public FindNpmDirectory()
            {
                options = Argument.Parse<NpmOptions>("config", "get", "prefix");
            }

            [Test]
            public void IsNotNull()
            {
                options.Should().NotBeNull();
            }

            [Test]
            public void HasInstallOptions()
            {
                options.Config.Should().NotBeNull();
            }

            [Test]
            public void HasNoGlobalMode()
            {
                options.Config.IsGlobalMode.Should().BeFalse();
            }

            [Test]
            public void IsGetCommand()
            {
                options.Config.Command.Should().Be("get");
            }

            [Test]
            public void HasRequestedKey()
            {
                options.Config.Key.Should().Be("prefix");
            }

            [Test]
            public void HasNoValue()
            {
                options.Config.Value.Should().BeNull();
            }
        }

        public class NpmOptions
        {
            [Parameter, At(0)]
            [Match("config")]
            public NpmConfigOptions Config { get; set; }

            [Parameter, At(0)]
            [Match("install")]
            public NpmInstallOptions Install { get; set; }
        }

        public class NpmConfigOptions
        {
            [Parameter, At(1)]
            public string Command { get; set; }

            [Parameter, At(2)]
            public string Key { get; set; }

            [Parameter, At(3)]
            public string Value { get; set; }

            [Presence]
            [Option("-g")]
            [Option("--global")]
            public bool IsGlobalMode { get; set; }
        }

        public class NpmInstallOptions
        {
            [Parameter, After(1)]
            public string[] Dependencies { get; set; }

            [Presence]
            [Option("-g")]
            [Option("--global")]
            public bool IsGlobalMode { get; set; }
        }
    }
}