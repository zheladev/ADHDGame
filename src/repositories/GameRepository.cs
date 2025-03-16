namespace ADHDGame.Repositories;

using ADHDGame.Features.PlayerShip;

public interface IGameRepository {
    //public event Action? SplashScreenSkipped;
    //public void OnEnterMainMenu();
}

public class GameRepository : IGameRepository {
    public PlayerShipData PlayerShipData { get; }

    public GameRepository() {
    }
}
