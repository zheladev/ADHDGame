namespace ADHDGame.Features.PlayerShip;


using Chickensoft.Introspection;
using Chickensoft.LogicBlocks;

public interface IPlayerShipLogic : ILogicBlock<PlayerShipLogic.State>;

[Meta]
[LogicBlock(typeof(State), Diagram = true)]
public partial class PlayerShipLogic : LogicBlock<PlayerShipLogic.State>, IPlayerShipLogic {
    public override Transition GetInitialState() => To<State.Idle>();

    public static class Input {
        public readonly record struct Move;
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

        public readonly record struct ExitGame;
    }
}
