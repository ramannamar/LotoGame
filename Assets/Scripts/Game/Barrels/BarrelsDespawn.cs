using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Barrels
{
    public class BarrelDespawn
	{
		private BarrelsGenerator barrelsGenerator;

		public BarrelDespawn(BarrelsGenerator barrelsGenerator)
		{
			this.barrelsGenerator = barrelsGenerator;
			this.barrelsGenerator.OnBarrelDestroy += OnDespawn;
		}

		private void OnDespawn(GameObject barrel)
		{
			Image image = barrel.GetComponent<Image>();
			TMP_Text text = barrel.GetComponentInChildren<TMP_Text>();
			image?.DOKill();
			text?.DOKill();

			text?.DOFade(0, 1f);
			image?.DOFade(0, 1f);
		}
	}
}

