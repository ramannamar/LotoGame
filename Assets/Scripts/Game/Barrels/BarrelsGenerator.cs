using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Barrels
{
	[Serializable]
	public class BarrelsGenerator
	{
		[SerializeField] private GameObject barrelPrefab;
		[SerializeField] private Transform container;
		[SerializeField] public TMP_Text lastNumberText;
		private int maxBarrels = 5;
		private List<int> availableNumbers = new List<int>();
		private Queue<GameObject> barrels = new Queue<GameObject>();
		private List<int> recentNumbers = new List<int>();
		private readonly List<int> lastFiveNumbers = new();
		public List<int> LastFiveNumbers => lastFiveNumbers;
		private ObjectPool<GameObject> barrelPool;
		public Action<GameObject> OnBarrelCreated;
		public Action<GameObject> OnBarrelDestroy;
		public Action<int> LastRemovedNumber;

		public void Init()
		{
			for (int i = 1; i <= 90; i++)
			{
				availableNumbers.Add(i);
			}

			barrelPool = new ObjectPool<GameObject>(
			  prewarmCount: maxBarrels,
			  constructor: () => UnityEngine.Object.Instantiate(barrelPrefab, container),
			  postPush: barrel => barrel.SetActive(false),
			  prePop: barrel => barrel.SetActive(true)
			);

			for (int i = 0; i < maxBarrels; i++)
			{
				GameObject newBarrel = barrelPool.Pop();
				barrelPool.Push(newBarrel);
			}

			CoroutineRunner.Instance.StartCoroutine(GenerateBarrels());
		}

		private IEnumerator GenerateBarrels()
		{
			while (true)
			{
				yield return new WaitForSeconds(3f);

				if (availableNumbers.Count == 0)
				{
					yield break;
				}

				int randomIndex = UnityEngine.Random.Range(0, availableNumbers.Count);
				int number = availableNumbers[randomIndex];
				availableNumbers.RemoveAt(randomIndex);

				GameObject newBarrel = barrelPool.Pop();
				newBarrel.transform.position = container.position;
				TMP_Text barrelText = newBarrel.GetComponentInChildren<TMP_Text>();
				barrelText.text = number.ToString();
				barrels.Enqueue(newBarrel);

				lastNumberText.text = number.ToString();

				recentNumbers.Add(number);
				lastFiveNumbers.Add(number);
				if (recentNumbers.Count > 5)
				{
					recentNumbers.RemoveAt(0);
					int removedNumber = lastFiveNumbers[0];
					lastFiveNumbers.RemoveAt(0);
					LastRemovedNumber?.Invoke(removedNumber);
				}

				if (barrels.Count > maxBarrels)
				{
					GameObject oldBarrel = barrels.Dequeue();
					CoroutineRunner.Instance.StartCoroutine(BarrelDespawn(oldBarrel));
				}

				OnBarrelCreated?.Invoke(newBarrel);
			}
		}

		public IEnumerator BarrelDespawn(GameObject oldBarrel)
		{
			OnBarrelDestroy?.Invoke(oldBarrel);
			yield return new WaitForSeconds(1f);
			barrelPool.Push(oldBarrel);
		}

		public IEnumerable<GameObject> GetBarrels()
		{
			return barrels;
		}
	}
}