namespace ADHDGame;

using Godot;
using Chickensoft.GameTools.Displays;

#if DEBUG
using System.Reflection;
using Chickensoft.GoDotTest;
#endif

// This entry-point file is responsible for determining if we should run tests.
//
// If you want to edit your game's main entry-point, please see Game.tscn and
// Game.cs instead.

public partial class Main : Node2D {
    public Vector2I DesignResolution => Display.UHD4k;
#if DEBUG
    public TestEnvironment Environment = default!;
#endif

    public override void _Ready() {
        // Correct any erroneous scaling and guess sensible defaults.
        GetWindow().LookGood(WindowScaleBehavior.UIFixed, DesignResolution);

#if DEBUG
        // If this is a debug build, use GoDotTest to examine the
        // command line arguments and determine if we should run tests.
        Environment = TestEnvironment.From(OS.GetCmdlineArgs());
        if (Environment.ShouldRunTests) {
            CallDeferred("RunTests");
            return;
        }
#endif

        // If we don't need to run tests, we can just switch to the game scene.
        CallDeferred("RunScene");
    }

#if DEBUG
    private void RunTests()
      => _ = GoTest.RunTests(Assembly.GetExecutingAssembly(), this, Environment);
#endif

    private void RunScene()
      => GetTree().ChangeSceneToFile("res://src/scenes/app_controller/AppController.tscn");
}
