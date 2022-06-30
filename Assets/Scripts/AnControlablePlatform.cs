using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnControlablePlatform : MonoBehaviour
{
    enum StatusMoveMent
    {
        STAY,
        LEFT,
        RIGHT
    }
    [SerializeField] private JointMotor2D _motor;
    [SerializeField] private StatusMoveMent _stCurrent = StatusMoveMent.STAY;
    [SerializeField] private StatusMoveMent _stLast = StatusMoveMent.LEFT;
    [SerializeField] private SliderJoint2D _slider;
    [SerializeField] private bool _onPlatform;
    private void Awake()
    {
        _slider = GetComponent<SliderJoint2D>();
        _motor = _slider.motor;
    }
    private void AnControlableMovement()
    {
        switch (_stCurrent)
        {
            case StatusMoveMent.LEFT:
                _motor.motorSpeed = -1;
                break;
            case StatusMoveMent.RIGHT:
                _motor.motorSpeed = 1;
                break;
        }
        _slider.motor = _motor;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TopBlock") || collision.CompareTag("BottomBlock"))
        {
            switch (_stCurrent)
            {
                case StatusMoveMent.LEFT:
                    _stCurrent = StatusMoveMent.RIGHT;
                    break;
                case StatusMoveMent.RIGHT:
                    _stCurrent = StatusMoveMent.LEFT;
                    break;
            }
        }
    }
    private void Update()
    {
        AnControlableMovement();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
