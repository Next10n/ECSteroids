namespace Infrastructure.Services.Pool
{
    public interface IPoolService
    {
        PoolObject InjectPoolView(GameEntity gameEntity, string poolObjectValue);
        Pool PreparePool(string asset, int size);
    }
}