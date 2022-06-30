using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartController : MonoBehaviour
{
    [SerializeField] private WheelJoint2D[] _wheels;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (WheelJoint2D i in _wheels)
            {
                i.useMotor = true;
            }
        }
        if (collision.gameObject.tag == "Bridge")
        {
            foreach (WheelJoint2D i in _wheels)
            {
                i.useMotor = false;
            }
        }
    }
}
