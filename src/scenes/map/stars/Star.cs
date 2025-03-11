namespace ADHDGame;

using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.Introspection;
using Godot;

public interface IStar : INode2D
{
    public Color StarColor { get; set; }
    public float Radius { get; set; }

    // public void _Draw();
}

[Meta(typeof(IAutoNode))]
public abstract partial class Star : Node2D, IStar
{
    public override void _Notification(int what) => this.Notify(what);

    [Export] public Color StarColor { get; set; }
    [Export] public float Radius { get; set; }

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
        DrawCircle(Vector2.Zero, Radius, StarColor);
    }

    // Método para generar el radio aleatoriamente dentro de un rango
    protected float GenerateRadius(float minRadius, float maxRadius)
    {
        return (float)GD.RandRange(minRadius, maxRadius);
    }
}
