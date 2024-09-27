using TMPro;
using UnityEngine;
using System;
using Button = UnityEngine.UI.Button;

namespace LotoButtons
{
    [Serializable]
	public class LotoButton
	{
		public event Action<int, Button> Clicked;
		private GameObject lotoCard;

		public LotoButton(GameObject lotoCard)
		{
			this.lotoCard = lotoCard;
			Init();
		}

		public void Init()
		{
			AddClickListeners();
		}

		private void AddClickListeners()
		{
			Button[] buttons = lotoCard.GetComponentsInChildren<Button>();

			foreach (Button button in buttons)
			{
				TMP_Text value = button.GetComponentInChildren<TMP_Text>();

				button.onClick.AddListener(() =>
				{
					if (int.TryParse(value.text, out int number))
					{
						Clicked?.Invoke(number, button);
					}
				});
			}
		}
	}
}