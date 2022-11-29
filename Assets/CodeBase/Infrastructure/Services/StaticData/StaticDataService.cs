using System.Collections.Generic;
using System.Linq;
using Core.Game.Components;
using Infrastructure.Services.AssetProvider;
using StaticData;

namespace Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticDataPath = "GameStaticData";
        
        private readonly IAssetProvider _assetProvider;
        private GameStaticData _gameStaticData;

        public StaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public PlayerStaticData PlayerStaticData => _gameStaticData.Player;
        public IEnumerable<SpawnerStaticData> SpawnersStaticData => _gameStaticData.Spawners;
        public int MinAsteroidFragments => _gameStaticData.MinAsteroidFragments;
        public int MaxAsteroidFragments => _gameStaticData.MaxAsteroidsFragments;

        public void Load()
        {
            _gameStaticData = _assetProvider.Load<GameStaticData>(StaticDataPath);
        }

        public EnemyStaticData GetEnemyData(EnemyType enemyType) => 
            _gameStaticData.Enemies.First(x => x.EnemyType == enemyType);

        public WeaponStaticData GetWeaponData(WeaponType weaponType) => 
            _gameStaticData.Weapons.First(x => x.WeaponType == weaponType);
    }
}