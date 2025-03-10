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
        public readonly record struct StartNewGame;
        public readonly record struct LoadGameData;
        public readonly record struct EnterInGame;
        public readonly record struct ExitGame;
    }

    public static class Output {
        public readonly record struct ShowSplashScreen;
        public readonly record struct ShowMainMenu;
        public readonly record struct ShowInGame;
        public readonly record struct LoadGameData;
        public readonly record struct GameDataLoaded;
        public readonly record struct NewGame;
    }
}
