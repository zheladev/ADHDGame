namespace ADHDGame.Scenes.AppController;


using Chickensoft.Introspection;
using Chickensoft.LogicBlocks;

public interface IAppControllerLogic : ILogicBlock<AppControllerLogic.State>;

[Meta]
[LogicBlock(typeof(State), Diagram = true)]
public partial class AppControllerLogic : LogicBlock<AppControllerLogic.State>, IAppControllerLogic {
    public override Transition GetInitialState() => To<State.SplashScreen>();

    public static class Input {
        public readonly record struct ShowSettingsMenu;
        public readonly record struct ShowMainMenu;
        public readonly record struct InitializeNewGame;
        public readonly record struct LoadGameData;
        public readonly record struct EnterInGame;
        public readonly record struct ExitGame;
    }

    public static class Output {
        // splash screen
        public readonly record struct LoadSplashScreen;
        public readonly record struct UnloadSplashScreen;
        // main menu
        public readonly record struct LoadMainMenu;
        public readonly record struct UnloadMainMenu;
        // settings menu
        public readonly record struct LoadSettingsMenu;
        public readonly record struct UnloadSettingsMenu;
        // in game
        public readonly record struct LoadGame;
        public readonly record struct UnloadGame;
        // game data
        public readonly record struct LoadGameData;
        public readonly record struct GameDataLoaded;
        public readonly record struct InitializeGameData;
    }
}
