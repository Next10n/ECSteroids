using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.StateMachine
{
    public class UnityUpdateService : MonoBehaviour, IUpdateService
    {
        private readonly List<IUpdatable> _updatables = new List<IUpdatable>();
        private readonly List<ILateUpdatable> _lateUpdatables = new List<ILateUpdatable>();

        public void Update()
        {
            foreach (IUpdatable updatable in _updatables)
                updatable.Update();
        }

        public void LateUpdate()
        {
            foreach (ILateUpdatable lateUpdatable in _lateUpdatables)
                lateUpdatable.LateUpdate();
        }

        public void RegisterUpdatable(IUpdatable updatable)
        {
            _updatables.Add(updatable);
        }

        public void UnRegisterUpdatable(IUpdatable updatable)
        {
            if (_updatables.Contains(updatable))
                _updatables.Remove(updatable);
        }

        public void RegisterLateUpdatable(ILateUpdatable lateUpdatable)
        {
            _lateUpdatables.Add(lateUpdatable);
        }

        public void UnRegisterLateUpdatable(ILateUpdatable lateUpdatable)
        {
            if (_lateUpdatables.Contains(lateUpdatable))
                _lateUpdatables.Remove(lateUpdatable);
        }
    }
}