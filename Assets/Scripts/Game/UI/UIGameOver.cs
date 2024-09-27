using System;
using System.Collections.Generic;
using DG.Tweening;
using LotoCard;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [Serializable]
    public class UIGameOver
    {
        private List<CardState> cardStates;
        [SerializeField] private GameObject gameOverCanvas;
        [SerializeField] private Button exitButton;
        
        public void Init(Action<bool> onExit)
        {
            exitButton = gameOverCanvas.GetComponentInChildren<Button>();
            var exitBtn = new ExitButton(exitButton);
            exitBtn.Init(onExit);
            gameOverCanvas.transform.localScale = Vector3.zero;
        }
        
        public void UpdateState(List<CardState> cardStates)
        {
            this.cardStates = cardStates;
            SubscribeToEvents();
        }
        
        private void SubscribeToEvents()
        {
            foreach (var cardState in cardStates)
            {
                cardState.CardEmpty += CardEmpty;
                cardState.RowEmpty += RowEmpty;
            }
        }
        
        private void CardEmpty(bool empty)
        {
            EnableGameOver();
        }
        
        private void RowEmpty(bool empty, int cardNumber, int row)
        {
            if (empty)
            {
                Debug.Log("Good");
            }
        }

        public void EnableGameOver()
        {
            gameOverCanvas.SetActive(true);
            AnimateCanvas();
        }
        
        public void DisableGameOver()
        {
            gameOverCanvas.SetActive(false);
        }

        private void AnimateCanvas()
        {
            gameOverCanvas.transform.localScale = Vector3.zero;
            gameOverCanvas.transform.DOScale(Vector3.one, 1f)
                .SetEase(Ease.OutBack);
        }
    }
}