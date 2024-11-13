using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrazeCount_Script : MonoBehaviour
{
    [SerializeField] GameObject _grazeEffect;
    private int _graze;

    // Start is called before the first frame update
    void Start()
    {
        _graze = 0;
    }

    public int GetGraze()
    {
        return _graze;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyBullet")
        {
            _graze++;
            Instantiate(_grazeEffect, transform.position, transform.rotation);
        }
    }
}
