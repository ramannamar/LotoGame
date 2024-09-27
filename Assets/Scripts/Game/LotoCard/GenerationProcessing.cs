using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine.UI;

namespace LotoCard
{
    public class GenerationProcessing
    {
        public void ClearRandomCells(GridLayoutGroup gridLayoutGroup, int columns)
        {
            TMP_Text[] texts = gridLayoutGroup.GetComponentsInChildren<TMP_Text>();

            ClearRandomCellsInRow(texts, 0, columns, 4);
            ClearRandomCellsInRow(texts, columns, columns, 4);

            int totalNumbers = texts.Count(t => !string.IsNullOrEmpty(t.text));

            List<int> thirdRowIndices = Enumerable.Range(columns * 2, columns).ToList();
            Utility.Shuffle(thirdRowIndices);

            foreach (int columnIndex in Enumerable.Range(0, columns))
            {
                int indexToClear = columnIndex + 2 * columns;
                int[] columnIndices = { columnIndex, columnIndex + columns, indexToClear };

                if (columnIndices.Count(idx => !string.IsNullOrEmpty(texts[idx].text)) == 3)
                {
                    texts[indexToClear].text = string.Empty;
                    totalNumbers--;
                }
            }

            foreach (int index in thirdRowIndices)
            {
                if (totalNumbers <= 15)
                {
                    break;
                }
                if (!string.IsNullOrEmpty(texts[index].text))
                {
                    int columnIndex = index % columns;
                    int[] columnIndices = { columnIndex, columnIndex + columns, columnIndex + 2 * columns };

                    if (columnIndices.Count(idx => !string.IsNullOrEmpty(texts[idx].text)) > 1)
                    {
                        texts[index].text = string.Empty;
                        totalNumbers--;
                    }
                }
            }
        }

        private void ClearRandomCellsInRow(TMP_Text[] texts, int start, int count, int clearCount)
        {
            List<int> indices = Enumerable.Range(start, count).ToList();
            Utility.Shuffle(indices);
            for (int i = 0; i < clearCount; i++)
            {
                texts[indices[i]].text = string.Empty;
            }
        }
    }
}

