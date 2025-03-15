namespace ADHDGame.Scenes.MapGenerator;

using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.Introspection;
using Godot;

public interface IMapCamera : ICamera2D {
    // Define exposed functions and properties here.
}

[Meta(typeof(IAutoNode))]
public partial class MapCamera : Camera2D, IMapCamera {
    public override void _Notification(int what) => this.Notify(what);

    [Export] private float _minZoom = 0.00048828125f;
    [Export] private float _maxZoom = 512.0f;
    [Export] private float _dragSlowdown = 0.7f;
    [Export] private float _smoothness = 12.0f;

    private bool _isDragging;
    private Vector2 _dragStartPosition;
    private Vector2 _targetPosition;

    #region Nodes
    // AutoInjected child nodes go here.
    // Example:
    // [Node] public IArea2D ExampleArea { get; set; } = default!;
    #endregion Nodes

    #region Signals
    // Signals go here
    // Example:
    // [Signal] public delegate void MainMenuEventHandler();
    #endregion Signals



    #region State
    // Define node state variables here
    // private bool _isRightMouseButtonHeld;
    #endregion State

    #region External
    // Non-godot vars go here
    // Example:
    // public IInstantiator Instantiator { get; set; } = default!;
    #endregion External


    #region Provisions
    // Provisions go here. These are exposed to children and can be retrieved
    // using dependencies. Check Dependencies region for an example.
    // Example:
    // IGameRepository IProvide<IGameRepository>.Value() => GameRepository;
    #endregion Provisions

    #region Dependencies
    // Repository injections go here
    // Example:
    // [Dependency] public IGameRepository GameRepository => this.DependOn<GameRepository>();
    #endregion Dependencies

    public void Setup() {
        // instantiation of objects and context setup
    }

    public void OnReady() { }

    public void OnExitTree() { }

    public override void _Process(double delta) {
        HandleZoom();
        HandleDrag(delta);
        FollowTarget(delta);
    }

    private void HandleZoom() {

        // Increase zoom
        if (Input.IsActionJustReleased("ui_zoom_in")) {
            var zoomFactor = 2f;
            Zoom = new Vector2(Zoom.X * zoomFactor, Zoom.Y * zoomFactor);
        }

        // Reduce zoom
        if (Input.IsActionJustReleased("ui_zoom_out")) {
            var zoomFactor = 2f;
            Zoom = new Vector2(Zoom.X / zoomFactor, Zoom.Y / zoomFactor);
        }

        Zoom = new Vector2(
            Mathf.Clamp(Zoom.X, _minZoom, _maxZoom),
            Mathf.Clamp(Zoom.Y, _minZoom, _maxZoom)
        );

    }

    private void HandleDrag(double delta) {

        if (Input.IsActionJustPressed("ui_right_click")) {
            _isDragging = true;
            _dragStartPosition = GetViewport().GetMousePosition();
        }

        if (Input.IsActionJustReleased("ui_right_click")) {
            _isDragging = false;
        }

        if (_isDragging) {
            var dragCurrentPosition = GetViewport().GetMousePosition();
            var dragOffset = _dragStartPosition - dragCurrentPosition;
            var worldOffset = dragOffset / Zoom * _dragSlowdown;
            _targetPosition += worldOffset;
            _dragStartPosition = GetViewport().GetMousePosition();
        }
    }

    private void FollowTarget(double delta) {
        var t = _smoothness * (float)delta;
        Position = Position.Lerp(_targetPosition, t);
    }
}
