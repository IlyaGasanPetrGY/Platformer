using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody2D))]

[RequireComponent(typeof(Helaph))] 

public class EnemeyMovment : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;
    private Animator _anim;
    [SerializeField, Range(0.1f, 2)] private float speed = 0.5f;

    private enum MovingStatus
    {
        Stay,
        LeftMoving,
        RightMoving
    }
    private MovingStatus _curentStatus = MovingStatus.RightMoving;
    private MovingStatus _lastStatus;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        MovingEnemy();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "RightBlockEnemy":
                {
                    StartCoroutine(SwitcherStatus(MovingStatus.LeftMoving));
                    break;
                }
            case "LeftBlockEnemy":
                {
                    StartCoroutine(SwitcherStatus(MovingStatus.RightMoving));
                    break;
                }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Helaph currentComp;
        if (collision.gameObject.TryGetComponent<Helaph>(out currentComp))
        {
            currentComp.TakeDamage(10);
        }
    }
    public void Dead()
    {
        _curentStatus = MovingStatus.Stay;
    }


    IEnumerator SwitcherStatus (MovingStatus status)
    {
        _lastStatus = _curentStatus;
        _anim.SetBool("Walk", false);


        _curentStatus = MovingStatus.Stay;
        yield return new WaitForSeconds(2f);
        _anim.SetBool("Walk", true);
        _curentStatus = status;
        switch (_curentStatus)
        {
            case MovingStatus.LeftMoving:
                _sprite.flipX = true;
                break;
            case MovingStatus.RightMoving:
                _sprite.flipX = false;
                break;
        }
    }
    
    private void MovingEnemy()
    {
        switch (_curentStatus)
        {
            case MovingStatus.Stay:
                {
                    _rb.velocity = new Vector2(0, _rb.velocity.y);
                    break;
                }

            case MovingStatus.LeftMoving:
                {
                    _rb.velocity = new Vector2(-speed, _rb.velocity.y);
                    break;
                }
            case MovingStatus.RightMoving:
                {
                    _rb.velocity = new Vector2(speed, _rb.velocity.y);
                    break;
                }
        }

    }
}
