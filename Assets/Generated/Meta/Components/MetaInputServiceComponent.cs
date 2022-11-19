//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MetaContext {

    public MetaEntity inputServiceEntity { get { return GetGroup(MetaMatcher.InputService).GetSingleEntity(); } }
    public Services.Components.InputServiceComponent inputService { get { return inputServiceEntity.inputService; } }
    public bool hasInputService { get { return inputServiceEntity != null; } }

    public MetaEntity SetInputService(Services.Input.IInputService newValue) {
        if (hasInputService) {
            throw new Entitas.EntitasException("Could not set InputService!\n" + this + " already has an entity with Services.Components.InputServiceComponent!",
                "You should check if the context already has a inputServiceEntity before setting it or use context.ReplaceInputService().");
        }
        var entity = CreateEntity();
        entity.AddInputService(newValue);
        return entity;
    }

    public void ReplaceInputService(Services.Input.IInputService newValue) {
        var entity = inputServiceEntity;
        if (entity == null) {
            entity = SetInputService(newValue);
        } else {
            entity.ReplaceInputService(newValue);
        }
    }

    public void RemoveInputService() {
        inputServiceEntity.Destroy();
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

    public Services.Components.InputServiceComponent inputService { get { return (Services.Components.InputServiceComponent)GetComponent(MetaComponentsLookup.InputService); } }
    public bool hasInputService { get { return HasComponent(MetaComponentsLookup.InputService); } }

    public void AddInputService(Services.Input.IInputService newValue) {
        var index = MetaComponentsLookup.InputService;
        var component = (Services.Components.InputServiceComponent)CreateComponent(index, typeof(Services.Components.InputServiceComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceInputService(Services.Input.IInputService newValue) {
        var index = MetaComponentsLookup.InputService;
        var component = (Services.Components.InputServiceComponent)CreateComponent(index, typeof(Services.Components.InputServiceComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveInputService() {
        RemoveComponent(MetaComponentsLookup.InputService);
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

    static Entitas.IMatcher<MetaEntity> _matcherInputService;

    public static Entitas.IMatcher<MetaEntity> InputService {
        get {
            if (_matcherInputService == null) {
                var matcher = (Entitas.Matcher<MetaEntity>)Entitas.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.InputService);
                matcher.componentNames = MetaComponentsLookup.componentNames;
                _matcherInputService = matcher;
            }

            return _matcherInputService;
        }
    }
}
