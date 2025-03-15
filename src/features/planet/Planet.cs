namespace ADHDGame;

using Chickensoft.AutoInject;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.Introspection;
using Godot;

public interface IPlanet : INode2D {
    public void SetRotationSpeed(float speed); // TODO: fix this shit
}

[Meta(typeof(IAutoNode))]
public partial class Planet : Node2D, IPlanet {
    public override void _Notification(int what) => this.Notify(what);

    #region Nodes
    [Node] public ISprite2D SurfaceSprite { get; set; } = default!;
    [Node] public ISprite2D CloudsSprite { get; set; } = default!;
    [Node] public ITimer Timer { get; set; } = default!;
    #endregion Nodes

    #region State
    [Export]
    public float RotationSpeed { get; set; } = 99f;
    private ShaderMaterial _surfaceMaterial;
    private ShaderMaterial _cloudsMaterial;
    #endregion State

    public void OnReady() {
        _surfaceMaterial = (ShaderMaterial)SurfaceSprite.GetMaterial();
        _cloudsMaterial = (ShaderMaterial)CloudsSprite.GetMaterial();
        SetSMParams("rotation_speed", RotationSpeed);
    }

    public void SetRotationSpeed(float speed) {
        RotationSpeed = speed;
        SetSMParams("rotation_speed", speed);
    }

    private void SetSMParams(string param_name, float value) {
        GD.Print("set to" + value);
        _surfaceMaterial.SetShaderParameter(param_name, value);
        _cloudsMaterial.SetShaderParameter(param_name, value);
    }
}

