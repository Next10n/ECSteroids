using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreTextListener : ContextsView, IScoreListener
    {
        [SerializeField] private TMP_Text _score;
        
        public override void InitializeView(Contexts contexts)
        {
            base.InitializeView(contexts);
            contexts.game.scoreEntity.AddScoreListener(this);
            OnScore(contexts.game.scoreEntity, contexts.game.score.Value);
        }

        public void OnScore(GameEntity entity, int value)
        {
            _score.text = $"Score : {value}";
        }
    }
}