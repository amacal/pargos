# pargos

## indices

```` csharp
string[] args = { "pull", "origin", "master" };
ArgumentCollection collection = ArgumentFactory.Parse(args);

collection.GetString(0); // pull
collection.GetString(1); // origin

collection.GetString(-1); // master
collection.GetString(-2); // origin

collection.GetString(5);  // null
collection.GetString(-5); // null
````

## names
```` csharp
string[] args = { "config", "--global", "--add", "user.email", "me@example.com" };
ArgumentCollection collection = ArgumentFactory.Parse(args);

collection.GetString("add");    // user.email
collection.GetString("add", 1); // me@example.com

collection.GetString("new");    // null
collection.GetString("global"); // null
collection.GetString("add", 2); // null
````

## existence
```` csharp
string[] args = { "config", "--global", "--add", "user.email", "me@example.com" };
ArgumentCollection collection = ArgumentFactory.Parse(args);

collection.Has(0); // true
collection.Has(1); // false

collection.Has("global");    // true
collection.Has("global", 0); // false

collection.Has("add", 1); // true
collection.Has("add", 2); // false
````

## aggregation
```` csharp
string[] args = { "commit", "-am", "Great feature", "--amend", "--no-verify", "--no-post-rewrite" };
ArgumentCollection collection = ArgumentFactory.Parse(args);

collection.Any();   // true
collection.Count(); // 1

collection.Count("a"); // 0
collection.Count("m"); // 1

collection.Count("nothing"); // 0
````

## scope
```` csharp
string[] args = { "commit", "-am", "Great feature", "--amend", "--no-verify", "--no-post-rewrite" };
ArgumentCollection collection = ArgumentFactory.Parse(args);

collection.Scope("no");               // --verify --post-rewrite
collection.Scope("no").Has("verify"); // true