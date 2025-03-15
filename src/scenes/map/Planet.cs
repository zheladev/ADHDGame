namespace ADHDGame;

using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.Introspection;
using Godot;

public interface IPlanetTest : INode2D
{
    public float Radius { get; set; }
    public float OrbitalDistance { get; set; }
    public Vector2 StarPosition { get; set; }
}

[Meta(typeof(IAutoNode))]
public partial class PlanetTest : Node2D, IPlanetTest
{
    public float Radius { get; set; }
    public float OrbitalDistance { get; set; }
    public Vector2 StarPosition { get; set; }

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

    public void OnReady() { }

    public void OnExitTree() { }

    public override void _Draw()
    {
        DrawCircle(Vector2.Zero, Radius, Colors.Pink);
        DrawArc(StarPosition - Position, OrbitalDistance, 0, 2 * Mathf.Pi, 100, Colors.White, 1, true);
    }
}
