// See https://aka.ms/new-console-template for more information
using System.Collections;

Console.WriteLine("Hello, World!");

Console.WriteLine();
Console.WriteLine("Args");

foreach (var arg in args)
{
    Console.WriteLine($" - {arg}");
}

Console.WriteLine();
Console.WriteLine("Environment Vars (Current Process)");

IDictionary dict = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process);
foreach (var key in dict.Keys)
{
    string val = dict[key].ToString();
    Console.WriteLine($" {key} = {val}");
}


Console.WriteLine();
Console.WriteLine("Environment Vars (User)");

dict = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User);
foreach (var key in dict.Keys)
{
    string val = dict[key].ToString();
    Console.WriteLine($" {key} = {val}");
}


Console.WriteLine();
Console.WriteLine("Environment Vars (Machine)");

dict = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine);
foreach (var key in dict.Keys)
{
    string val = dict[key].ToString();
    Console.WriteLine($" {key} = {val}");
}

Console.WriteLine();
