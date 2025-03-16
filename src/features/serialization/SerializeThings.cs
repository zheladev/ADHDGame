using System.Text.Json;
using ADHDGame;
using Chickensoft.Serialization;

var options = new JsonSerializerOptions {
    WriteIndented = true,
    TypeInfoResolver = new SerializableTypeResolver(),
    Converters = { new SerializableTypeConverter() }
};

var sp = new SerializablePlanet {
    Name = "Earth",
    Description = "Home"
};

var json = JsonSerializer.Serialize(sp, options);

var spAgain = JsonSerializer.Deserialize<SerializablePlanet>(json, options);
