// See https://aka.ms/new-console-template for more information

using System.Linq.Expressions;
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, Caller!");

// Using CallerFilePathAttribute
FilePath();

static void FilePath([CallerFilePath] string filepath = "")
{
    Console.WriteLine(
        $"File path: {filepath}"); // File path: /Users/jeremycantu/Documents/GitHub/CSharpMenagerie/Reflection/CallerMetadataExamples/Program.cs
}

// Using CallerMemberNameAttribute
// Deriving what member invoked the current method
WhoCalled();

static void WhoCalled([CallerMemberName] string name = "")
{
    Console.WriteLine($"Invoker name: {name}"); // Invoker name: <Main>$
}

// Using CallerLineNumberAttribute
WhereCalled();

static void WhereCalled([CallerLineNumber] int lineNumber = 0)
{
    Console.WriteLine($"Invoker line number: {lineNumber}"); // Invoker line number: 26
}

// Using CallerArgumentExpressionAttribute
const int math = 3 * 3;
Express(math);

Express(3 * 3);

static void Express(int res, [CallerArgumentExpression("res")] string expression = "")
{
    Console.WriteLine($"{expression} is {res}");

    // math is 9
    // 3 * 3 is 9
}

Console.ReadLine();