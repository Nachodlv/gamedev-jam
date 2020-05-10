using System;
using DefaultNamespace;
using Player.Attack;
using UnityEngine;
using Utils.Audio;

namespace Entities.Player
{
	public class CharacterAudioHandler : MonoBehaviour
	{
		[Header("Audios")]
		[SerializeField] private AudioClip attackClip;
		[SerializeField] private AudioClip jumpClip;
		[SerializeField] private AudioClip hitGroundClip;
		[SerializeField] private AudioClip timeStopAbility;
		[SerializeField] private AudioClip dieClip;
		[SerializeField] private AudioClip walkingClip;
		
		[Header("References")]
		[SerializeField] private CharacterController characterController;
		[SerializeField] private PlayerAttacker playerAttacker;
		[SerializeField] private APlayer player;

		[Header("Settings")] [SerializeField] private float timeBetweenWalkingClips;
		
		private float _lastWalkingClip;
		
		private void Awake()
		{
			// characterController.OnJumpEvent += () => PlaySound(jumpClip);
			characterController.OnLandEvent += () => PlaySound(hitGroundClip);
			playerAttacker.OnMakeAttack += () => PlaySound(attackClip);
			player.OnDie += () => PlaySound(dieClip);
		}

		private void Start()
		{
			player.TimeStopAbility.OnTimeStop += () => PlaySound(timeStopAbility);
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