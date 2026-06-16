using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Renderer))]

    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Color _defaultColor = new UnityEngine.Color(0.016f, 0.596f, 0.376f);

        private Renderer _renderer;
        private IColorable _colorable;

        private void Awake()
        {
            _colorable = GetComponent<IColorable>();
            _renderer = GetComponent<Renderer>();
        }

        private void OnEnable()
        {
            _renderer.material.color = _defaultColor;

            if (_colorable != null)
                _colorable.ColorChangeRequested += Work;
        }

        private void OnDisable()
        {
            if (_renderer != null && _renderer.material != null)
                _renderer.material.color = _defaultColor;

            if (_colorable != null)
                _colorable.ColorChangeRequested -= Work;
        }

        public void Work()
        {
            _renderer.material.color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, 1f, 1f);
        }
    }
}