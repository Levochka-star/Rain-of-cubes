using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Color : MonoBehaviour
{
    private Renderer _renderer;
    private UnityEngine.Color _color = new UnityEngine.Color(0.016f, 0.596f, 0.376f);
    private bool _wasTouch = false;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = _color;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain") && _wasTouch == false)
        {
            Work();
            _wasTouch = true;
        }
    }

    private void Work()
    {
        _renderer.material.color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, 1f, 1f);
    }
}
