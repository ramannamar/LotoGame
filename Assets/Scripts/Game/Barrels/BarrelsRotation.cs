using DG.Tweening;
using UnityEngine;

namespace Barrels
{
    public class BarrelsRotation
	{
		private BarrelsGenerator barrelsGenerator;

		public BarrelsRotation(BarrelsGenerator BarrelsGenerator)
		{
			this.barrelsGenerator = BarrelsGenerator;
		}

		public void RotateBarrels()
		{
			float xOffset = 110f;

			foreach (var barrel in barrelsGenerator.GetBarrels())
			{
				RectTransform rectTransform = barrel.GetComponent<RectTransform>();
				Vector2 newPosition = rectTransform.anchoredPosition;
				newPosition.x += xOffset;

				rectTransform.DOKill();

				rectTransform.DOAnchorPos(newPosition, 0.9f);
				rectTransform.DORotate(new Vector3(0, 0, -360), 0.9f, RotateMode.FastBeyond360)
					.SetEase(Ease.Linear);
			}
		}
	}
}