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
            if (newIndex == _previousIndex || newIndex >= sprites.Count || newIndex < 0) return;
            _image.sprite = sprites[newIndex];
            _previousIndex = newIndex;
        }
    }
}