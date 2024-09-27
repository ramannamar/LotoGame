using System.Linq;
using Barrels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LotoButtons
{
	public class LotoMissing
	{
		private BarrelsGenerator barrelsGenerator;
		private GameObject[] lotoCards;

		public LotoMissing(BarrelsGenerator barrelsGenerator, GameObject[] lotoCards)
		{
			this.barrelsGenerator = barrelsGenerator;
			this.lotoCards = lotoCards;

			barrelsGenerator.LastRemovedNumber += OnLastRemovedNumberChanged;
		}

		private void OnLastRemovedNumberChanged(int lastRemovedNumber)
		{
			CheckLastRemovedNumber(lastRemovedNumber);
		}

		public void CheckLastRemovedNumber(int lastRemovedNumber)
		{
			foreach (GameObject lotoCard in lotoCards)
			{
				TMP_Text[] textComponents = lotoCard.GetComponentsInChildren<TMP_Text>();
				foreach (TMP_Text text in textComponents)
				{
					if (int.TryParse(text.text, out int buttonNumber) && buttonNumber == lastRemovedNumber)
					{
						SetAlphaToMax(text.gameObject);
					}
				}
			}
		}

		private void SetAlphaToMax(GameObject textObject)
		{
			Transform parentTransform = textObject.transform.parent;
			RawImage cross = parentTransform.GetComponentsInChildren<RawImage>().FirstOrDefault(ri => ri.name == "Cross");
			cross.color = new Color(cross.color.r, cross.color.g, cross.color.b, 1);
		}
	}
}