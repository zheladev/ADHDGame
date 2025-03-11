namespace ADHDGame.Scenes.AppController;

using ADHDGame.Repositories;
using ADHDGame.Utils;
using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.Introspection;
using Godot;

public interface IAppController : INode2D, IProvide<IAppRepository> {
    // Define exposed functions and properties here.
}

[Meta(typeof(IAutoNode))]
public partial class AppController : Node2D, IAppController {
    public override void _Notification(int what) => this.Notify(what);

    public const string SPLASH_SCREEN_SCENE_PATH = "res://src/scenes/splash_screen/SplashScreen.tscn";
    public const string SETTINGS_MENU_SCENE_PATH = "res://src/scenes/settings_menu/SettingsMenu.tscn";
    public const string MAIN_MENU_SCENE_PATH = "res://src/scenes/main_menu/MainMenu.tscn";

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
    private Node LoadedScene { get; set; } = default!;
    // Define node state variables here
    // private bool _isRightMouseButtonHeld;
    public IAppRepository AppRepository { get; set; } = default!;
    public IAppControllerLogic AppControllerLogic { get; set; } = default!;
    public AppControllerLogic.IBinding AppControllerBinding { get; set; } = default!;
    #endregion State

    #region External
    public IInstantiator Instantiator { get; set; } = default!;
    #endregion External


    #region Provisions
    // TODO: Provide all repositories
    // IGameRepository IProvide<IGameRepository>.Value() => GameRepository;
    IAppRepository IProvide<IAppRepository>.Value() => AppRepository;
    #endregion Provisions

    #region Dependencies
    // Repository injections go here
    // Example:
    // [Dependency] public IGameRepository GameRepository => this.DependOn<GameRepository>();
    #endregion Dependencies

    public void Setup() {
        Instantiator = new Instantiator(GetTree());
        AppControllerLogic = new AppControllerLogic();
        // Instantiate Repositories here

        AppRepository = new AppRepository();

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
        LoadedScene?.QueueFree();
        var splashScreen = Instantiator.LoadAndInstantiate<SplashScreen>(SPLASH_SCREEN_SCENE_PATH);
        AddChild(splashScreen);
        splashScreen.Show();
        Instantiator.SceneTree.Paused = false;
        splashScreen.OnSplashScreenFinished += OnSplashScreenTimerTimeout;
        LoadedScene = splashScreen;
    }

    private void ShowMainMenu() {
        LoadedScene?.QueueFree();
        GD.Print("Main menu entered");
        var mainMenu = Instantiator.LoadAndInstantiate<MainMenu>(MAIN_MENU_SCENE_PATH);
        AddChild(mainMenu);
        mainMenu.Show();
        Instantiator.SceneTree.Paused = false;
        LoadedScene = mainMenu;
    }

    private static void ShowInGame() {
        // Show in game
    }

    private static void LoadGame() {
        // Load game
    }

    private static void NewGame() {
        // Start new game
    }

    private void OnSplashScreenTimerTimeout() => AppControllerLogic.Input(new AppControllerLogic.Input.ShowMainMenu());
}

