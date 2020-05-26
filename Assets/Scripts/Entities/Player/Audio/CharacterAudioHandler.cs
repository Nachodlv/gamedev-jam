using Entities.Grabbables;
using Entities.Player.Attack;
using UnityEngine;
using Utils.Audio;
using CharacterController = Entities.Player.Movement.CharacterController;

namespace Entities.Player.Audio
{
	[RequireComponent(typeof(AudioClip))]
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
		private AudioSource _audioSource;
		
		private void Awake()
		{
			_audioSource = GetComponent<AudioSource>();
			
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
			});
		}

		private void PlayInterruptibleSound(CustomAudioClip customClip)
		{
			_audioSource.clip = customClip.audioClip;
			_audioSource.Play();
		}

		public void Pause()
		{
			_paused = true;
			PlayInterruptibleSound(audioReferences.timeStopAbility);
			AudioManager.Instance.PlayBackgroundMusic(audioReferences.continuousStoppedTime.audioClip);
		}

		public void UnPause()
		{
			AudioManager.Instance.StopBackgroundMusic(audioReferences.continuousStoppedTime.audioClip);
			if(_paused) PlayInterruptibleSound(audioReferences.timeStopEnd);
			_paused = false;
		}
	}
}