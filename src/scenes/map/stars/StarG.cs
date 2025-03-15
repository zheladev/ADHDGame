namespace ADHDGame;

using Godot;

public partial class StarG : Star {
    public StarG() {
        StarColor = new Color("#FFC300");
        Radius = GenerateRadius(0.96f, 1.15f) * STAR_SCALING;
        PlanetSystemRadius = 50f * STAR_SCALING;
    }
}
