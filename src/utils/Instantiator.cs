namespace ADHDGame.Utils;

using Godot;

/// <summary>
/// Utility class that loads and instantiates scenes.
/// </summary>
public interface IInstantiator {
    /// <summary>Scene tree.</summary>
    public SceneTree SceneTree { get; }

    /// <summary>
    /// Loads and instantiates the given scene.
    /// </summary>
    /// <param name="path">Path to the scene.</param>
    /// <typeparam name="T">Type of the scene's root.</typeparam>
    /// <returns>Instance of the scene.</returns>
    public T LoadAndInstantiate<T>(string path) where T : Node;
}

/// <summary>
/// Utility class that loads and instantiates scenes.
/// </summary>
public class Instantiator(SceneTree sceneTree) : IInstantiator {
    public SceneTree SceneTree { get; } = sceneTree;

    public T LoadAndInstantiate<T>(string path) where T : Node {
        var scene = GD.Load<PackedScene>(path);
        return scene.Instantiate<T>();
    }
}
