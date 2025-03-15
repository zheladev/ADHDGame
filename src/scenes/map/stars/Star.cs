namespace ADHDGame;

using System.Collections.Generic;

using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.Introspection;
using Godot;

public interface IStar : INode2D
{
    public Color StarColor { get; set; }
    public float Radius { get; set; }

    public float PlanetSystemRadius { get; set; }
    public List<PlanetTest> Planets { get; set; }

    public abstract void GeneratePlanetarySystem();
}

[Meta(typeof(IAutoNode))]
public abstract partial class Star : Node2D, IStar
{
    public override void _Notification(int what) => this.Notify(what);

    private RandomNumberGenerator Rng { get; set; } = new();

    [Export] public Color StarColor { get; set; }
    [Export] public float Radius { get; set; }

    [Export] public float PlanetSystemRadius { get; set; }
    public List<PlanetTest> Planets { get; set; } = new List<PlanetTest>();

    protected const float STAR_SCALING = 695f;   // base unit is 10^3 km

    public void Setup()
    {
        // instantiation of objects and context setup
    }

    public void OnReady() { }

    public void OnExitTree() { }

    public override void _Draw()
    {
        DrawCircle(Vector2.Zero, Radius, StarColor);
        DrawCircle(Vector2.Zero, PlanetSystemRadius, new Color(1, 1, 1, 0.1f));
    }

    public void SetSeed(ulong seed) => Rng.Seed = seed;

    public float GenerateRadius(float minRadius, float maxRadius) => Rng.RandfRange(minRadius, maxRadius);

    public void GeneratePlanetarySystem()
    {
        var planetCount = Rng.RandiRange(1, 8);
        for (var i = 0; i < planetCount; i++)
        {
            var position = GeneratePlanetPosition();
            var orbitalDistance = position.Length();
            var planetRadius = Rng.RandfRange(10, 100);

            var planet = new PlanetTest
            {
                Radius = planetRadius,
                OrbitalDistance = orbitalDistance,
                Position = position,
                StarPosition = new Vector2(0, 0),
            };

            Planets.Add(planet);
            AddChild(planet);
        }
    }

    private Vector2 GeneratePlanetPosition()
    {
        var angle = Rng.RandfRange(0, 2 * Mathf.Pi);
        var radius = Rng.RandfRange(Radius, PlanetSystemRadius); // Distancia en UA
        var position = new Vector2(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle));

        return position;
    }

}
