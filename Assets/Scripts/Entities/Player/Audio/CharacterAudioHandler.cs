using System;
using Entities.Enemy;
using Entities.Grabbables;
using Entities.Player.Abilities;
using Entities.Player.Attack;
using UnityEngine;
using Utils.Audio;
using Entities.Player.Movement;
using CharacterController = Entities.Player.Movement.CharacterController;

namespace Entities.Player
{
	public class CharacterAudioHandler : MonoBehaviour, IPausable
	{
		[Header("Audios")] [SerializeField] private PlayerAudioReferences audioReferences;

		[Header("References")]
		[SerializeField] private CharacterController characterController;
		[SerializeField] private APlayer player;
		[SerializeField] private CharacterAnimator characterAnimator;
		[SerializeField] private PlayerAttacker playerAttacker;
		[SerializeField] private Grabber grabber;

		[Header("Settings")] [SerializeField] private float timeBetweenWalkingClips;
		
		private float _lastWalkingClip;
		private bool _paused;
		
		private void Awake()
		{
			characterController.OnJumpEvent += () => PlaySound(audioReferences.jumpClip);
			characterController.OnLandEvent += () => PlaySound(audioReferences.hitGroundClip);
			player.OnDie += () => PlaySound(audioReferences.dieClip);
			characterAnimator.OnSwordDrawn += () => PlaySound(audioReferences.swordDraw);
			characterAnimator.OnAttackAnimation += () => PlaySound(audioReferences.attackClip);
			player.DashAbility.OnDash += () => PlaySound(audioReferences.dash);
			playerAttacker.OnReflectBullet += () => PlaySound(audioReferences.reflectBullet);
			grabber.OnGrab += () => PlaySound(audioReferences.batteryPickUp);
		}

		private void Update()
		{
			if (Time.time - _lastWalkingClip < timeBetweenWalkingClips || !characterController.Grounded ||
			    Mathf.Abs(characterController.Velocity.x) < 0.01f) return;
			PlaySound(audioReferences.walkingClip);
			_lastWalkingClip = Time.time;
		}

		private void PlaySound(CustomAudioClip customClip)
		{
			AudioManager.Instance.PlaySound(customClip.audioClip, new AudioOptions
			{
				Volume = customClip.volume,
				LowPassFilter = _paused
			});
		}

		public void Pause()
		{
			_paused = true;
			PlaySound(audioReferences.timeStopAbility);
			AudioManager.Instance.PlayBackgroundMusic(audioReferences.continuousStoppedTime.audioClip);
		}

		public void UnPause()
		{
			AudioManager.Instance.StopBackgroundMusic(audioReferences.continuousStoppedTime.audioClip);
			if(_paused) PlaySound(audioReferences.timeStopEnd);
			_paused = false;
		}
	}
}