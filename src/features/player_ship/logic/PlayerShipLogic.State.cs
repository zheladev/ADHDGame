namespace ADHDGame.Features.PlayerShip;

using Chickensoft.Introspection;
using Chickensoft.LogicBlocks;

public partial class PlayerShipLogic {
    [Meta]
    public abstract partial record State : StateLogic<State>;
}
