namespace ADHDGame;

using Godot;

public partial class StarK : Star {
    public StarK() {
        StarColor = new Color("#FF8C00");
        Radius = GenerateRadius(0.7f, 0.96f) * STAR_SCALING;
        PlanetSystemRadius = 10f * STAR_SCALING;
    }
}
