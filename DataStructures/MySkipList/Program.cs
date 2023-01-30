// See https://aka.ms/new-console-template for more information

using MySkipList.Core;

Console.WriteLine("Hello, Skip List!");

var skipList = new SkipList();

skipList.Insert(100);
skipList.Insert(250);
skipList.Insert(150);

skipList.Remove(250);

Console.WriteLine(skipList.Contains(100));

foreach (var entry in skipList.Enumerate())
{
    Console.WriteLine(entry);
}