using UnityEngine;

namespace Enemy.Ai.States
{
	public abstract class MoverState: IState
	{
		private readonly Transform _player;
		protected readonly Mover Mover;
		protected readonly Transform _self;

		protected MoverState(Mover mover, Transform self, Transform player)
		{
			Mover = mover;
			_player = player;
			_self = self;
		}
		
		public abstract void Tick();
		public abstract void FixedTick();
		public abstract void OnEnter();
		public abstract void OnExit();
		
		protected void LookAtTarget()
		{
			Mover.Flip(_player.position.x < _self.position.x ? new Vector2(-1, 0) : new Vector2(1, 0));
		}
	}
}