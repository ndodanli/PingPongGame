using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public KeyCode moveUp, moveDown;
    public float speed = 10;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveUp)){

            rb.velocity = new Vector2(rb.velocity.x, 10);
        }
        else if (Input.GetKey(moveDown))
        {
            rb.velocity = new Vector2(rb.velocity.x, -10);
        } else {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
}
