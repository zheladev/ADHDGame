namespace ADHDGame;

using Godot;

public partial class StarF : Star {
    public StarF() {
        StarColor = new Color("#FFD700");
        Radius = GenerateRadius(1.15f, 1.4f) * STAR_SCALING;
        PlanetSystemRadius = 10f * STAR_SCALING;
    }
}
