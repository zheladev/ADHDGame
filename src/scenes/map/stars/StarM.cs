namespace ADHDGame;

using Godot;

public partial class StarM : Star
{
    public StarM()
    {
        StarColor = new Color("#FF4500");
        Radius = GenerateRadius(0.4f, 0.7f) * starScaling;
    }
}