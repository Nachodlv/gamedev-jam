using System;
using Player;
using UnityEngine;

namespace Levels
{
	public class FinishLevel : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!other.GetComponent<APlayer>()) return;
			FindObjectOfType<LevelManager>().FinishLevel();
		}
	}
}