namespace ADHDGame;

using Godot;

public partial class StarA : Star {
    public StarA() {
        StarColor = new Color("#F0F8FF");
        Radius = GenerateRadius(1.4f, 1.8f) * STAR_SCALING;
        PlanetSystemRadius = 10f * STAR_SCALING;
    }
}
