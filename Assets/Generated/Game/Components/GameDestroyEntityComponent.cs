//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Game.Components.DestroyEntityComponent destroyEntityComponent = new Game.Components.DestroyEntityComponent();

    public bool isDestroyEntity {
        get { return HasComponent(GameComponentsLookup.DestroyEntity); }
        set {
            if (value != isDestroyEntity) {
                var index = GameComponentsLookup.DestroyEntity;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : destroyEntityComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherDestroyEntity;

    public static Entitas.IMatcher<GameEntity> DestroyEntity {
        get {
            if (_matcherDestroyEntity == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DestroyEntity);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDestroyEntity = matcher;
            }

            return _matcherDestroyEntity;
        }
    }
}