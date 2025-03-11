namespace ADHDGame;

using System;

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
    [Export] private float _galaxyRadius = 1000f;
    [Export] private float _centerConcentration = 0.5f;

    private readonly Random _random = new();

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
            float angle = (float)_random.NextDouble() * 2 * Mathf.Pi;
            float radius = GenerateRadius();

            // Convert to Cartesian coordinates
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);

            Star star = CreateRandomStar();
            star.Position = new Vector2(x, y);
            // Color color = GetStarColor();
            // CreateStar(new Vector2(x, y), color);

            AddChild(star);
        }
    }

    private float GenerateRadius() {
        // Normal distribution
        float u1 = 1.0f - (float)_random.NextDouble();
        float u2 = 1.0f - (float)_random.NextDouble();
        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.Pi * u2);
        float radius = Mathf.Abs(randStdNormal) * _galaxyRadius * _centerConcentration;

        // Radius doesn't exceed galaxy size
        return Mathf.Min(radius, _galaxyRadius);
    }

    private void CreateStar(Vector2 position, Color color) {
        var star = new Sprite2D {
            Position = position
        };

        var image = Image.CreateEmpty(16, 16, false, Image.Format.Rgba8);
        image.Fill(color);

        var texture = ImageTexture.CreateFromImage(image);
        star.Texture = texture;

        AddChild(star);
    }

    private Star CreateRandomStar() {
        float starType = (float)_random.NextDouble();

        // return new StarO();

        if (starType < 0.01f) // O-type (1%)
        {
            return new StarO();
        }
        else if (starType < 0.05f) // B-type (4%)
        {
            return new StarB();
        }
        else if (starType < 0.15f) // A-type (10%)
        {
            return new StarA();
        }
        else if (starType < 0.35f) // F-type (20%)
        {
            return new StarF();
        }
        else if (starType < 0.65f) // G-type (30%)
        {
            return new StarG();
        }
        else if (starType < 0.90f) // K-type (25%)
        {
            return new StarK();
        }
        else // M-type (10%)
        {
            return new StarM();
        }
    }
}
