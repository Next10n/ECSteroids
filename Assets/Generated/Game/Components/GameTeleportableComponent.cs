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

    static readonly TeleportableComponent teleportableComponent = new TeleportableComponent();

    public bool isTeleportable {
        get { return HasComponent(GameComponentsLookup.Teleportable); }
        set {
            if (value != isTeleportable) {
                var index = GameComponentsLookup.Teleportable;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : teleportableComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherTeleportable;

    public static Entitas.IMatcher<GameEntity> Teleportable {
        get {
            if (_matcherTeleportable == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Teleportable);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTeleportable = matcher;
            }

            return _matcherTeleportable;
        }
    }
}
