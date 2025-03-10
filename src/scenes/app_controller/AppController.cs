namespace ADHDGame;

using ADHDGame.Utils;
using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.Introspection;
using Godot;

public interface IAppController : INode2D {
    // Define exposed functions and properties here.
}

[Meta(typeof(IAutoNode))]
public partial class AppController : Node2D, IAppController {
    public override void _Notification(int what) => this.Notify(what);

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
    public IInstantiator Instantiator { get; set; } = default!;
    #endregion External


    #region Provisions
    // TODO: Provide all repositories
    // IGameRepository IProvide<IGameRepository>.Value() => GameRepository;
    #endregion Provisions

    #region Dependencies
    // Repository injections go here
    // Example:
    // [Dependency] public IGameRepository GameRepository => this.DependOn<GameRepository>();
    #endregion Dependencies

    public void Setup() {
        // instantiation of objects and context setup
    }

    public void OnReady() { }

    public void OnExitTree() { }
}

