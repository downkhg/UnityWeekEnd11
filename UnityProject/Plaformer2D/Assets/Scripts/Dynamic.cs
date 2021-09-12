using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic : MonoBehaviour
{
    public float JumpPower;
    public bool isGround;
    public int Score;
    public float Speed;
    public Gun gun;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround)
            {
                Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
                rigidbody.velocity = Vector2.zero;
                rigidbody.AddForce(Vector3.up * JumpPower);
                isGround = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            gun.Shot(Vector3.right);
        }
    }
    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 20), "Score:" + Score);
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Item")
    //    {
    //        Score += 1;
    //        Destroy(collision.gameObject);
    //    }
    //    if(collision.gameObject.tag == "Item")
    //    {
    //        Score += 10;
    //        Destroy(collision.gameObject);
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
        Debug.Log("OnCollisionEnter2D:" + collision.gameObject.name);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isGround = false;
            Debug.Log("OnCollisionExit2D:" + collision.gameObject.name);
        }
    }
}
