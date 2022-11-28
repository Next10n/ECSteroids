﻿using System;
using System.Collections.Generic;
using System.Linq;
using Game.Components;
using Services.AssetProvider;
using StaticData;

namespace Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider _assetProvider;
        private GameStaticData _gameStaticData;

        public StaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public PlayerStaticData PlayerStaticData => _gameStaticData.Player;
        public IEnumerable<SpawnerStaticData> SpawnersStaticData => _gameStaticData.Spawners;

        public void Load()
        {
            _gameStaticData = _assetProvider.Load<GameStaticData>("GameStaticData");
        }

        public EnemyStaticData GetEnemyData(EnemyType enemyType)
        {
            EnemyStaticData enemyStaticData = _gameStaticData.Enemies.First(x => x.EnemyType == enemyType);
            if(enemyStaticData != null)
                return enemyStaticData;
            throw new InvalidOperationException($"Enemy with Type: {enemyType} doesn't found in static data service");
        }
    }
}