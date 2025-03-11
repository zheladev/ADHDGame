namespace ADHDGame.Scenes.AppController;

using Chickensoft.Introspection;
using Chickensoft.LogicBlocks;

public partial class AppControllerLogic {
    public partial record State {
        [Meta]
        public partial record ExitGame : State {
            public ExitGame() {
                this.OnEnter(() => Output(new Output.ExitGame()));
            }
        }
    }
}
