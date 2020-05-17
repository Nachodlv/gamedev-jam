using UnityEngine;

namespace Entities.Enemy.Ai.States
{
	public class DestroySelfState: IState
	{
		private GameObject _gameObject;

		public DestroySelfState(GameObject gameObject)
		{
			_gameObject = gameObject;
		}
		
		public void Tick()
		{
		}

		public void FixedTick()
		{
		}

		public void OnEnter()
		{
			Object.Destroy(_gameObject);
		}

		public void OnExit()
		{
		}
	}
}