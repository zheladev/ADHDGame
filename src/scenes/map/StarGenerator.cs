namespace ADHDGame;

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
    [Export] private float _minDistance = 20f; // TODO

    private readonly RandomNumberGenerator _rng = new();
    private readonly List<Vector2> _starPositions = new();

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

    public void Setup() => _rng.Seed = _seed;// instantiation of objects and context setup

    public void OnReady() => GenerateStars();

    public void OnExitTree() { }

    private void GenerateStars() {
        for (var i = 0; i < _starCount; i++) {
            // Generate polar coordinates
            var angle = _rng.Randf() * 2 * Mathf.Pi;
            var radius = GenerateRadius();
            // Vector2 position = GenerateStarPosition();

            // Convert to Cartesian coordinates
            var x = radius * Mathf.Cos(angle);
            var y = radius * Mathf.Sin(angle);

            var star = CreateRandomStar();
            var starSeed = _seed + (ulong)i;
            star.SetSeed(starSeed);
            // starPositions.Add(position);
            star.Position = new Vector2(x, y);
            // star.rng = _rng;

            star.GeneratePlanetarySystem();
            AddChild(star);
        }
    }

    private float GenerateRadius() {
        // Normal distribution
        var u1 = 1.0f - _rng.Randf();
        var u2 = 1.0f - _rng.Randf();
        var randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.Pi * u2);
        var radius = Mathf.Abs(randStdNormal) * _galaxyRadius * _centerConcentration;

        // Radius doesn't exceed galaxy size
        return Mathf.Min(radius, _galaxyRadius);
    }

    private Vector2 GenerateStarPosition() {
        Vector2 position;
        bool isValidPosition;

        do {
            var angle = _rng.RandfRange(0, 2 * Mathf.Pi);
            var radius = _rng.RandfRange(0, _galaxyRadius);
            position = new Vector2(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle));

            isValidPosition = true;
            foreach (var existingPosition in _starPositions) {
                if (position.DistanceTo(existingPosition) < _minDistance) {
                    isValidPosition = false;
                    break;
                }
            }
        } while (!isValidPosition);

        return position;
    }

    private Star CreateRandomStar() {
        var starType = _rng.Randf();

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
