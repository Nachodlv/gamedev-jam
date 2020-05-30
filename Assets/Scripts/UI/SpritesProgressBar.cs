using System;
using System.Collections.Generic;
using Entities.Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Image))]
    public class SpritesProgressBar: MonoBehaviour
    {
        [SerializeField] private List<Sprite> sprites;

        private Image _image;
        private int _previousIndex;
        private float _range;
        private float _maxValue;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void SetUpMaxValue(float maxvalue)
        {
            _maxValue = maxvalue;
            _range = _maxValue / sprites.Count;
            _image.sprite = sprites[sprites.Count - 1];
            _previousIndex = sprites.Count - 1;
        }

        public void UpdateValue(float currentValue)
        {
            if (currentValue > _maxValue)
            {
                SetUpMaxValue(currentValue);
                return;
            }
            
            var newIndex = Mathf.CeilToInt(currentValue / _range);
            if (newIndex == _previousIndex ) return;
            if (newIndex >= sprites.Count) newIndex = sprites.Count - 1;
            if (newIndex < 0) newIndex = 0;
            _image.sprite = sprites[newIndex];
            _previousIndex = newIndex;
        }
    }
}