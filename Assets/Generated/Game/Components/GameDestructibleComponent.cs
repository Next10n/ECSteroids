//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Core.Game.Components;

public partial class GameEntity {

    static readonly DestructibleComponent destructibleComponent = new DestructibleComponent();

    public bool isDestructible {
        get { return HasComponent(GameComponentsLookup.Destructible); }
        set {
            if (value != isDestructible) {
                var index = GameComponentsLookup.Destructible;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : destructibleComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherDestructible;

    public static Entitas.IMatcher<GameEntity> Destructible {
        get {
            if (_matcherDestructible == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Destructible);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDestructible = matcher;
            }

            return _matcherDestructible;
        }
    }
}
