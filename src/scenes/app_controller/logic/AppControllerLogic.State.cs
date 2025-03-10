namespace ADHDGame.Scenes.AppController;

using Chickensoft.Introspection;
using Chickensoft.LogicBlocks;

public partial class AppControllerLogic {
    [Meta]
    public abstract partial record State : StateLogic<State>;
}
