using System;
using System.Linq;
using UnityEngine;

namespace Enemy.Ai.States
{
	public class PlayAnimationState : MoverState
	{
		public bool Finished { get; private set; }

		private float _remainingTime;
		private readonly int _animationTrigger;
		private readonly string _stateName;
		private bool _hasRemainingTime;

		public PlayAnimationState(Animator animator, Transform player, Mover mover, string animationTrigger,
			string stateName): base(mover, animator, player)
		{
			_animationTrigger = Animator.StringToHash(animationTrigger);
			_stateName = stateName;
		}

		public override void Tick()
		{
			if (!_hasRemainingTime)
			{
				GetRemainingTime();
				return;	
			}
			_remainingTime -= Time.deltaTime;
			if (_remainingTime <= 0) Finished = true;
		}

		public override void FixedTick()
		{
		}

		public override void OnEnter()
		{
			LookAtTarget();
			Animator.SetTrigger(_animationTrigger);
		}

		public override void OnExit()
		{
			_remainingTime = 0;
			Finished = false;
			_hasRemainingTime = false;
		}

		

		private void GetRemainingTime()
		{
			var clips = Animator.GetCurrentAnimatorClipInfo(0).ToList();
			clips.AddRange(Animator.GetNextAnimatorClipInfo(0));
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