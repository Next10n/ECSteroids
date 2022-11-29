namespace Infrastructure.Services.UpdateService
{
    public interface IUpdateService
    {
        void RegisterUpdatable(IUpdatable updatable);
        void UnRegisterUpdatable(IUpdatable updatable);
        void RegisterLateUpdatable(ILateUpdatable lateUpdatable);
        void UnRegisterLateUpdatable(ILateUpdatable lateUpdatable);
    }
}