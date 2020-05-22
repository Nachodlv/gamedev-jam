using System;
using Entities.Enemy;
using Entities.Player.Abilities;
using Entities.Player.Attack;
using UnityEngine;
using Utils.Audio;
using CharacterController = Entities.Player.Movement.CharacterController;

namespace Entities.Player
{
	public class CharacterAudioHandler : MonoBehaviour
	{
		[Header("Audios")] 
		[SerializeField] private AudioClip swordDraw;
		[SerializeField] private AudioClip attackClip;
		[SerializeField] private AudioClip jumpClip;
		[SerializeField] private AudioClip hitGroundClip;
		[SerializeField] private AudioClip timeStopAbility;
		[SerializeField] private AudioClip dieClip;
		[SerializeField] private AudioClip walkingClip;
		[SerializeField] private AudioClip continousStoppedTime;
		[SerializeField] private AudioClip timeStopEnd;
		[SerializeField] private AudioClip dash;

		[Header("References")]
		[SerializeField] private CharacterController characterController;
		[SerializeField] private PlayerAttacker playerAttacker;
		[SerializeField] private APlayer player;
		[SerializeField] private CharacterAnimator characterAnimator;
		[SerializeField] private DashAbility dashAbility;

		[Header("Settings")] [SerializeField] private float timeBetweenWalkingClips;
		
		private float _lastWalkingClip;
		
		private void Awake()
		{
			characterController.OnJumpEvent += () => PlaySound(jumpClip);
			characterController.OnLandEvent += () => PlaySound(hitGroundClip);
			playerAttacker.OnMakeAttack += () => PlaySound(attackClip);
			player.OnDie += () => PlaySound(dieClip);
			characterAnimator.OnSwordDrawn += () => PlaySound(swordDraw);
			dashAbility.OnDash += () => PlaySound(dash);
			//Sonido devolucion bala (TODO)
			//Battery pick up
		}

		private void Start()
		{
			player.TimeStopAbility.OnTimeStop += () => PlaySound(timeStopAbility);
			player.TimeStopAbility.OnTimeStop += () => PlaySound(continousStoppedTime); //TODO
		}

		private void Update()
		{
			if (Time.time - _lastWalkingClip < timeBetweenWalkingClips || !characterController.Grounded ||
			    Mathf.Abs(characterController.Velocity.x) < 0.01f) return;
			PlaySound(walkingClip);
			_lastWalkingClip = Time.time;
		}

		private void PlaySound(AudioClip clip)
		{
			AudioManager.Instance.PlaySound(clip);
		}
	}
}