using System.Collections.Immutable;

namespace ImmutableUpdatePatterns.Models;

public record Inn(string Name, ImmutableHashSet<Room> Rooms);