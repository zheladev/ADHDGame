namespace ADHDGame.Scenes.AppController;

using System;
using ADHDGame.Repositories;
using ADHDGame.Utils;
using Chickensoft.AutoInject;
using Chickensoft.Collections;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.Introspection;
using Godot;

public interface IAppController : INode2D, IProvide<IAppRepository> {
    // Define exposed functions and properties here.
}

[Meta(typeof(IAutoNode))]
public partial class AppController : Node2D, IAppController {
    public override void _Notification(int what) => this.Notify(what);

    public const string SPLASH_SCREEN_SCENE_PATH = "res://src/scenes/init_menu/splash_screen/SplashScreen.tscn";
    public const string SETTINGS_MENU_SCENE_PATH = "res://src/scenes/init_menu/settings_menu/SettingsMenu.tscn";
    public const string MAIN_MENU_SCENE_PATH = "res://src/scenes/init_menu/main_menu/MainMenu.tscn";
    public const string GAME_SCENE_PATH = "res://src/scenes/game/Game.tscn";

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
    private readonly Blackboard _blackboard = new();
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
            // splash screen
            .Handle((in AppControllerLogic.Output.LoadSplashScreen _) => LoadSplashScreen())
            .Handle((in AppControllerLogic.Output.UnloadSplashScreen _) => UnloadSplashScreen())
            // main menu
            .Handle((in AppControllerLogic.Output.LoadMainMenu _) => LoadMainMenu())
            .Handle((in AppControllerLogic.Output.UnloadMainMenu _) => UnloadMainMenu())
            // settings
            .Handle((in AppControllerLogic.Output.LoadSettingsMenu _) => LoadSettingsMenu())
            .Handle((in AppControllerLogic.Output.UnloadSettingsMenu _) => UnloadSettingsMenu())
            // in game
            .Handle((in AppControllerLogic.Output.LoadGame _) => LoadGame())
            .Handle((in AppControllerLogic.Output.UnloadGame _) => UnloadGame())
            // game data
            .Handle((in AppControllerLogic.Output.LoadGameData _) => LoadGameData())
            .Handle((in AppControllerLogic.Output.InitializeGameData _) => InitializeGameData());

        AppControllerLogic.Start();
    }

    // Splash screen
    public void LoadSplashScreen() {
        var splashScreen = Instantiator.LoadAndInstantiate<SplashScreen>(SPLASH_SCREEN_SCENE_PATH);
        AddChild(splashScreen);
        splashScreen.Show();
        Instantiator.SceneTree.Paused = false;

        splashScreen.OnSplashScreenFinished += () => AppControllerLogic.Input(new AppControllerLogic.Input.ShowMainMenu());

        _blackboard.Set<ISplashScreen>(splashScreen);
    }

    public void UnloadSplashScreen() => _blackboard.Get<ISplashScreen>()?.QueueFree();

    // Main menu
    private void LoadMainMenu() {
        var mainMenu = Instantiator.LoadAndInstantiate<MainMenu>(MAIN_MENU_SCENE_PATH);
        AddChild(mainMenu);
        mainMenu.Show();
        Instantiator.SceneTree.Paused = false;

        mainMenu.OnStartNewGame += () => AppControllerLogic.Input(new AppControllerLogic.Input.InitializeNewGame());
        mainMenu.OnStartLoadGame += () => AppControllerLogic.Input(new AppControllerLogic.Input.LoadGameData());
        mainMenu.OnOpenSettingsMenu += () => AppControllerLogic.Input(new AppControllerLogic.Input.ShowSettingsMenu());
        mainMenu.OnExitGame += () => AppControllerLogic.Input(new AppControllerLogic.Input.ExitGame());

        _blackboard.Set<IMainMenu>(mainMenu);
    }

    private void UnloadMainMenu() => _blackboard.Get<IMainMenu>()?.QueueFree();

    // Settings menu

    private void LoadSettingsMenu() {
        var settingsMenu = Instantiator.LoadAndInstantiate<SettingsMenu>(SETTINGS_MENU_SCENE_PATH);
        AddChild(settingsMenu);
        settingsMenu.Show();
        Instantiator.SceneTree.Paused = false;
        _blackboard.Set<ISettingsMenu>(settingsMenu);
    }

    private void UnloadSettingsMenu() => _blackboard.Get<ISettingsMenu>()?.QueueFree();

    // Ingame
    private void UnloadGame() => throw new NotImplementedException();
    private void LoadGame() => throw new NotImplementedException();

    // Game load
    private void InitializeGameData() => throw new NotImplementedException();
    private void LoadGameData() => throw new NotImplementedException();
}

