using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralacks : MonoBehaviour
{
    [SerializeField] private Transform[] _layers;
    [SerializeField] private float[] _coef;

    private int _layersCount;
    private void Start()
    {
        _layersCount = _layers.Length;
    }
    private void Update()
    {
        for(int i = 0; i < _layersCount; i++)
        {
            _layers[i].position = new Vector3(transform.position.x * _coef[i], transform.position.y * _coef[i], _layers[i].position.z);
        }
    }
}

