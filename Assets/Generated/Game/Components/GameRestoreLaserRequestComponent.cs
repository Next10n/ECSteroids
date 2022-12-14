//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Core.Game.Components.Weapon;

public partial class GameEntity {

    static readonly RestoreLaserRequestComponent restoreLaserRequestComponent = new RestoreLaserRequestComponent();

    public bool isRestoreLaserRequest {
        get { return HasComponent(GameComponentsLookup.RestoreLaserRequest); }
        set {
            if (value != isRestoreLaserRequest) {
                var index = GameComponentsLookup.RestoreLaserRequest;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : restoreLaserRequestComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherRestoreLaserRequest;

    public static Entitas.IMatcher<GameEntity> RestoreLaserRequest {
        get {
            if (_matcherRestoreLaserRequest == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RestoreLaserRequest);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRestoreLaserRequest = matcher;
            }

            return _matcherRestoreLaserRequest;
        }
    }
}
