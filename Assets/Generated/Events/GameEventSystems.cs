//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class GameEventSystems : Feature {

    public GameEventSystems(Contexts contexts) {
        Add(new DeadEventSystem(contexts)); // priority: 0
        Add(new DestroyEntityEventSystem(contexts)); // priority: 0
        Add(new PositionEventSystem(contexts)); // priority: 0
        Add(new RotationAngleEventSystem(contexts)); // priority: 0
        Add(new ScoreEventSystem(contexts)); // priority: 0
        Add(new VelocityEventSystem(contexts)); // priority: 0
    }
}
