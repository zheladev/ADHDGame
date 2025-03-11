namespace ADHDGame.Scenes.AppController;

using Chickensoft.Introspection;
using Chickensoft.LogicBlocks;

public partial class AppControllerLogic {
    public partial record State {
        [Meta]
        public partial record MainMenu : State, IGet<Input.LoadGameData>, IGet<Input.InitializeNewGame>, IGet<Input.ShowSettingsMenu>, IGet<Input.ExitGame> {
            public MainMenu() {
                this.OnEnter(() => Output(new Output.LoadMainMenu()));
                this.OnExit(() => Output(new Output.UnloadMainMenu()));
            }

            public Transition On(in Input.LoadGameData input) => To<LoadGameData>();
            public Transition On(in Input.InitializeNewGame input) => To<InitializeGameData>();
            public Transition On(in Input.ShowSettingsMenu input) => To<SettingsMenu>();
            public Transition On(in Input.ExitGame input) => To<ExitGame>();
        }
    }
}
