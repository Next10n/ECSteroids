using System;

namespace Services.SceneProvider
{
    public interface ISceneProvider : IService
    {
        void Load(string sceneName, Action onLoad);
    }
}