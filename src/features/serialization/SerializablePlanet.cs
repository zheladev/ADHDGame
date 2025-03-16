namespace ADHDGame;
using Chickensoft.Introspection;
using Chickensoft.Serialization;

[Meta, Id("serializablePlanet")]
public partial class SerializablePlanet {
    // define name and description attributes as seen in https://www.nuget.org/packages/Chickensoft.Serialization/
    [Save("name")]
    public required string Name { get; init; } // required allows it to be non-nullable

    [Save("description")]
    public string? Description { get; init; } // not required, should be nullable
}
