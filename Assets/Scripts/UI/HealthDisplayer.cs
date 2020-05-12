using System;
using System.Collections.Generic;
using Entities.Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Image))]
    public class HealthDisplayer: MonoBehaviour
    {
        [SerializeField] private List<Sprite> sprites;

        private Image _image;
        private int _previousIndex;
        private float _range;
        private float _maxHealth;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void SetUpMaxHealth(float maxHealth)
        {
            _maxHealth = maxHealth;
            _range = _maxHealth / sprites.Count;
            _image.sprite = sprites[sprites.Count - 1];
            _previousIndex = sprites.Count - 1;
        }

        public void UpdateHealth(float currentHealth)
        {
            if (currentHealth > _maxHealth)
            {
                SetUpMaxHealth(currentHealth);
                return;
            }
            
            var newIndex = Mathf.CeilToInt(currentHealth / _range);
            if (newIndex == _previousIndex || newIndex >= sprites.Count || newIndex < 0) return;
            _image.sprite = sprites[newIndex];
            _previousIndex = newIndex;
        }
    }
}