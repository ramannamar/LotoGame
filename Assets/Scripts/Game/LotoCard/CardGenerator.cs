using System;
using System.Collections.Generic;
using LotoButtons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LotoCard
{
    [Serializable]
	public class CardGenerator
	{
		[SerializeField] private GridLayoutGroup[] gridLayoutGroups;

		private readonly int Columns = 9;
		private readonly int TotalCells = 27;
		private readonly int[] startRanges = { 1, 10, 20, 30, 40, 50, 60, 70, 80 };
		private readonly int[] endRanges = { 9, 19, 29, 39, 49, 59, 69, 79, 90 };

		private List<CardState> cardStates;
		private GenerationProcessing generationProcessing;
		private LotoMatches lotoMatches;

		public void Init(LotoMatches lotoMatches)
		{
			generationProcessing = new GenerationProcessing();
			cardStates = new List<CardState>();
			this.lotoMatches = lotoMatches;
			GenerateNumbersInCells();
		}

		private void GenerateNumbersInCells()
		{
			for (int gridIndex = 0; gridIndex < gridLayoutGroups.Length; gridIndex++)
			{
				GridLayoutGroup gridLayoutGroup = gridLayoutGroups[gridIndex];
				TMP_Text[] texts = gridLayoutGroup.GetComponentsInChildren<TMP_Text>();
				List<int>[] Numbers = new List<int>[Columns];

				for (int i = 0; i < Columns; i++)
				{
					Numbers[i] = Utility.GenerateNumberRange(startRanges[i], endRanges[i]);
				}

				for (int i = 0; i < TotalCells; i++)
				{
					TMP_Text text = texts[i];
					int columnIndex = i % Columns;
					text.text = Numbers[columnIndex][0].ToString();
					Numbers[columnIndex].RemoveAt(0);
				}

				generationProcessing.ClearRandomCells(gridLayoutGroup, Columns);

				CardState cardState = new CardState(lotoMatches, gridIndex + 1);
				for (int i = 0; i < texts.Length; i++)
				{
					if (!string.IsNullOrEmpty(texts[i].text))
					{
						int rowIndex = i / Columns;
						cardState.AddNumber(rowIndex, int.Parse(texts[i].text));
					}
				}

				cardStates.Add(cardState);
			}
		}

		public List<CardState> GetCardStates()
		{
			return cardStates;
		}
	}
}