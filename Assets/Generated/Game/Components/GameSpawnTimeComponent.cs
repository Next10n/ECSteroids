//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Core.Game.Components.Enemies;

public partial class GameEntity {

    public SpawnTimeComponent spawnTime { get { return (SpawnTimeComponent)GetComponent(GameComponentsLookup.SpawnTime); } }
    public bool hasSpawnTime { get { return HasComponent(GameComponentsLookup.SpawnTime); } }

    public void AddSpawnTime(float newValue) {
        var index = GameComponentsLookup.SpawnTime;
        var component = (SpawnTimeComponent)CreateComponent(index, typeof(SpawnTimeComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSpawnTime(float newValue) {
        var index = GameComponentsLookup.SpawnTime;
        var component = (SpawnTimeComponent)CreateComponent(index, typeof(SpawnTimeComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSpawnTime() {
        RemoveComponent(GameComponentsLookup.SpawnTime);
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

    static Entitas.IMatcher<GameEntity> _matcherSpawnTime;

    public static Entitas.IMatcher<GameEntity> SpawnTime {
        get {
            if (_matcherSpawnTime == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SpawnTime);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSpawnTime = matcher;
            }

            return _matcherSpawnTime;
        }
    }
}
