namespace ADHDGame;

using Godot;

public partial class StarB : Star
{
    public StarB()
    {
        StarColor = new Color("#87CEEB"); // Azul eléctrico
        Radius = GenerateRadius(1.6f, 6.6f); // Radio entre 10 y 15
    }
}