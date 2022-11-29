using System;

namespace Infrastructure.Services.SceneProvider
{
    public interface ISceneProvider
    {
        void Load(string sceneName, Action onLoad);
    }
}