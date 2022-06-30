using UnityEngine;

public class BuildBridge : MonoBehaviour
{
    [SerializeField] private Animator _blockAnim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _blockAnim.SetTrigger("Open");
        }
    }
}
