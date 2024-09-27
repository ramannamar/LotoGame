// using System;
// using System.Collections.Generic;
// using LotoCard;
// using UnityEngine;

// namespace New
// {
// 	[Serializable]
// 	public class MatchSignals
// 	{
// 		private List<CardState> cardStates;
// 		public event Action<int, int> RowEmptySignal;

// 		public MatchSignals(List<CardState> cardStates)
// 		{
// 			this.cardStates = cardStates;
// 			// SubscribeToEvents();
// 		}

// 		// private void SubscribeToEvents()
// 		// {
// 		// 	foreach (var cardState in cardStates)
// 		// 	{
// 		// 		cardState.RowEmpty += RowEmpty;
// 		// 		cardState.CardEmpty += CardEmpty;
// 		// 	}
// 		// }

// 		// private void RowEmpty(bool empty, int cardNumber, int row)
// 		// {
// 		// 	if (empty)
// 		// 	{
// 		// 		Debug.Log("Good");
// 		// 	}
// 		// }

// 		// private void CardEmpty(bool empty)
// 		// {
// 		// 	if (empty)
// 		// 	{
// 		// 		foreach (var cardState in cardStates)
// 		// 		{
// 		// 			cardState.RowEmpty -= RowEmpty;

// 		// 		}
// 		// 	}
// 		// }
// 	}
// }