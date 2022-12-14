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

    static readonly LaserComponent laserComponent = new LaserComponent();

    public bool isLaser {
        get { return HasComponent(GameComponentsLookup.Laser); }
        set {
            if (value != isLaser) {
                var index = GameComponentsLookup.Laser;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : laserComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherLaser;

    public static Entitas.IMatcher<GameEntity> Laser {
        get {
            if (_matcherLaser == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Laser);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLaser = matcher;
            }

            return _matcherLaser;
        }
    }
}
