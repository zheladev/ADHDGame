namespace ADHDGame.Scenes.AppController;

using Chickensoft.Introspection;

public partial class AppControllerLogic {
    public partial record State {
        [Meta]
        public partial record SettingsMenu : State, IGet<Input.ShowMainMenu> {
            public SettingsMenu() {
            }

            public Transition On(in Input.ShowMainMenu input) => To<MainMenu>();
        }
    }
}
