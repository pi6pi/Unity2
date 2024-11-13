using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy_Script : MonoBehaviour
{ 
    //メンバ変数
    int _hp;
    [SerializeField] int _maxHp = 50;
    [SerializeField] int _life = 5;
    [SerializeField] Image _hpBar;
    [SerializeField] GameObject _deleteEffect;
    [SerializeField] GameManager_Script _gameManager;
    private string[] _hitTags = { "Player", "PlayerBullet", "PlayerBomb" };

    private Vector3 _defaultPos;
    private Quaternion _defaultRot;

    //弾関係
    [SerializeField] GameObject _barrel;
    private float _fireLate;
    private float _fireLateCool;

    void Start()
    {
        _hp = _maxHp;
        _defaultPos = transform.position;
        _defaultRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        _fireLateCool += Time.deltaTime;

        switch (_life)
        {
            case 5:
                if (CheckFirelate())
                {
                    _fireLate = 1f;
                    Quaternion rot = transform.rotation;
                    rot.eulerAngles = new Vector3(0, 0, 180); //真下
                    Instantiate(_barrel, transform.position, rot, transform);

                    _fireLateCool = 0;
                }
                break;
            case 4:
                if (CheckFirelate())
                {
                    _fireLate = 2f;
                    Quaternion rot = transform.rotation;
                    rot.eulerAngles = new Vector3(0, 0, 180); //真下
                    Instantiate(_barrel, transform.position + new Vector3(20, 10, 0), rot, transform);
                    Instantiate(_barrel, transform.position + new Vector3(-20, 10, 0), rot, transform);

                    _fireLateCool = 0;
                }
                break;
            case 3:
                if (CheckFirelate())
                {
                    _fireLate = 3f;
                    Quaternion rot = transform.rotation;
                    rot.eulerAngles = new Vector3(0, 0, 270); //真左
                    Instantiate(_barrel, transform.position + new Vector3(30, 10, 0), rot, transform);

                    //初期化
                    _fireLateCool = 0;
                }
                break;
            case 2:
                if (CheckFirelate())
                {
                    _fireLate = 1f;
                    transform.eulerAngles = new Vector3(0, 0, 180); //真下
                    Instantiate(_barrel, transform.position, transform.rotation, transform);

                    //初期化
                    _fireLateCool = 0;
                }
                break;
            case 1:
                if (CheckFirelate())
                {
                    _fireLate = 1f;
                    transform.eulerAngles = new Vector3(0, 0, 180); //真下
                    Instantiate(_barrel, transform.position, transform.rotation, transform);

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

    public int GetLife()
    {
        return _life;
    }

    private void ClearGame()
    {
        _gameManager.GameClear();
    }

    private void UpdateHpBar()
    {
        _hpBar.fillAmount = (float)_hp / _maxHp;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bool isHit = false;

        foreach (string tag in _hitTags)
        {
            if (other.tag == tag)
                isHit = true;
        }

        if(isHit)
        {
            if (--_hp <= 0)
            {
                _hp = _maxHp;
                if (--_life <= 0)
                {
                    Instantiate(_deleteEffect, transform.position, transform.rotation);
                    Invoke(nameof(ClearGame), 3f);
                }
            }
            UpdateHpBar();
        }
    }
}
