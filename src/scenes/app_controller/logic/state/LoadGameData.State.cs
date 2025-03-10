namespace ADHDGame.Scenes.AppController;

using Chickensoft.Introspection;

public partial class AppControllerLogic {
    public partial record State {
        [Meta]
        public partial record LoadGameData : State, IGet<Input.EnterInGame> {
            public LoadGameData() {
                // TOOD: load user data
            }

            public Transition On(in Input.EnterInGame input) => To<InGame>();
        }
    }
}
