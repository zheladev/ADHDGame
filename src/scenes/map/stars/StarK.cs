namespace ADHDGame;

using Godot;

public partial class StarK : Star
{
    public StarK()
    {
        StarColor = new Color("#FF8C00"); // Azul eléctrico
        Radius = GenerateRadius(0.7f, 0.96f); // Radio entre 10 y 15
    }
}