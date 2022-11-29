//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MetaContext {

    public MetaEntity staticDataServiceEntity { get { return GetGroup(MetaMatcher.StaticDataService).GetSingleEntity(); } }
    public Services.Components.StaticDataServiceComponent staticDataService { get { return staticDataServiceEntity.staticDataService; } }
    public bool hasStaticDataService { get { return staticDataServiceEntity != null; } }

    public MetaEntity SetStaticDataService(Services.StaticData.IStaticDataService newValue) {
        if (hasStaticDataService) {
            throw new Entitas.EntitasException("Could not set StaticDataService!\n" + this + " already has an entity with Services.Components.StaticDataServiceComponent!",
                "You should check if the context already has a staticDataServiceEntity before setting it or use context.ReplaceStaticDataService().");
        }
        var entity = CreateEntity();
        entity.AddStaticDataService(newValue);
        return entity;
    }

    public void ReplaceStaticDataService(Services.StaticData.IStaticDataService newValue) {
        var entity = staticDataServiceEntity;
        if (entity == null) {
            entity = SetStaticDataService(newValue);
        } else {
            entity.ReplaceStaticDataService(newValue);
        }
    }

    public void RemoveStaticDataService() {
        staticDataServiceEntity.Destroy();
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

    public Services.Components.StaticDataServiceComponent staticDataService { get { return (Services.Components.StaticDataServiceComponent)GetComponent(MetaComponentsLookup.StaticDataService); } }
    public bool hasStaticDataService { get { return HasComponent(MetaComponentsLookup.StaticDataService); } }

    public void AddStaticDataService(Services.StaticData.IStaticDataService newValue) {
        var index = MetaComponentsLookup.StaticDataService;
        var component = (Services.Components.StaticDataServiceComponent)CreateComponent(index, typeof(Services.Components.StaticDataServiceComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceStaticDataService(Services.StaticData.IStaticDataService newValue) {
        var index = MetaComponentsLookup.StaticDataService;
        var component = (Services.Components.StaticDataServiceComponent)CreateComponent(index, typeof(Services.Components.StaticDataServiceComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveStaticDataService() {
        RemoveComponent(MetaComponentsLookup.StaticDataService);
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

    static Entitas.IMatcher<MetaEntity> _matcherStaticDataService;

    public static Entitas.IMatcher<MetaEntity> StaticDataService {
        get {
            if (_matcherStaticDataService == null) {
                var matcher = (Entitas.Matcher<MetaEntity>)Entitas.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.StaticDataService);
                matcher.componentNames = MetaComponentsLookup.componentNames;
                _matcherStaticDataService = matcher;
            }

            return _matcherStaticDataService;
        }
    }
}