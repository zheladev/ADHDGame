namespace ADHDGame.Scenes.AppController;

using Chickensoft.Introspection;
using Chickensoft.LogicBlocks;

public partial class AppControllerLogic {
    public partial record State {
        [Meta]
        public partial record SplashScreen : State, IGet<Input.ShowMainMenu> {
            public SplashScreen() {
                this.OnEnter(() => Output(new Output.LoadSplashScreen()));
                this.OnExit(() => Output(new Output.UnloadSplashScreen()));
            }

            public Transition On(in Input.ShowMainMenu input) => To<MainMenu>();
        }
    }
}
