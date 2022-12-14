//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class CurrentLaserRestoreTimeEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<ICurrentLaserRestoreTimeListener> _listenerBuffer;

    public CurrentLaserRestoreTimeEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<ICurrentLaserRestoreTimeListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.CurrentLaserRestoreTime)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasCurrentLaserRestoreTime && entity.hasCurrentLaserRestoreTimeListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.currentLaserRestoreTime;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.currentLaserRestoreTimeListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnCurrentLaserRestoreTime(e, component.Value);
            }
        }
    }
}
