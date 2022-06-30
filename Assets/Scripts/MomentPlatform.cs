using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SliderJoint2D))]
public class MomentPlatform : MonoBehaviour
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
    [SerializeField]private bool _onPlatform;
    private void Awake()
    {
        _slider = GetComponent<SliderJoint2D>();
        _motor = _slider.motor;
    }
    public void MovingPlatform()
    {
        switch (_stCurrent)
        {
            case StatusMoveMent.STAY:
                _motor.motorSpeed = 0;

                break;
            case StatusMoveMent.LEFT:
                _motor.motorSpeed = 1;
                break;
            case StatusMoveMent.RIGHT:
                _motor.motorSpeed = -1;
                break;
        }
        _slider.motor = _motor;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("TopBlock") || collision.CompareTag("BottomBlock"))
        {
            _stLast = _stCurrent;
            _stCurrent = StatusMoveMent.STAY;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _onPlatform = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _onPlatform = false;
        }
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& _onPlatform)
        {
            switch (_stCurrent)
            {
                case StatusMoveMent.STAY:
                    switch (_stLast)
                    {
                        case StatusMoveMent.LEFT:
                            _stCurrent = StatusMoveMent.RIGHT;
                            break;
                        case StatusMoveMent.RIGHT:
                            _stCurrent = StatusMoveMent.LEFT;
                            break;
                        case StatusMoveMent.STAY:
                            _stCurrent = StatusMoveMent.LEFT;
                            break;
                    }
                    break;
                case StatusMoveMent.LEFT:
                    _stLast = _stCurrent;
                    _stCurrent = StatusMoveMent.STAY;
                    break;
                case StatusMoveMent.RIGHT:
                    _stLast = _stCurrent;
                    _stCurrent = StatusMoveMent.STAY;
                    break;
            }
        }
        MovingPlatform();
    }
}