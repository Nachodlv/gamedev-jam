using UnityEngine;

namespace Enemy.Ai.States
{
	public abstract class MoverState: IState
	{
		private readonly Transform _player;
		protected readonly Mover Mover;
		protected readonly Animator Animator;

		protected MoverState(Mover mover, Animator animator, Transform player)
		{
			Mover = mover;
			Animator = animator;
			_player = player;
		}
		
		public abstract void Tick();
		public abstract void FixedTick();
		public abstract void OnEnter();
		public abstract void OnExit();
		
		protected void LookAtTarget()
		{
			Mover.Flip(_player.position.x < Animator.transform.position.x ? new Vector2(-1, 0) : new Vector2(1, 0));
		}
	}
}