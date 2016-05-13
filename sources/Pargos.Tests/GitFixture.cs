namespace Pargos.Tests
{
    public static class GitFixture
    {
        public static readonly string[] Usage = { };

        public static readonly string[] Pull = { "pull", "origin", "master" };

        public static readonly string[] Commit = { "commit", "-am", "Great feature", "--amend", "--no-verify", "--no-post-rewrite" };

        public static readonly string[] Reset = { "reset", "--hard" };

        public static readonly string[] Config = { "config", "--global", "--add", "user.email", "me@example.com" };
    }
}