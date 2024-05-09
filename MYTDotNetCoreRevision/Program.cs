// See https://aka.ms/new-console-template for more information
using MYTDotNetCoreRevision.AdoDotNet;
using MYTDotNetCoreRevision.Dapper;

Console.WriteLine("Hello, World!");

//ExampleAdo exampleAdo = new ExampleAdo();
//exampleAdo.Run();

DapperExample dapperExample = new DapperExample();
dapperExample.Run();
Console.ReadKey();