namespace ADHDGame.Features.PlayerShip;

using Chickensoft.Introspection;

public partial class PlayerShipLogic {
    public partial record State {
        [Meta]
        public partial record Idle : State {
            public Idle() {
            }
        }
    }
}
