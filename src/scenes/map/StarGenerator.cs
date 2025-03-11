namespace ADHDGame;

using System;

using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.Introspection;
using Godot;

public interface IStarGenerator : INode2D
{
    // Define exposed functions and properties here.
}

[Meta(typeof(IAutoNode))]
public partial class StarGenerator : Node2D, IStarGenerator
{
    public override void _Notification(int what) => this.Notify(what);

    [Export] private int starCount = 1000;
    [Export] private float galaxyRadius = 500f;
    [Export] private float centerConcentration = 0.5f;

    private Random random = new Random();

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

    private void GenerateStars()
    {
        for (int i = 0; i < starCount; i++)
        {
            // Generate polar coordinates
            float angle = (float)random.NextDouble() * 2 * Mathf.Pi;
            float radius = GenerateRadius();

            // Convert to Cartesian coordinates
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);

            Color color = GetStarColor();
            CreateStar(new Vector2(x, y), color);
        }
    }

    private float GenerateRadius()
    {
        // Normal distribution
        float u1 = 1.0f - (float)random.NextDouble();
        float u2 = 1.0f - (float)random.NextDouble();
        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.Pi * u2);
        float radius = Mathf.Abs(randStdNormal) * galaxyRadius * centerConcentration;

        // Radius doesn't exceed galaxy size
        return Mathf.Min(radius, galaxyRadius);
    }

    private void CreateStar(Vector2 position, Color color)
    {
        var star = new Sprite2D();
        star.Position = position;

        var image = Image.Create(16, 16, false, Image.Format.Rgba8);
        image.Fill(color);

        var texture = ImageTexture.CreateFromImage(image);
        star.Texture = texture;

        AddChild(star);
    }

    private Color GetStarColor()
    {
        float starType = (float)random.NextDouble();

        if (starType < 0.7f)
        {
            return Colors.White;
        }
        else if (starType < 0.9f)
        {
            return Colors.Yellow;
        }
        else
        {
            return Colors.Blue;
        }
    }
}
