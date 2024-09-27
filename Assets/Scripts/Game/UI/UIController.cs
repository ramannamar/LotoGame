using System;
using System.Collections.Generic;
using LotoCard;
using UnityEngine;

namespace UI
{
    [Serializable]
	public class UIController
	{
		[SerializeField] private UIMainMenu mainMenuCanvas = new();
		[SerializeField] private UIGame gameCanvas = new();
		[SerializeField] private UIGameOver gameOverCanvas;
		private List<CardState> cardStates;

		public void Init(Action<bool> onPlayAction, Action<bool> onExitAction)
		{
			mainMenuCanvas.Init(onPlayAction);
			gameOverCanvas.Init(onExitAction);
		}

		public void UpdateGameOver(List<CardState> cardStates)
		{
			this.cardStates = cardStates;
			gameOverCanvas.UpdateState(cardStates);
		}

		public void StartGame(bool onPlay)
		{
			if (onPlay)
			{
				gameCanvas.EnableGame();
				mainMenuCanvas.DisableMainMenu();
				gameOverCanvas.DisableGameOver();
			}
		}

		public void Exit(bool onExit)
		{
			if (onExit)
			{
				gameCanvas.DisableGame();
				mainMenuCanvas.EnableMainMenu();
				gameOverCanvas.DisableGameOver();
			}
		}
	}
}