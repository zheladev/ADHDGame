namespace ADHDGame;

using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.Introspection;
using Godot;

public interface IPlanet : INode2D {
    // Define exposed functions and properties here.
}

[Meta(typeof(IAutoNode))]
public partial class Planet : Node2D, IPlanet {
    public override void _Notification(int what) => this.Notify(what);

    #region Nodes
    [Node] public ISprite2D SurfaceSprite { get; set; } = default!;
    [Node] public ISprite2D CloudsSprite { get; set; } = default!;
    #endregion Nodes

    #region State
    private float _rotationSpeed = 0.1f;
    [Export]
    public float RotationSpeed {
        get => _rotationSpeed;
        set {
            _rotationSpeed = value;
            SetSMParams("RotationSpeed", value);
        }
    }
    private ShaderMaterial _surfaceMaterial;
    private ShaderMaterial _cloudsMaterial;
    #endregion State

    public void OnReady() {
        var surface_sm = (ShaderMaterial)SurfaceSprite.GetMaterial();
        var clouds_sm = (ShaderMaterial)CloudsSprite.GetMaterial();

        SetSMParams("rotation_speed", RotationSpeed);
    }

    private void SetSMParams(string param_name, Variant value) {
        _surfaceMaterial.SetShaderParameter(param_name, value);
        _cloudsMaterial.SetShaderParameter(param_name, value);
    }
}

