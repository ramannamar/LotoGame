using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Barrels
{
	public class BarrelsSpawn
	{
		private readonly float targetScale = 1.5f;
		private readonly float duration = 0.3f;
		private BarrelsGenerator barrelsGenerator;
		private BarrelsRotation barrelsRotation;

		public BarrelsSpawn(BarrelsGenerator barrelsGenerator)
		{
			this.barrelsGenerator = barrelsGenerator;
			this.barrelsGenerator.OnBarrelCreated += OnSpawn;
			barrelsRotation = new BarrelsRotation(barrelsGenerator);
		}

		private void OnSpawn(GameObject barrel)
		{
			Image image = barrel.GetComponent<Image>();
			TMP_Text text = barrel.GetComponentInChildren<TMP_Text>();

			text?.DOKill();
			image?.DOKill();

			text?.DOFade(1f, 0.5f);
			image?.DOFade(1f, 0.5f);

			Vector3 originalScale = barrel.transform.localScale;

			barrel.transform.DOKill();

			barrel.transform.DOScale(originalScale * targetScale, duration)
			  .OnComplete(() =>
			  {
				  barrel.transform.DOScale(originalScale, duration)
			  .OnComplete(() =>
			  {
					  barrelsRotation.RotateBarrels();
				  });
			  });
		}
	}
}