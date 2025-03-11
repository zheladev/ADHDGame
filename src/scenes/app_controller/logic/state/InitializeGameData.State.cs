namespace ADHDGame.Scenes.AppController;

using Chickensoft.Introspection;
using Chickensoft.LogicBlocks;

public partial class AppControllerLogic {
    public partial record State {
        [Meta]
        public partial record InitializeGameData : State, IGet<Input.EnterInGame> {
            public InitializeGameData() {
                this.OnEnter(OnEnterHandler);
            }

            public Transition On(in Input.EnterInGame input) => To<InGame>();

            private void OnEnterHandler() =>
                // TODO: initialize user data
                Output(new Output.InitializeGameData());
        }
    }
}
