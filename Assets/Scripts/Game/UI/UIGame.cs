using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [Serializable]
	public class UIGame
	{
		[SerializeField] private GameObject gameCanvas;
		[SerializeField] private GameObject pausePanel;
		[SerializeField] private Button mainMenu;

		public void EnableGame()
		{
			gameCanvas.SetActive(true);
		}

		public void DisableGame()
		{
			gameCanvas.SetActive(false);
		}
	}
}