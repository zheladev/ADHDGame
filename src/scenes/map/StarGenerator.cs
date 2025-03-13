namespace ADHDGame;

using System;
using System.Collections.Generic;

using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.Introspection;
using Godot;

public interface IStarGenerator : INode2D {
    // Define exposed functions and properties here.
}

[Meta(typeof(IAutoNode))]
public partial class StarGenerator : Node2D, IStarGenerator {
    public override void _Notification(int what) => this.Notify(what);

    [Export] private int _starCount = 2000;
    [Export] private float _galaxyRadius = 2000000f;
    [Export] private float _centerConcentration = 0.5f;
    [Export] private ulong _seed = 123456789;
    [Export] private float minDistance = 20f; // TODO

    private readonly RandomNumberGenerator _rng = new();
    private List<Vector2> starPositions = new List<Vector2>();

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

    public void Setup()
    {
        _rng.Seed = (ulong)_seed;
        // instantiation of objects and context setup
    }

    public void OnReady()
    {
        GenerateStars();
    }

    public void OnExitTree() { }

    private void GenerateStars() {
        for (int i = 0; i < _starCount; i++) {
            // Generate polar coordinates
            float angle = _rng.Randf() * 2 * Mathf.Pi;
            float radius = GenerateRadius();
            // Vector2 position = GenerateStarPosition();

            // Convert to Cartesian coordinates
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);

            Star star = CreateRandomStar(_seed);
            // starPositions.Add(position);
            star.Position = new Vector2(x, y);

            star.GeneratePlanetarySystem();
            AddChild(star);
        }
    }

    private float GenerateRadius() {
        // Normal distribution
        float u1 = 1.0f - _rng.Randf();
        float u2 = 1.0f - _rng.Randf();
        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.Pi * u2);
        float radius = Mathf.Abs(randStdNormal) * _galaxyRadius * _centerConcentration;

        // Radius doesn't exceed galaxy size
        return Mathf.Min(radius, _galaxyRadius);
    }

    private Vector2 GenerateStarPosition()
    {
        Vector2 position;
        bool isValidPosition;

        do
        {
            float angle = (float)GD.RandRange(0, 2 * Mathf.Pi);
            float radius = (float)GD.RandRange(0, _galaxyRadius);
            position = new Vector2(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle));

            isValidPosition = true;
            foreach (Vector2 existingPosition in starPositions)
            {
                if (position.DistanceTo(existingPosition) < minDistance)
                {
                    isValidPosition = false;
                    break;
                }
            }
        } while (!isValidPosition);

        return position;
    }

    private Star CreateRandomStar(ulong useed) {
        float starType = _rng.Randf();

        if (starType < 0.0001f) // O-type (0.01%)
        {
            return new StarO();
        }
        else if (starType < 0.001f) // B-type (0.09%)
        {
            return new StarB();
        }
        else if (starType < 0.01f) // A-type (1%)
        {
            return new StarA();
        }
        else if (starType < 0.04f) // F-type (3%)
        {
            return new StarF();
        }
        else if (starType < 0.12f) // G-type (8%)
        {
            return new StarG();
        }
        else if (starType < 0.24f) // K-type (12%)
        {
            return new StarK();
        }
        else // M-type (76%)
        {
            return new StarM();
        }
    }
}
