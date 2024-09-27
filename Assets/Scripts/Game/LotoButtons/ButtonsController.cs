using System;
using UnityEngine;
using Barrels;
using System.Collections.Generic;

namespace LotoButtons
{
	[Serializable]
	public class ButtonsController
	{
		[SerializeField] private GameObject[] lotoCards;
		private List<LotoButton> lotoButtons;
		private LotoMatches lotoMatches;
		private LotoMissing lotoMissing;
		private BarrelsGenerator barrelsGenerator;

		public void Init(BarrelsGenerator barrelsGenerator)
		{
			this.barrelsGenerator = barrelsGenerator;
			lotoButtons = new List<LotoButton>();

			foreach (GameObject lotoCard in lotoCards)
			{
				LotoButton lotoButton = new LotoButton(lotoCard);
				lotoButtons.Add(lotoButton);
			}

			lotoMatches = new LotoMatches(lotoButtons, barrelsGenerator);
			lotoMissing = new LotoMissing(barrelsGenerator, lotoCards);
		}

		public LotoMatches GetMatches()
		{
			return lotoMatches;
		}
	}
}