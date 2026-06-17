using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Sphere))]
[RequireComponent(typeof(Colorer))]
public class SphereAlphaChanger : MonoBehaviour
{
    private Sphere _sphere;
    private Colorer _colorer;

    private void Awake()
    {
        _sphere = GetComponent<Sphere>();
        _colorer = GetComponent<Colorer>();
    }

    private void OnEnable()
    {
        _sphere.AlphaChanging += SetAlpha;
    }

    private void OnDisable()
    {
        _sphere.AlphaChanging -= SetAlpha;
    }

    private void SetAlpha(float value)
    {
        _colorer.SetAlphaChannel(value);
    }
}
