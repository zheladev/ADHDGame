namespace ADHDGame;

using ADHDGame.Utils;
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
    [Node] public IPlanet PlanetLeft { get; set; } = default!;
    [Node] public IPlanet PlanetRight { get; set; } = default!;
    #endregion Nodes

    #region Signals
    [Signal] public delegate void OnSplashScreenFinishedEventHandler();
    #endregion Signals

    public void Setup() => SplashScreenTimer.Timeout += () => EmitSignal(SignalName.OnSplashScreenFinished);

    public void OnReady() {
        var instant = new Instantiator(GetTree());
        UpdatePlanetRotationalSpeed();

        // cool test, uncomment to show planets rotating on splash screen
        // var iterPlanetSpeed = 0.00f;
        // for (var i = 0; i < 10; i++) {
        //     for (var j = 0; j < 10; j++) {
        //         iterPlanetSpeed += 0.02f;
        //         var temp = instant.LoadAndInstantiate<Planet>("res://src/features/planet/Planet.tscn");
        //         AddChild(temp);
        //         temp.Show();
        //         temp.SetRotationSpeed(iterPlanetSpeed);
        //         temp.Scale = new Vector2(0.2f, 0.2f);
        //         temp.Position = new Vector2(i * 100, j * 100);
        //     }
        // }
    }

    private void UpdatePlanetRotationalSpeed() {
        PlanetLeft.SetRotationSpeed(3f);
        PlanetRight.SetRotationSpeed(-3f);
    }
}
