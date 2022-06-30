using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CadSceneController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cm;
    [SerializeField] private Image _imgDialog;
    [SerializeField] private Sprite[] _imgArrayDialog;
    [SerializeField] private PlayerInput _player;
    [SerializeField] private Canvas _canvas;

    private int _currentIndex = 0;
    private bool _isStaying;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _canvas.gameObject.SetActive(true);
            collision.GetComponentInParent<MovingPlayer>().SetAnimatingStop();
            _cm.Priority = 20;
            _player.enabled = false;
            _imgDialog.sprite = _imgArrayDialog[_currentIndex];
            _isStaying = true;
        }
    }
    private void ChangerSprite()
    {   
        try
        {
            _currentIndex += 1;
            _imgDialog.sprite = _imgArrayDialog[_currentIndex];
        }
        catch
        {
            _player.enabled = true;
            _cm.Priority = 1;
            _currentIndex = 0;
            _canvas.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isStaying)
        {
            ChangerSprite();
        }
    }

}
