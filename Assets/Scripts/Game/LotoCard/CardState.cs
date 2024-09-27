using System.Collections.Generic;
using LotoButtons;
using System;

namespace LotoCard
{
    [Serializable]
	public class CardState
	{
		public event Action<bool, int, int> RowEmpty;
		public event Action<bool> CardEmpty;
		private const int Rows = 3;
		private const int Columns = 9;
		private HashSet<int>[] rowNumbers;
		private LotoMatches lotoMatches;
		private int cardNumber;

		public CardState(LotoMatches lotoMatches, int cardNumber)
		{
			rowNumbers = new HashSet<int>[Rows];
			for (int i = 0; i < Rows; i++)
			{
				rowNumbers[i] = new HashSet<int>();
			}

			this.lotoMatches = lotoMatches;
			this.cardNumber = cardNumber;
			lotoMatches.NumberMarked += MarkNumber;
		}

		public void AddNumber(int rowIndex, int number)
		{
			rowNumbers[rowIndex].Add(number);
		}

		private void MarkNumber(int number)
		{
			for (int i = 0; i < Rows; i++)
			{
				if (rowNumbers[i].Remove(number))
				{
					if (rowNumbers[i].Count == 0)
					{
						RowEmpty?.Invoke(true, cardNumber, i + 1);
					}

					if (IsCardEmpty())
					{
						CardEmpty?.Invoke(true);
					}
					return;
				}
			}
		}

		public bool IsRowEmpty(int rowIndex)
		{
			return rowNumbers[rowIndex].Count == 0;
		}

		public bool IsCardEmpty()
		{
			for (int i = 0; i < Rows; i++)
			{
				if (rowNumbers[i].Count > 0)
				{
					return false;
				}
			}
			return true;

		}
	}
}