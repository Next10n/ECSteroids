using System;
using Core.Systems;
using UnityEngine;

namespace Core
{
    public class Main : MonoBehaviour
    {
        private Contexts _contexts;
        private ApplyDamageSystem _applyDamageSystem;
        private GameCleanupSystems _gameCleanupSystems;
        private ApplyDamageReactiveSystem _applyDamageReactiveSystem;
        private DamageSystems _damageSystems;

        private void Awake()
        {
            _contexts = new Contexts();
            GameEntity gameEntity = _contexts.game.CreateEntity();
            _damageSystems = new DamageSystems(_contexts);
            _gameCleanupSystems = new GameCleanupSystems(_contexts);
            gameEntity.AddHealth(100f);
            gameEntity.AddDamage(5f);
            // _applyDamageSystem = new ApplyDamageSystem(_contexts);
            // _applyDamageReactiveSystem = new ApplyDamageReactiveSystem(_contexts);
        }

        private void Update()
        {
            _damageSystems.Execute();
            // _applyDamageSystem.Execute();
            // _applyDamageReactiveSystem.Execute();
        }

        private void LateUpdate()
        {
            _gameCleanupSystems.Cleanup();
        }
    }
}