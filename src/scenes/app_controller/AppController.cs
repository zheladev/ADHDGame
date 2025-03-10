namespace ADHDGame.Scenes.AppController;

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
    public IAppControllerLogic AppControllerLogic { get; set; } = default!;
    public AppControllerLogic.IBinding AppControllerBinding { get; set; } = default!;
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
        Instantiator = new Instantiator(GetTree());

        // Instantiate Repositories here
        this.Provide();
    }

    public void OnReady() {
        AppControllerBinding = AppControllerLogic.Bind();

        AppControllerBinding
            .Handle((in AppControllerLogic.Output.ShowSplashScreen _) => ShowSplashScreen())
            .Handle((in AppControllerLogic.Output.ShowMainMenu _) => ShowMainMenu())
            .Handle((in AppControllerLogic.Output.ShowInGame _) => ShowInGame())
            .Handle((in AppControllerLogic.Output.LoadGameData _) => LoadGame())
            .Handle((in AppControllerLogic.Output.NewGame _) => NewGame());

        AppControllerLogic.Start();
    }


    private void ShowSplashScreen() {
        GD.Print("Showing splash Screen.");
        AppControllerLogic.Input(new AppControllerLogic.Input.ShowMainMenu());
    }

    private void ShowMainMenu() {
        // Show main menu
    }

    private void ShowInGame() {
        // Show in game
    }

    private void LoadGame() {
        // Load game
    }

    private void NewGame() {
        // Start new game
    }


}

