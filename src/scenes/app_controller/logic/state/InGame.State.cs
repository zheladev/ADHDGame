namespace ADHDGame.Scenes.AppController;

using Chickensoft.Introspection;

public partial class AppControllerLogic {
    public partial record State {
        [Meta]
        public partial record InGame : State, IGet<Input.ShowMainMenu>, IGet<Input.ExitGame> {
            public InGame() {
                // Can't exit this state fuck you
            }

            public Transition On(in Input.ShowMainMenu input) => throw new System.NotImplementedException(); //TODO: impl
            public Transition On(in Input.ExitGame input) => throw new System.NotImplementedException(); //TODO: impl
        }
    }
}
