using System.Collections;
using Levels;
using UnityEngine;

namespace UI
{
    public class BackgroundChanger : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer background;
        [SerializeField] private SpriteRenderer secondBackground;
        [SerializeField] private LevelManager levelManager;

        private Coroutine _changingBackgrounds;

        private void Awake()
        {
            levelManager.OnLevelChange += (settings) => InitiateBackgrounds(settings.backgrounds, settings.time);
        }

        private void InitiateBackgrounds(Sprite[] backgrounds, float time)
        {
            if (backgrounds.Length == 0) return;
            if (_changingBackgrounds != null) StopCoroutine(_changingBackgrounds);
            if (backgrounds.Length < 2) background.sprite = backgrounds[0];
            else
            {
                _changingBackgrounds = StartCoroutine(GoThroughBackgrounds(backgrounds, 0, time / backgrounds.Length));
            }
        }

        private IEnumerator GoThroughBackgrounds(Sprite[] backgrounds, int currentIndex, float range)
        {
            background.sprite = backgrounds[currentIndex];
            secondBackground.sprite = backgrounds[currentIndex + 1];
            var backgroundColor = background.color;
            backgroundColor.a = 1;
            background.color = backgroundColor;
            
            float t = 0;
            while (background.color.a > 0)
            {
                var color = background.color;
                color.a = Mathf.Lerp(1, 0, t);
                background.color = color;
                t += Time.deltaTime / range;
                yield return null;
            }
            currentIndex++;
            if (currentIndex + 1 >= backgrounds.Length)
            {
                background.sprite = secondBackground.sprite;
                yield break;
            }
            _changingBackgrounds = StartCoroutine(GoThroughBackgrounds(backgrounds, currentIndex, range));
        }
    }
}