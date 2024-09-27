using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public abstract class BaseButton
    {
        protected Button button;

        protected BaseButton(Button button)
        {
            this.button = button;
        }

        public abstract void Init(Action<bool> onClickAction);

        protected void AddClickAnimation(Action onComplete)
        {
            button.interactable = false;

            Sequence buttonSequence = DOTween.Sequence();

            buttonSequence.Append(button.transform.DOScale(Vector3.one * 1.1f, 0.1f).SetEase(Ease.OutQuad));
            buttonSequence.Append(button.transform.DOScale(Vector3.one, 0.1f).SetEase(Ease.OutQuad));

            buttonSequence.Join(button.transform.DORotate(new Vector3(0, 0, 15), 0.1f).SetEase(Ease.OutQuad));
            buttonSequence.Append(button.transform.DORotate(Vector3.zero, 0.1f).SetEase(Ease.OutQuad));

            buttonSequence.OnComplete(() =>
            {
                button.interactable = true;
                onComplete?.Invoke();
                buttonSequence.Kill();
            });
        }
    }
}