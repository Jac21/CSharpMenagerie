using System.Text.Json.Serialization;
using JsonSourceGenerators.Entities;

namespace JsonSourceGenerators.SerializationContexts;

[JsonSourceGenerationOptions(WriteIndented = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(Person))]
public partial class PersonSerializationContext : JsonSerializerContext
{
}