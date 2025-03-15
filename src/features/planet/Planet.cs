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

    private const string SURFACE_SHADER_PATH = "res://src/features/planet/Planet.gdshader";
    private const string CLOUDS_SHADER_PATH = "res://src/features/planet/Clouds.gdshader";

    #region Nodes
    [Node] public ISprite2D SurfaceSprite { get; set; } = default!;
    [Node] public ISprite2D CloudsSprite { get; set; } = default!;
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

        GenerateUniqueShaderMaterials();
        SetRotationSpeed(RotationSpeed);
    }

    public void SetRotationSpeed(float speed) {
        RotationSpeed = speed;
        SetSMParams("rotation_speed", speed);
    }

    private void GenerateUniqueShaderMaterials() {
        var surfaceShader = (Shader)ResourceLoader.Load(SURFACE_SHADER_PATH);
        var cloudsShader = (Shader)ResourceLoader.Load(CLOUDS_SHADER_PATH);

        _surfaceMaterial = new ShaderMaterial {
            Shader = surfaceShader
        };
        SurfaceSprite.SetMaterial(_surfaceMaterial);

        _cloudsMaterial = new ShaderMaterial {
            Shader = cloudsShader
        };
        CloudsSprite.SetMaterial(_cloudsMaterial);
    }

    private void SetSMParams(string param_name, float value) {
        _surfaceMaterial.SetShaderParameter(param_name, value);
        _cloudsMaterial.SetShaderParameter(param_name, value);
    }
}

