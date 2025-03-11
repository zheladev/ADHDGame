namespace ADHDGame;

using Godot;

public partial class StarA : Star
{
    public StarA()
    {
        StarColor = new Color("#F0F8FF"); // Azul eléctrico
        Radius = GenerateRadius(1.4f, 1.8f); // Radio entre 10 y 15
    }
}