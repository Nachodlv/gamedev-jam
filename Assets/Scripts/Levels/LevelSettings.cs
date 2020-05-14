using UnityEngine;

namespace Levels
{
	[CreateAssetMenu(fileName = "Level", menuName = "NewLevel", order = 0)]
	public class LevelSettings : ScriptableObject
	{
		public int index;
		public string levelName;
		public float time;
		public Vector2 playerPosition;
		public Sprite[] backgrounds;
	}
}