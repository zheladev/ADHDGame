namespace ADHDGame.Repositories;

using System;

public interface IAppRepository {
    public event Action? SplashScreenSkipped;
    public event Action? GameEntered;
    public event Action? GameExited;

    public event Action? MainMenuEntered;
    public event Action? MainMenuExited;

    public void OnEnterMainMenu();
    public void OnExitMainMenu();

    public void OnEnterGame();

    public void OnExitGame();
}

public class AppRepository : IAppRepository {
    public event Action? GameEntered;
    public event Action? GameExited;
    public event Action? MainMenuEntered;
    public event Action? MainMenuExited;
    public event Action? SplashScreenSkipped;

    public void OnSplashScreenSkipped() => SplashScreenSkipped?.Invoke();

    public void OnEnterGame() => GameEntered?.Invoke();
    public void OnEnterMainMenu() => MainMenuEntered?.Invoke();
    public void OnExitGame() => GameExited?.Invoke();
    public void OnExitMainMenu() => MainMenuExited?.Invoke();
}
