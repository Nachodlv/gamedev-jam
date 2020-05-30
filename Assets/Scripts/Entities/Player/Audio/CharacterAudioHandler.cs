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

		[Header("Settings")] 
		[SerializeField] private float timeBetweenWalkingClips;
		[SerializeField] private float timeBetweenLowHealthClip = 0.2f;
		
		private float _lastWalkingClip;
		private bool _paused;
		private bool _isInLowHealth;
		private float _lastLowHealthClip;
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
			player.OnLowHealth += (isInLowHealth) => _isInLowHealth = isInLowHealth;
			player.OnDamageReceive += () => PlaySound(audioReferences.receiveDamage);
			playerAttacker.OnReflectBullet += () => PlaySound(audioReferences.reflectBullet);
			grabber.OnGrab += () => PlaySound(audioReferences.batteryPickUp);
		}

		private void Update()
		{
			var now = Time.time;
			
			if (now - _lastWalkingClip > timeBetweenWalkingClips && characterController.Grounded &&
			    Mathf.Abs(characterController.Velocity.x) > 0.01f)
			{
				PlaySound(audioReferences.walkingClip);
				_lastWalkingClip = now;
			}

			if (_isInLowHealth && now - _lastLowHealthClip > timeBetweenLowHealthClip)
			{
				PlaySound(audioReferences.lowHealth);
				_lastLowHealthClip = now;
			}
			
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
			_audioSource.volume = customClip.volume;
			_audioSource.Play();
		}

		public void Pause()
		{
			_paused = true;
			PlayInterruptibleSound(audioReferences.timeStopAbility);
			AudioManager.Instance.PauseAllBackgroundMusic();
			AudioManager.Instance.PlayBackgroundMusic(audioReferences.continuousStoppedTime.audioClip, new AudioOptions
			{
				Volume = audioReferences.continuousStoppedTime.volume
			});
		}

		public void UnPause()
		{
			AudioManager.Instance.StopBackgroundMusic(audioReferences.continuousStoppedTime.audioClip);
			if(_paused) PlayInterruptibleSound(audioReferences.timeStopEnd);
			_paused = false;
		}
	}
}