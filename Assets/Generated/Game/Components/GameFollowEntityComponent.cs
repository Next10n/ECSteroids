//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Core.Game.Components.FollowEntityComponent followEntity { get { return (Core.Game.Components.FollowEntityComponent)GetComponent(GameComponentsLookup.FollowEntity); } }
    public bool hasFollowEntity { get { return HasComponent(GameComponentsLookup.FollowEntity); } }

    public void AddFollowEntity(int newValue) {
        var index = GameComponentsLookup.FollowEntity;
        var component = (Core.Game.Components.FollowEntityComponent)CreateComponent(index, typeof(Core.Game.Components.FollowEntityComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceFollowEntity(int newValue) {
        var index = GameComponentsLookup.FollowEntity;
        var component = (Core.Game.Components.FollowEntityComponent)CreateComponent(index, typeof(Core.Game.Components.FollowEntityComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveFollowEntity() {
        RemoveComponent(GameComponentsLookup.FollowEntity);
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

    static Entitas.IMatcher<GameEntity> _matcherFollowEntity;

    public static Entitas.IMatcher<GameEntity> FollowEntity {
        get {
            if (_matcherFollowEntity == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.FollowEntity);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFollowEntity = matcher;
            }

            return _matcherFollowEntity;
        }
    }
}