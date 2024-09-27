using System;
using System.Collections.Generic;
using Barrels;
using LotoButtons;
using LotoCard;
using UnityEngine;

namespace Game
{
	[Serializable]
	public class GameController
	{
		[SerializeField] private LotoCardController lotoCardController = new();
		[SerializeField] private BarrelsController barrelsController = new();
		[SerializeField] private ButtonsController buttonsController = new();

		public void Init()
		{
			barrelsController.Init();
			var barrelsGenerator = barrelsController.GetBarrelsGenerator();
			buttonsController.Init(barrelsGenerator);
			var lotoMatches = buttonsController.GetMatches();
			lotoCardController.Init(lotoMatches);
			// var cardStates = GetCardStates();
		}	
		
		public List<CardState> GetCardStates()
		{
			return lotoCardController.GetCardStates();
		}
	}
}