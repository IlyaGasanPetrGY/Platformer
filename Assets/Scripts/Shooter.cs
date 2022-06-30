using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _forceFire;
    [SerializeField] private Transform _firePosRight;
    [SerializeField] private Transform _firePosLeft;


    private bool _readyToShoot;

    public void ShootNew(float directon)
    {
        
        
        if (directon >= 0)
        {
            GameObject currntBullet = Instantiate(_bullet, _firePosRight.position, Quaternion.identity);
            Rigidbody2D _bulletRB = currntBullet.GetComponent<Rigidbody2D>();
            _bulletRB.velocity = new Vector2(_forceFire * 1, _bulletRB.velocity.y);
        }
        else
        {
            GameObject currntBullet = Instantiate(_bullet, _firePosLeft.position, Quaternion.identity);
            Rigidbody2D _bulletRB = currntBullet.GetComponent<Rigidbody2D>();
            _bulletRB.velocity = new Vector2(_forceFire * -1, _bulletRB.velocity.y);
            currntBullet.transform.rotation = Quaternion.Euler(0, 180, 0);
            
        }
        
    }
}
