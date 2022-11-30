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

    public SpawnerComponent spawner { get { return (SpawnerComponent)GetComponent(GameComponentsLookup.Spawner); } }
    public bool hasSpawner { get { return HasComponent(GameComponentsLookup.Spawner); } }

    public void AddSpawner(EnemyType newValue) {
        var index = GameComponentsLookup.Spawner;
        var component = (SpawnerComponent)CreateComponent(index, typeof(SpawnerComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSpawner(EnemyType newValue) {
        var index = GameComponentsLookup.Spawner;
        var component = (SpawnerComponent)CreateComponent(index, typeof(SpawnerComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSpawner() {
        RemoveComponent(GameComponentsLookup.Spawner);
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

    static Entitas.IMatcher<GameEntity> _matcherSpawner;

    public static Entitas.IMatcher<GameEntity> Spawner {
        get {
            if (_matcherSpawner == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Spawner);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSpawner = matcher;
            }

            return _matcherSpawner;
        }
    }
}
