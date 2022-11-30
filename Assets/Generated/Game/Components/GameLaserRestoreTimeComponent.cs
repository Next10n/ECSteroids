//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Core.Game.Components.LaserRestoreTimeComponent laserRestoreTime { get { return (Core.Game.Components.LaserRestoreTimeComponent)GetComponent(GameComponentsLookup.LaserRestoreTime); } }
    public bool hasLaserRestoreTime { get { return HasComponent(GameComponentsLookup.LaserRestoreTime); } }

    public void AddLaserRestoreTime(float newValue) {
        var index = GameComponentsLookup.LaserRestoreTime;
        var component = (Core.Game.Components.LaserRestoreTimeComponent)CreateComponent(index, typeof(Core.Game.Components.LaserRestoreTimeComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceLaserRestoreTime(float newValue) {
        var index = GameComponentsLookup.LaserRestoreTime;
        var component = (Core.Game.Components.LaserRestoreTimeComponent)CreateComponent(index, typeof(Core.Game.Components.LaserRestoreTimeComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLaserRestoreTime() {
        RemoveComponent(GameComponentsLookup.LaserRestoreTime);
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

    static Entitas.IMatcher<GameEntity> _matcherLaserRestoreTime;

    public static Entitas.IMatcher<GameEntity> LaserRestoreTime {
        get {
            if (_matcherLaserRestoreTime == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LaserRestoreTime);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLaserRestoreTime = matcher;
            }

            return _matcherLaserRestoreTime;
        }
    }
}
