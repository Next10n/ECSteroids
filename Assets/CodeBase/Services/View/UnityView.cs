using Entitas;
using UnityEngine;

namespace Services.AssetProvider
{
    public class UnityView : MonoBehaviour, IViewController
    {
        public Vector2Int Position { get; set; }
        public void InitializeView(Contexts contexts, IEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void DestroyView()
        {
            throw new System.NotImplementedException();
        }
    }
}