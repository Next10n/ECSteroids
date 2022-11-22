namespace Services.UpdateService
{
    public interface IUpdateService : IService
    {
        void RegisterUpdatable(IUpdatable updatable);
        void UnRegisterUpdatable(IUpdatable updatable);
        void RegisterLateUpdatable(ILateUpdatable lateUpdatable);
        void UnRegisterLateUpdatable(ILateUpdatable lateUpdatable);
    }
}