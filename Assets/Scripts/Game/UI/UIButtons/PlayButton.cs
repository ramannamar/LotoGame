using System;
using UnityEngine.UI;

namespace UI
{
    public class PlayButton : BaseButton
    {
        public PlayButton(Button button) : base(button) { }

        public override void Init(Action<bool> onPlay)
        {
            button.onClick.AddListener(() =>
            {
                AddClickAnimation(() => onPlay(true));
            });
        }
    }
}