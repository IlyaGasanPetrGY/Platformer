using System.Collections;
using UnityEngine;
using Cinemachine;

public class CMController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cinemachine;
    private bool _wasPressed = false;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_wasPressed)
        {
            _wasPressed = true;
            collision.GetComponentInParent<MovingPlayer>().SetAnimatingStop(collision, _cinemachine);
        }
    }
    
}
