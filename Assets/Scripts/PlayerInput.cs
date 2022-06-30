using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovingPlayer))]
[RequireComponent(typeof(Shooter))]

public class PlayerInput : MonoBehaviour
{
    private MovingPlayer _playerMovment;
    private Shooter _shooter;
    private void Awake()
    {
        _playerMovment = GetComponent<MovingPlayer>();
        _shooter = GetComponent<Shooter>();
    }
    private void GettingAxis()
    {
        float horizontal = Input.GetAxis("Horizontal");
        bool isjumpbuttonpresed = Input.GetButtonDown("Jump");
        if (Input.GetButtonDown("Fire1"))
        {
            _shooter.ShootNew(horizontal);
            _playerMovment.Atack();
        }
        _playerMovment.Move(horizontal, isjumpbuttonpresed);
    }
    private void Update()
    {
        GettingAxis();
    }
}
