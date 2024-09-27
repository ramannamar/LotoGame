// using System.Collections.Generic;
// using LotoCard;

// namespace New
// {
// 	public class MatchFinish
// 	{
// 		private List<CardState> cardStates;
		
// 		public MatchFinish(List<CardState> cardStates)
// 		{
// 			this.cardStates = cardStates;
// 			SubscribeToEvents();
// 		}
		
// 		private void SubscribeToEvents()
// 		{
// 			foreach (var cardState in cardStates)
// 			{
// 				cardState.CardEmpty += CardEmpty;
// 			}
// 		}
		
// 		private void CardEmpty(bool empty)
// 		{
			
// 		}
// 	}
// }