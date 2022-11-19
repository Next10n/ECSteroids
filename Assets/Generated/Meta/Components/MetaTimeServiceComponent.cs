//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MetaContext {

    public MetaEntity timeServiceEntity { get { return GetGroup(MetaMatcher.TimeService).GetSingleEntity(); } }
    public Services.Components.TimeServiceComponent timeService { get { return timeServiceEntity.timeService; } }
    public bool hasTimeService { get { return timeServiceEntity != null; } }

    public MetaEntity SetTimeService(Services.Time.ITimeService newValue) {
        if (hasTimeService) {
            throw new Entitas.EntitasException("Could not set TimeService!\n" + this + " already has an entity with Services.Components.TimeServiceComponent!",
                "You should check if the context already has a timeServiceEntity before setting it or use context.ReplaceTimeService().");
        }
        var entity = CreateEntity();
        entity.AddTimeService(newValue);
        return entity;
    }

    public void ReplaceTimeService(Services.Time.ITimeService newValue) {
        var entity = timeServiceEntity;
        if (entity == null) {
            entity = SetTimeService(newValue);
        } else {
            entity.ReplaceTimeService(newValue);
        }
    }

    public void RemoveTimeService() {
        timeServiceEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MetaEntity {

    public Services.Components.TimeServiceComponent timeService { get { return (Services.Components.TimeServiceComponent)GetComponent(MetaComponentsLookup.TimeService); } }
    public bool hasTimeService { get { return HasComponent(MetaComponentsLookup.TimeService); } }

    public void AddTimeService(Services.Time.ITimeService newValue) {
        var index = MetaComponentsLookup.TimeService;
        var component = (Services.Components.TimeServiceComponent)CreateComponent(index, typeof(Services.Components.TimeServiceComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTimeService(Services.Time.ITimeService newValue) {
        var index = MetaComponentsLookup.TimeService;
        var component = (Services.Components.TimeServiceComponent)CreateComponent(index, typeof(Services.Components.TimeServiceComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTimeService() {
        RemoveComponent(MetaComponentsLookup.TimeService);
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
public sealed partial class MetaMatcher {

    static Entitas.IMatcher<MetaEntity> _matcherTimeService;

    public static Entitas.IMatcher<MetaEntity> TimeService {
        get {
            if (_matcherTimeService == null) {
                var matcher = (Entitas.Matcher<MetaEntity>)Entitas.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.TimeService);
                matcher.componentNames = MetaComponentsLookup.componentNames;
                _matcherTimeService = matcher;
            }

            return _matcherTimeService;
        }
    }
}
