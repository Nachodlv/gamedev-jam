using System;
using System.Linq;
using UnityEngine;

namespace Enemy.Ai.States
{
	public class PlayAnimationState : IState
	{
		public bool Finished { get; private set; }

		private readonly Animator _animator;
		private readonly Transform _player;
		private readonly Mover _mover;
		private float _remainingTime;
		private readonly int _animationTrigger;
		private readonly string _stateName;
		private bool _hasRemainingTime;

		public PlayAnimationState(Animator animator, Transform player, Mover mover, string animationTrigger,
			string stateName)
		{
			_animator = animator;
			_mover = mover;
			_player = player;
			_animationTrigger = Animator.StringToHash(animationTrigger);
			_stateName = stateName;
		}

		public void Tick()
		{
			if (!_hasRemainingTime)
			{
				GetRemainingTime();
				return;	
			}
			_remainingTime -= Time.deltaTime;
			if (_remainingTime <= 0) Finished = true;
		}

		public void FixedTick()
		{
		}

		public void OnEnter()
		{
			LookAtTarget();
			_animator.SetTrigger(_animationTrigger);
		}

		public void OnExit()
		{
			_remainingTime = 0;
			Finished = false;
			_hasRemainingTime = false;
		}

		private void LookAtTarget()
		{
			_mover.Flip(_player.position.x < _animator.transform.position.x ? new Vector2(-1, 0) : new Vector2(1, 0));
		}

		private void GetRemainingTime()
		{
			var clips = _animator.GetCurrentAnimatorClipInfo(0).ToList();
			clips.AddRange(_animator.GetNextAnimatorClipInfo(0));
			foreach (var animatorClipInfo in clips)
			{
				if (animatorClipInfo.clip.name == _stateName)
				{
					_remainingTime = animatorClipInfo.clip.length;
					_hasRemainingTime = true;
				}
			}
		}
	}
}