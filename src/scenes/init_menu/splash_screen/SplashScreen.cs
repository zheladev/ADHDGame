namespace ADHDGame;

using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.Introspection;
using Godot;

public interface ISplashScreen : INode2D {
	public event SplashScreen.OnSplashScreenFinishedEventHandler OnSplashScreenFinished;
	// Define exposed functions and properties here.
}

[Meta(typeof(IAutoNode))]
public partial class SplashScreen : Node2D, ISplashScreen {
	public override void _Notification(int what) => this.Notify(what);

	#region Nodes
	[Node] public ITimer SplashScreenTimer { get; set; } = default!;
	#endregion Nodes

	#region Signals
	[Signal] public delegate void OnSplashScreenFinishedEventHandler();
	#endregion Signals

	public void Setup() => SplashScreenTimer.Timeout += () => EmitSignal(SignalName.OnSplashScreenFinished);

	public void OnReady() { }

	public void OnExitTree() { }
}
