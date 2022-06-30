using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlayer : MonoBehaviour
{
    [Header("MovingPlayervariables")] 
    [SerializeField] private float jumpForce;
    [SerializeField] private bool onground = false;
    [SerializeField] private Transform _groundColliderTransform;
    [SerializeField] private LayerMask _layerMaskJump;
    [SerializeField] private float jumpOffset;
    [SerializeField] private Animator _anim;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private SpriteRenderer _srpite;
    [SerializeField] private PlayerInput _playerInput;
    
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _srpite = GetComponent<SpriteRenderer>();
    }

   
    private void FixedUpdate()
    {
        CircleDrowing();
    }
    public void Move(float horizontal, bool jump)
    {
        //jump
        //horizontalMovment
        if (jump)
        {
            Jump();
        }
        if (horizontal > 0.0001 || horizontal < -0.0001)
            HorizontalMovement(horizontal);
        else
            _anim.SetBool("Moove", false);
    }
    private void Jump()
    {
        if (onground)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            _anim.SetTrigger("Jump");
        }
    }
    
    private void HorizontalMovement(float dir)
    {
        _rb.velocity = new Vector2(_curve.Evaluate(dir), _rb.velocity.y);
        _anim.SetBool("Moove", true);
        if (dir < 0)
        {
            _srpite.flipX = true;
        }

        else
        {
            _srpite.flipX = false;

        }

    }
    private void CircleDrowing()
    {
        Vector3 overlapCirclePos = _groundColliderTransform.position;
        onground = Physics2D.OverlapCircle(overlapCirclePos, jumpOffset, _layerMaskJump);
    }
    public void Atack()
    {
        _anim.SetTrigger("Atack");
    }
    public void SetAnimatingStop()
    {
        _anim.SetBool("Moove", false);
    }
    public void SetAnimatingStop(Collider2D collision, CinemachineVirtualCamera _currentCM)
    {
        _anim.SetBool("Moove", false);
        StartCoroutine(Cinemachine(collision, 4f, _currentCM));
    }
    private IEnumerator Cinemachine(Collider2D collison, float deltatime, CinemachineVirtualCamera cm)
    {
        _playerInput.enabled = false;
        cm.Priority = 10;
        yield return new WaitForSeconds(deltatime);
        cm.Priority = 1;
        _playerInput.enabled = true;

    }
}
