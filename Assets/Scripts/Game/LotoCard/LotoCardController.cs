using System;
using System.Collections.Generic;
using LotoButtons;
using UnityEngine;

namespace LotoCard
{
    [Serializable]
	public class LotoCardController
	{
		[SerializeField] private CardGenerator cardGenerator;
		private LotoMatches lotoMatches;
		private List<CardState> cardStates;

		public void Init(LotoMatches lotoMatches)
		{
			this.lotoMatches = lotoMatches;
			cardGenerator.Init(lotoMatches);
			cardStates = cardGenerator.GetCardStates();
		}

		public List<CardState> GetCardStates()
		{
			return cardStates;
		}		
	}
}