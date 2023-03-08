namespace JsonSourceGenerators.Entities;

public record Person(string Name, bool IsCool = true, Person? Friend = null);