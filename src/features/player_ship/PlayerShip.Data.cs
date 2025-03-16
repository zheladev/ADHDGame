namespace ADHDGame.Features.PlayerShip;

using Chickensoft.Collections;
using Chickensoft.Introspection;
using Chickensoft.Serialization;
using Godot;

[Meta, Id("PlayerShipData")]
public partial record PlayerShipData {
    [Save("player_ship_position")]
    public required Vector2 Position { get; init; }

    // TODO: player state in a class so that values can be modified etc
    [Save("player_is_alive")]
    public AutoProp<bool> IsAlive { get; init; } = default!;
}
