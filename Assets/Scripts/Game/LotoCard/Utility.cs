using System.Collections.Generic;

namespace LotoCard
{
    public static class Utility
    {
        public static void Shuffle<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int randomIndex = UnityEngine.Random.Range(i, list.Count);
                (list[i], list[randomIndex]) = (list[randomIndex], list[i]);
            }
        }

        public static List<int> GenerateNumberRange(int start, int end)
        {
            List<int> numbers = new List<int>();

            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            Shuffle(numbers);
            return numbers;
        }
    }
}