namespace ADHDGame.Scenes.AppController;

using Chickensoft.Introspection;

public partial class AppControllerLogic {
    public partial record State {
        [Meta]
        public partial record StartNewGame : State, IGet<Input.EnterInGame> {
            public StartNewGame() {
            }

            public Transition On(in Input.EnterInGame input) => To<InGame>();
        }
    }
}
