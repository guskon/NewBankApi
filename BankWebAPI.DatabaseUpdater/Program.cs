﻿using DbUp;
using System.Reflection;

var connectionString =
        args.FirstOrDefault()
        ?? "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=naujasPW150";

EnsureDatabase.For.PostgresqlDatabase(connectionString);

var upgrader =
    DeployChanges.To
        .PostgresqlDatabase(connectionString)
        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
        .LogToConsole()
        .Build();

var result = upgrader.PerformUpgrade();

if (!result.Successful)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(result.Error);
    Console.ResetColor();
#if DEBUG
    Console.ReadLine();
#endif
    return -1;
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Success!");
Console.ResetColor();
return 0;
