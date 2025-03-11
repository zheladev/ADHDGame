namespace ADHDGame.Scenes.AppController;

using Chickensoft.Introspection;
using Chickensoft.LogicBlocks;

public partial class AppControllerLogic {
    public partial record State {
        [Meta]
        public partial record MainMenu : State, IGet<Input.LoadGameData>, IGet<Input.InitializeNewGame>, IGet<Input.ShowSettingsMenu> {
            public MainMenu() {
                this.OnEnter(OnEnterHandler);
            }

            public Transition On(in Input.LoadGameData input) => To<LoadGameData>();
            public Transition On(in Input.InitializeNewGame input) => To<StartNewGame>();
            public Transition On(in Input.ShowSettingsMenu input) => To<SettingsMenu>();

            private void OnEnterHandler() => Output(new Output.LoadMainMenu());
        }
    }
}
