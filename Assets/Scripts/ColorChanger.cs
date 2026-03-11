using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Renderer))]

    public class ColorChanger : MonoBehaviour
    {
        private Renderer _renderer;
        private UnityEngine.Color _defaultColor = new UnityEngine.Color(0.016f, 0.596f, 0.376f);

        public bool _wasTouch { get; private set; }

        private void OnEnable()
        {
            _wasTouch = false;
            _renderer = GetComponent<Renderer>();
            _renderer.material.color = _defaultColor;
        }

        public void Work()
        {
            _renderer.material.color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, 1f, 1f);

            _wasTouch = true;
        }

        private void OnDisable()
        {
            _renderer.material.color = _defaultColor;
        }
    }
}