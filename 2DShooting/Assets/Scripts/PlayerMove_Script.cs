using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove_Script : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0.02f;

    // Update is called once per frame
    private void Update()
    {
        float moveSpeed = _moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift)) {
            moveSpeed *= 0.5f;
        }
        if (Input.GetKey(KeyCode.W)) {
            gameObject.transform.position += new Vector3(0, moveSpeed, 0);
        }
        if (Input.GetKey(KeyCode.S)) {
            gameObject.transform.position += new Vector3(0, -moveSpeed, 0);
        }
        if (Input.GetKey(KeyCode.A)) {
            gameObject.transform.position += new Vector3(-moveSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D)) {
            gameObject.transform.position += new Vector3(moveSpeed, 0, 0);
        }
    }
}
