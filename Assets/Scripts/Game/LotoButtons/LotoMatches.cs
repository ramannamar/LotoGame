using System;
using System.Collections.Generic;
using System.Linq;
using Barrels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LotoButtons
{
	[Serializable]
	public class LotoMatches
	{
		private List<LotoButton> lotoButtons;
		private BarrelsGenerator barrelsGenerator;

		public event Action<int> NumberMarked;

		public LotoMatches(List<LotoButton> lotoButtons, BarrelsGenerator barrelsGenerator)
		{
			this.lotoButtons = lotoButtons;
			this.barrelsGenerator = barrelsGenerator;

			foreach (LotoButton lotoButton in lotoButtons)
			{
				lotoButton.Clicked += OnButtonClicked;
			}
		}

		private void OnButtonClicked(int number, Button button)
		{
			List<int> lastFive = barrelsGenerator.LastFiveNumbers;

			RawImage keg = button.GetComponentsInChildren<RawImage>().FirstOrDefault(ri => ri.name == "Keg");

			if (lastFive.Contains(number))
			{
				keg.color = new Color(keg.color.r, keg.color.g, keg.color.b, 1);

				TMP_Text text = button.GetComponentInChildren<TMP_Text>();
				text.text = text.text.Replace(number.ToString(), string.Empty);

				NumberMarked?.Invoke(number);
			}
		}
	}
}