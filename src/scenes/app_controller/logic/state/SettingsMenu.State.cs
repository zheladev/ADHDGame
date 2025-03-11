namespace ADHDGame.Scenes.AppController;

using Chickensoft.Introspection;
using Chickensoft.LogicBlocks;

public partial class AppControllerLogic {
    public partial record State {
        [Meta]
        public partial record SettingsMenu : State, IGet<Input.ShowMainMenu> {
            public SettingsMenu() {
                this.OnEnter(() => Output(new Output.LoadSettingsMenu()));
                this.OnExit(() => Output(new Output.UnloadSettingsMenu()));
            }

            public Transition On(in Input.ShowMainMenu input) => To<MainMenu>();
        }
    }
}
