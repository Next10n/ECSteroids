using Entitas;
using UnityEngine;

namespace Services.AssetProvider
{
    public interface IViewController
    {
        Vector2Int Position {get; set;}
        void InitializeView(Contexts contexts, IEntity entity);
        void DestroyView();
    }
}