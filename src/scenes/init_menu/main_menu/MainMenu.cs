namespace ADHDGame;

using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.Introspection;
using Godot;

public interface IMainMenu : IControl {
    public event MainMenu.OnStartNewGameEventHandler OnStartNewGame;
    public event MainMenu.OnStartLoadGameEventHandler OnStartLoadGame;
    public event MainMenu.OnOpenSettingsMenuEventHandler OnOpenSettingsMenu;
    public event MainMenu.OnExitGameEventHandler OnExitGame;
}

[Meta(typeof(IAutoNode))]
public partial class MainMenu : Control, IMainMenu {
    public override void _Notification(int what) => this.Notify(what);

    #region Nodes
    // AutoInjected child nodes go here.
    // Example:
    // [Node] public IArea2D ExampleArea { get; set; } = default!;
    [Node] public IButton NewGameButton { get; set; } = default!;
    [Node] public IButton LoadGameButton { get; set; } = default!;
    [Node] public IButton SettingsButton { get; set; } = default!;
    [Node] public IButton ExitGameButton { get; set; } = default!;
    #endregion Nodes

    #region Signals
    [Signal] public delegate void OnStartNewGameEventHandler();
    [Signal] public delegate void OnStartLoadGameEventHandler();
    [Signal] public delegate void OnOpenSettingsMenuEventHandler();
    [Signal] public delegate void OnExitGameEventHandler();
    #endregion Signals

    public void Setup() {
        // instantiation of objects and context setup
    }

    public void OnReady() {
        NewGameButton.Pressed += () => EmitSignal(nameof(OnStartNewGame));
        LoadGameButton.Pressed += () => EmitSignal(nameof(OnStartLoadGame));
        SettingsButton.Pressed += () => EmitSignal(nameof(OnOpenSettingsMenu));
        ExitGameButton.Pressed += () => EmitSignal(nameof(OnExitGame));
    }

    public void OnExitTree() { }
}

