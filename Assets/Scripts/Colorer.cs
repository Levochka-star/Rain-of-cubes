using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Renderer))]

    public class Colorer : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Color _defaultColor = new UnityEngine.Color(0.016f, 0.596f, 0.376f);
        [SerializeField] private float _defaultAlpha = 1.0f;

        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void OnEnable()
        {
            _renderer.material.color = _defaultColor;

            SetAlphaChannel(_defaultAlpha);
        }

        private void OnDisable()
        {
            if (_renderer != null && _renderer.material != null)
                _renderer.material.color = _defaultColor;
        }

        public void SetRandom()
        {
            _renderer.material.color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, 1f, 1f);
        }

        public void SetAlphaChannel(float value)
        {
            Color newColor = _renderer.material.color;

            newColor.a = value;

            _renderer.material.color = newColor;
        }
    }
}