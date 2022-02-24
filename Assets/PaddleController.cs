using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(Vector2.left*speed);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            rigid.velocity = Vector3.zero;
            rigid.Sleep();
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(Vector2.right*speed);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            rigid.velocity = Vector3.zero;
            rigid.Sleep();
        }
    }
}
