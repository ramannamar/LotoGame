using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [Serializable]
	public class UIMainMenu
	{
		[SerializeField] private GameObject mainMenuCanvas;
		[SerializeField] private Button _playButton;
		[SerializeField] private Button _settingsButton;

		private List<BaseButton> buttons;

		public void Init(Action<bool> onPlayButtonClicked)
		{
			buttons = new List<BaseButton>
			{
				new PlayButton(_playButton),
			};

			foreach (var button in buttons)
			{
				button.Init(onPlayButtonClicked);
			}
		}

		public void EnableMainMenu()
		{
			mainMenuCanvas.SetActive(true);
		}

		public void DisableMainMenu()
		{
			mainMenuCanvas.SetActive(false);
		}
	}
}