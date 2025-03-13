namespace ADHDGame;

using System;
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
    public List<Planet> Planets { get; set; }

    public abstract void GeneratePlanetarySystem();
}

[Meta(typeof(IAutoNode))]
public abstract partial class Star : Node2D, IStar
{
    public override void _Notification(int what) => this.Notify(what);

    [Export] public Color StarColor { get; set; }
    [Export] public float Radius { get; set; }

    [Export] public float PlanetSystemRadius { get; set; }
    public List<Planet> Planets { get; set; } = new List<Planet>();

    protected const float starScaling = 695f;   // base unit is 10^3 km
    private readonly RandomNumberGenerator _rng = new();

    #region Nodes
    // AutoInjected child nodes go here.
    // Example:
    // [Node] public IArea2D ExampleArea { get; set; } = default!;
    #endregion Nodes

    #region Signals
    // Signals go here
    // Example:
    // [Signal] public delegate void MainMenuEventHandler();
    #endregion Signals



    #region State
    // Define node state variables here
    // private bool _isRightMouseButtonHeld;
    #endregion State

    #region External
    // Non-godot vars go here
    // Example:
    // public IInstantiator Instantiator { get; set; } = default!;
    #endregion External


    #region Provisions
    // Provisions go here. These are exposed to children and can be retrieved
    // using dependencies. Check Dependencies region for an example.
    // Example:
    // IGameRepository IProvide<IGameRepository>.Value() => GameRepository;
    #endregion Provisions

    #region Dependencies
    // Repository injections go here
    // Example:
    // [Dependency] public IGameRepository GameRepository => this.DependOn<GameRepository>();
    #endregion Dependencies

    public void Setup(ulong seed)
    {
        _rng.Seed = (ulong)seed;
        // instantiation of objects and context setup
    }

    public void OnReady() { }

    public void OnExitTree() { }

    public override void _Draw()
    {
        DrawCircle(Vector2.Zero, Radius, StarColor);
        DrawCircle(Vector2.Zero, PlanetSystemRadius, new Color(1, 1, 1, 0.1f));
    }

    public float GenerateRadius(float minRadius, float maxRadius)
    {
        return _rng.RandfRange(minRadius, maxRadius);
    }

    public void GeneratePlanetarySystem()
    {
        int planetCount = _rng.RandiRange(1, 8);
        for (int i = 0; i < planetCount; i++)
        {
            Vector2 position = GeneratePlanetPosition();
            float orbitalDistance = position.Length();
            float planetRadius = _rng.RandfRange(10, 100);

            Planet planet = new Planet{
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
        float angle = _rng.RandfRange(0, 2 * Mathf.Pi);
        float radius = _rng.RandfRange(Radius, PlanetSystemRadius); // Distancia en UA
        Vector2 position = new Vector2(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle));

        return position;
    }

}
