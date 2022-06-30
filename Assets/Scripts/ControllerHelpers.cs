using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHelpers : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listsHelpers;
    [SerializeField] private GameObject _helperSpawn;
    private bool[] _showed;
    
    
    IEnumerator Helps(int i)
    {
        if (!_showed[i])
        {
            GameObject _current = Instantiate(_listsHelpers[i], _helperSpawn.transform);
            yield return new WaitForSeconds(2f);
            Destroy(_current);
            _showed[i] = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lift"))
        {
            StartCoroutine(Helps(0));
        }
    }
    private void Awake()
    {
        _showed = new bool[_listsHelpers.ToArray().Length];
    }
}
