using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InitializationUtils;

namespace Health
{
    public class HealthBehaviour : MonoBehaviour, IHealthSystem
    {
        [SerializeField] private List<float> healthWaves = new List<float>();
        [SerializeField] private List<GameObject> gameObjectsWithRenderersToFlashOnHit = new List<GameObject>();

        private int _currentWave;
        private float _currentHealth;
        private IList<SpriteRenderer> _renderersToFlashOnHit = new List<SpriteRenderer>();
        private IList<Color> _renderersOriginalColours = new List<Color>();
        private bool _isFlashing;

        private void Awake()
        {
            if (healthWaves.Count == 0)
            {
                StopAndThrowInitializationError($"Failed to initialize {name}, {nameof(healthWaves)} needs at least 1 value.");
            }

            gameObjectsWithRenderersToFlashOnHit.ForEach(gameObjectToFlash =>
            {
                SpriteRenderer spriteRendererToFlash = gameObjectToFlash.GetComponent<SpriteRenderer>();
                if (spriteRendererToFlash == null)
                {
                    StopAndThrowInitializationError(
                            $"Failed to initialize {name}, one of the game objects to flash did not have a sprite renderer");
                }

                _renderersToFlashOnHit.Add(spriteRendererToFlash);
                _renderersOriginalColours.Add(spriteRendererToFlash.color);
            });

            _currentHealth = healthWaves[_currentWave];
        }

        public float Health => ValidateAliveThenReturn(_currentHealth);

        public float HealthMax => ValidateAliveThenReturn(healthWaves[_currentWave]);

        public float HealthPercentage => ValidateAliveThenReturn(Health / HealthMax);

        public bool IsPermaDead => _currentWave >= healthWaves.Count;

        public int FutureWaveCount => ValidateAliveThenReturn(healthWaves.Count - _currentWave);

        public void DealDamage(float damage)
        {
            _currentHealth -= damage;
            OnHealthChange?.Invoke(this);
            if (_currentHealth <= 0f)
            {
                HandleWaveDeath();
            }
            else if (!_isFlashing)
            {
                StartCoroutine(nameof(FlashSpriteRenders));
            }
        }

        private IEnumerator FlashSpriteRenders()
        {
            for (int flashCount = 0; flashCount < 2; flashCount++)
            {
                for (int rendererIndex = 0; rendererIndex < _renderersToFlashOnHit.Count; rendererIndex++)
                {
                    SpriteRenderer spriteRenderer = _renderersToFlashOnHit[rendererIndex];
                    Color colour = _renderersOriginalColours[rendererIndex];
                    Color flashColour = (Color.white * 2f + colour) / 3f;
                    spriteRenderer.color = flashColour;
                }

                yield return new WaitForSeconds(0.1f);

                for (int rendererIndex = 0; rendererIndex < _renderersToFlashOnHit.Count; rendererIndex++)
                {
                    SpriteRenderer spriteRenderer = _renderersToFlashOnHit[rendererIndex];
                    Color colour = _renderersOriginalColours[rendererIndex];
                    spriteRenderer.color = colour;
                }

                yield return new WaitForSeconds(0.1f);
            }

            StopCoroutine(nameof(FlashSpriteRenders));
            _isFlashing = false;
        }

        public event IHealthSystem.HealthSystemEvent OnWaveDeath;

        public event IHealthSystem.HealthSystemEvent OnHealthChange;

        private T ValidateAliveThenReturn<T>(T toReturn)
        {
            if (IsPermaDead)
            {
                throw new InvalidOperationException($"Object {name} is perma-dead");
            }

            return toReturn;
        }

        private void HandleWaveDeath()
        {
            _currentWave += 1;
            OnWaveDeath?.Invoke(this);

            if (!IsPermaDead)
            {
                Invoke(nameof(SetHealthForNextWave), 0.01f);
            }
        }

        private void SetHealthForNextWave()
        {
            print("Resetting health for next wave");
            _currentHealth = healthWaves[_currentWave];
            OnHealthChange?.Invoke(this);
        }
    }
}
