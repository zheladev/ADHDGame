namespace ADHDGame.Scenes.AppController;

using Chickensoft.Introspection;
using Chickensoft.LogicBlocks;

public partial class AppControllerLogic {
    public partial record State {
        [Meta]
        public partial record SplashScreen : State, IGet<Input.ShowMainMenu> {
            public SplashScreen() {
                this.OnEnter(() => Output(new Output.ShowSplashScreen()));
            }

            public Transition On(in Input.ShowMainMenu input) => To<MainMenu>();
        }
    }
}
