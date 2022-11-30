//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Core.Game.Components.Movements;

public partial class GameEntity {

    public RotationAngleComponent rotationAngle { get { return (RotationAngleComponent)GetComponent(GameComponentsLookup.RotationAngle); } }
    public bool hasRotationAngle { get { return HasComponent(GameComponentsLookup.RotationAngle); } }

    public void AddRotationAngle(float newValue) {
        var index = GameComponentsLookup.RotationAngle;
        var component = (RotationAngleComponent)CreateComponent(index, typeof(RotationAngleComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceRotationAngle(float newValue) {
        var index = GameComponentsLookup.RotationAngle;
        var component = (RotationAngleComponent)CreateComponent(index, typeof(RotationAngleComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveRotationAngle() {
        RemoveComponent(GameComponentsLookup.RotationAngle);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherRotationAngle;

    public static Entitas.IMatcher<GameEntity> RotationAngle {
        get {
            if (_matcherRotationAngle == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RotationAngle);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRotationAngle = matcher;
            }

            return _matcherRotationAngle;
        }
    }
}
