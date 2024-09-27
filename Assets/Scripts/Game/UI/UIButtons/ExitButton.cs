using System;
using UnityEngine.UI;

namespace UI
{
    public class ExitButton : BaseButton
	{
		public ExitButton(Button button) : base(button) { }

		public override void Init(Action<bool> onExit)
		{
			button.onClick.AddListener(() =>
			{
				AddClickAnimation(() => onExit(true));
			});
		}		
	}
}