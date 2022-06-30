using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Helaph : MonoBehaviour
{
    [SerializeField] private float _maxHealph;
    [SerializeField] private float _currentHealph;
    [SerializeField] private Animator _anim;
    private CapsuleCollider2D _collider;
    private PlayerInput _moving;
    private Rigidbody2D _rb;
   

  
    [SerializeField] private Image _hp;
    [SerializeField] private GameObject _canvasDead;
    [SerializeField] private DiferentsTrigersPlayer _killsController;
    
    private void Awake()
    {
        _currentHealph = _maxHealph;
        _anim = GetComponent<Animator>();
        _collider = GetComponent<CapsuleCollider2D>();
        _moving = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody2D>();
    }
    public void TakeDamage(float damge)
    { 
        _currentHealph -= damge;
        _hp.fillAmount = _currentHealph / _maxHealph;
        IsAlivePlayer();
    }
    private void IsAlivePlayer()
    {
        if (_currentHealph < 0)
        {
            Destroy(_collider);
            _rb.bodyType = RigidbodyType2D.Kinematic;
            _anim.SetTrigger("Death");
            if (gameObject.CompareTag("Player"))
            {
                _canvasDead.gameObject.SetActive(true);
                _moving.enabled = false;
                GetComponent<EnemeyMovment>().enabled = false;
                _rb.velocity = new Vector2(0, 0);
            }
            else
            {
                GetComponent<EnemeyMovment>().enabled = false;
                GetComponent<EnemyMessageController>().enabled = false;
                _rb.velocity = new Vector2(0, 0);
                _killsController.CollectKills();
            }

            
        }
    }
    public void AtackAnim()
    {
        _anim.SetTrigger("Atack");
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}