using System;
using UnityEngine;

namespace Barrels

{
	[Serializable]
	public class BarrelsController
	{
		[SerializeField] private BarrelsGenerator barrelsGenerator = new();
		[SerializeField] private BarrelsSpawn barrelsSpawn;
		private BarrelDespawn barrelDespawn;

		public void Init()
		{
			barrelsGenerator.Init();
			barrelsSpawn = new BarrelsSpawn(barrelsGenerator);
			barrelDespawn = new BarrelDespawn(barrelsGenerator);
		}
		
		public BarrelsGenerator GetBarrelsGenerator()
		{
			return barrelsGenerator;
		}
	}
}

