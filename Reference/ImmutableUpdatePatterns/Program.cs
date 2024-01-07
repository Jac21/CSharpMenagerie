// See https://aka.ms/new-console-template for more information

using System.Collections.Immutable;
using ImmutableUpdatePatterns.Models;

Console.WriteLine("Hello, Immutable Update Patterns!");

// unidirectional data flow, aka, a reducer
(Inn Inn, int RoomId) ReserveRoom(Inn inn)
{
    var room = inn
        .Rooms
        .FirstOrDefault(r => r.Available) ?? throw new InvalidOperationException("No rooms available");

    return (inn with
    {
        Rooms = inn.Rooms
            .Remove(room)
            .Add(room with
            {
                Available = false
            })
    }, room.Id);
}

// creating a reserving a new Inn
Inn myInn = new("Inn at the Presidio",
    Enumerable.Range(0, 50)
        .Select(x => new Room(x + 100, true))
        .ToImmutableHashSet());

var (resultInn, resultInnId) = ReserveRoom(myInn);

Console.WriteLine($"Result Inn Name - {resultInn.Name}");
Console.WriteLine($"Result Inn ID - {resultInnId}");
Console.ReadLine();