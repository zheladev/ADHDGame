namespace ADHDGame;

using Godot;

public partial class StarG : Star
{
    public StarG()
    {
        StarColor = new Color("#FFC300"); // Azul eléctrico
        Radius = GenerateRadius(0.96f, 1.15f); // Radio entre 10 y 15
    }
}