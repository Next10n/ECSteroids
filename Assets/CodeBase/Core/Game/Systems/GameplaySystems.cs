﻿using Core.Game.Systems.Collect;
using Core.Game.Systems.DestroySystems;
using Core.Game.Systems.Score;
using Core.Game.Systems.Spawn;

namespace Core.Game.Systems
{
    public sealed class GameplaySystems : Feature
    {
        public GameplaySystems(Contexts contexts)
        {
            Add(new CollectSystems(contexts));
            Add(new MovementSystems(contexts));
            Add(new SpawnSystems(contexts));
            Add(new WeaponSystems(contexts));
            Add(new DestroySystem(contexts));
            Add(new ScoreSystems(contexts));
        }
    }
}