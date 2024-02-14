// See https://aka.ms/new-console-template for more information

using Crdts.Domain.Registers.Implementations;

Console.WriteLine("Hello, CRDTs!");

var lastWriteWinsRegister = new LastWriteWinsRegister<int>("1", ("2", 0, 1));

lastWriteWinsRegister.Set(2);
lastWriteWinsRegister.Set(3);
lastWriteWinsRegister.Set(4);

var value = lastWriteWinsRegister.Get();

Console.WriteLine(value);

lastWriteWinsRegister.Merge(("2", 4, 2));

var valueTwo = lastWriteWinsRegister.Get();

Console.WriteLine(valueTwo);

Console.ReadLine();