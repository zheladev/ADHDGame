namespace ADHDGame;

using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.Introspection;
using Godot;

public interface ISettingsMenu : IControl {
    public event SettingsMenu.OnReturnToMainMenuEventHandler OnReturnToMainMenu;
}

[Meta(typeof(IAutoNode))]
public partial class SettingsMenu : Control, ISettingsMenu {
    public override void _Notification(int what) => this.Notify(what);

    #region Nodes
    [Node] public IButton MainMenuButton { get; set; } = default!;
    #endregion Nodes

    #region Signals
    [Signal] public delegate void OnReturnToMainMenuEventHandler();
    #endregion Signals

    public void Setup() => MainMenuButton.Pressed += () => EmitSignal(nameof(OnReturnToMainMenu));
}

