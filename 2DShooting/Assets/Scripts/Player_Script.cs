using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Script : MonoBehaviour
{

    [SerializeField] GameManager_Script _gameManager;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] private float _fireLate = 0.5f;
    private float _fireLateCool;
    private string[] _hitTags = { "Enemy", "EnemyBullet", "EnemyBomb" };


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        _fireLateCool += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space)) {
            if (CheckFirelate())
            {
                _fireLateCool = 0;
                Instantiate(_bulletPrefab, transform.position, transform.rotation);
            }
        }
    }

    private bool CheckFirelate()
    {
        return _fireLateCool > _fireLate;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (string tag in _hitTags)
        {
            if (other.tag == tag)
                _gameManager.GameOver();
        }
    }
}
