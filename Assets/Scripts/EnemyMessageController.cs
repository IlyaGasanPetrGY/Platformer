using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyMessageController : MonoBehaviour
{
    [SerializeField] private Image _message;
    [SerializeField] private float _timer;
    private bool _isvisableImg;
    private void Awake()
    {
        _timer = Random.Range(4,7);
        _isvisableImg = false;
    }
    private void MessageController(bool state)
    {
        _message.gameObject.SetActive(state); 
    }
    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            _timer = Random.Range(1, 4);
            if (_isvisableImg)
            {
                MessageController(!_isvisableImg);
                _isvisableImg = !_isvisableImg;
            }  
            else
            {
                MessageController(!_isvisableImg);
                _isvisableImg = !_isvisableImg;
            }
        }
    }
}
