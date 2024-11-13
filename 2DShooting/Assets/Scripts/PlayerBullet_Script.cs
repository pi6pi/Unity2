using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet_Script : MonoBehaviour
{
    [SerializeField] private int _lifeTime = 5;
    [SerializeField] private float _speed = 1.0f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * _speed, ForceMode2D.Impulse);

        Destroy(gameObject, _lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
            Destroy(gameObject);
    }
}
