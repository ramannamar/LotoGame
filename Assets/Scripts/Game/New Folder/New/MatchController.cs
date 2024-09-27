// using System;
// using System.Collections.Generic;
// using LotoCard;
// using UnityEngine;

// namespace New
// {
// 	[Serializable]
// 	public class MatchController
// 	{
// 		private MatchSignals matchSignals;
// 		private MatchFinish matchFinish;
// 		private List<CardState> cardStates;

// 		public void Init(List<CardState> cardStates)
// 		{
// 			this.cardStates = cardStates;
// 			matchSignals = new MatchSignals(cardStates);
// 			matchFinish = new MatchFinish(cardStates);

// 		}
// 	}
// }