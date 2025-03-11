namespace ADHDGame;

using Godot;

public partial class StarM : Star
{
    public StarM()
    {
        StarColor = new Color("#FF4500"); // Azul eléctrico
        Radius = GenerateRadius(0.4f, 0.7f); // Radio entre 10 y 15
    }
}