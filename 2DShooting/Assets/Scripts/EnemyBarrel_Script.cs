using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarrel_Script : MonoBehaviour
{
    [SerializeField]GameObject[] _bulletPrefab;
    private int _pattern;
    private Rigidbody2D rb;
    private float _fireLate;
    private float _fireLateCool;
    float _rotZ;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _fireLateCool = 0;
        _rotZ = 180;
        _pattern = GetComponentInParent<Enemy_Script>().GetLife();
        switch (_pattern)
        {
            case 5:
                SetStatus(1, 0, 0.1f);
                break;
            case 4:
                SetStatus(7, 7, 0.3f);
                break;
            case 3:
                SetStatus(10, 5, 1f);
                break;
            case 2:
                SetStatus(5, 0, 0.1f);
                break;
            case 1:
                SetStatus(1, 0, 0.1f);
                break;
            default:
                break;
        }
    }

    public void SetStatus(int lifeTime, float speed, float fireLate)
    {
        Destroy(gameObject, lifeTime);
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        _fireLate = fireLate;
    }

    // Update is called once per frame
    void Update()
    {
        _fireLateCool += Time.deltaTime;

        switch (_pattern)
        {
            case 5:
                if (CheckFirelate())
                {
                    _rotZ = 120 + (Time.time * 120) % 120; //120`240
                    transform.eulerAngles = new Vector3(0, 0, _rotZ);
                    Instantiate(_bulletPrefab[0], transform.position, transform.rotation);
                    _fireLateCool = 0;
                }
                break;
            case 4:
                if (CheckFirelate())
                {
                    _rotZ = Random.Range(0, 360); //0`360
                    transform.eulerAngles = new Vector3(0, 0, _rotZ);
                    Instantiate(_bulletPrefab[0], transform.position, transform.rotation);
                    _fireLateCool = 0;
                }
                break;
            case 3:
                if (CheckFirelate())
                {
                    _rotZ = 120 + (Time.time * 120) % 120; //120`240
                    transform.eulerAngles = new Vector3(0, 0, _rotZ);
                    Instantiate(_bulletPrefab[0], transform.position, transform.rotation);
                    _fireLateCool = 0;
                }
                break;
            case 2:
                if (CheckFirelate())
                {
                    _rotZ = 120 + (Time.time * 120) % 120; //120`240
                    transform.eulerAngles = new Vector3(0, 0, _rotZ);
                    Instantiate(_bulletPrefab[0], transform.position, transform.rotation);
                    _fireLateCool = 0;
                }
                break;
            case 1:
                if (CheckFirelate())
                {
                    _rotZ = 120 + (Time.time * 120) % 120; //120`240
                    transform.eulerAngles = new Vector3(0, 0, _rotZ);
                    Instantiate(_bulletPrefab[0], transform.position, transform.rotation);
                    _fireLateCool = 0;
                }
                break;
            default:
                break;
        }
    }

    private bool CheckFirelate()
    {
        return _fireLateCool > _fireLate;
    }
}
