using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public GameObject Paddle;
    public GameObject BottomWall;
    public GameObject GC;
    Rigidbody2D rigid;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Invoke("Gamestart", 0f);
    }

    void Gamestart()
    {
        transform.position = new Vector3(0f, -3.62f, 0f);
        rigid.velocity = Vector3.zero;
        Paddle.GetComponent<Transform>().position = new Vector3(0f, -4.23f, 0f);
        Paddle.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        new WaitForSeconds(10f);
        rigid.AddForce(new Vector2(3, 12) * speed);
                
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Paddle)
        {
            Vector2 vel;
            vel.x = rigid.velocity.x / 2 + Paddle.GetComponent<Rigidbody2D>().velocity.x / 2;
            vel.y = rigid.velocity.y;

            rigid.velocity = vel;
        }

        if (collision.gameObject == BottomWall)
        {
            GC.GetComponent<GameController>().LoseLife();
            Invoke("Gamestart", 0f);
        }

        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            GC.GetComponent<GameController>().HitBrick();
        }
    }

        
        

}

