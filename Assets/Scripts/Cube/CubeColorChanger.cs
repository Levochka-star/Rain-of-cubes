using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cube))]
[RequireComponent (typeof(Colorer))]
public class CubeColorChanger : MonoBehaviour
{
    private Cube _cube;
    private Colorer _colorer;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
        _colorer = GetComponent<Colorer>();
    }

    private void OnEnable()
    {
        _cube.ColorChangeRequested += SetColor;
    }

    private void OnDisable()
    {
        _cube.ColorChangeRequested -= SetColor;
    }

    private void SetColor()
    {
        _colorer.SetRandom();
    }
}
