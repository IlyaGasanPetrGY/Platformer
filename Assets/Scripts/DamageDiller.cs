using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDiller : MonoBehaviour
{
    [SerializeField] private float _damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damagable"))
        {
            collision.gameObject.GetComponent<Helaph>().TakeDamage(_damage);
        }
        Destroy(gameObject);

    }

}
