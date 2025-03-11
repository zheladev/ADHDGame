namespace ADHDGame.Scenes.AppController;

using Chickensoft.Introspection;
using Chickensoft.LogicBlocks;

public partial class AppControllerLogic {
    public partial record State {
        [Meta]
        public partial record InGame : State, IGet<Input.ShowMainMenu>, IGet<Input.ExitGame> {
            public InGame() {
                this.OnEnter(() => Output(new Output.LoadGame()));
                this.OnExit(() => Output(new Output.UnloadGame()));
            }

            public Transition On(in Input.ShowMainMenu input) => throw new System.NotImplementedException(); //TODO: impl
            public Transition On(in Input.ExitGame input) => throw new System.NotImplementedException(); //TODO: impl
        }
    }
}
