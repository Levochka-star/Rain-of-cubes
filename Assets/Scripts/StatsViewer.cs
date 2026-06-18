using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _spawnedValue;
    [SerializeField] private TextMeshProUGUI _createdValue;
    [SerializeField] private TextMeshProUGUI _activedValue;

    public void Write(int spawnedValue, int createdValue, int activedValue)
    {
        _spawnedValue.text = $"{spawnedValue}";
        _createdValue.text = $"{createdValue}";
        _activedValue.text = $"{activedValue}";
    }
}
