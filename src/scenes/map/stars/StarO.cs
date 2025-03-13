namespace ADHDGame;

using Godot;

public partial class StarO : Star
{
    public StarO()
    {
        StarColor = new Color("#00BFFF");
        Radius = GenerateRadius(6.6f, 8f) * starScaling;
        PlanetSystemRadius = 10f * starScaling;
    }
}