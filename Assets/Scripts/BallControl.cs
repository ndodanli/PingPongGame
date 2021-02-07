using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    float ballSpeed = 100;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoBall(1));
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y / 2 + collision.rigidbody.velocity.y);
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.Play();
        }
    }
    IEnumerator GoBall(float delay)
    {
        yield return new WaitForSeconds(delay);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float randomNumber = Random.Range(0, 2);
        if (randomNumber <= 0.5)
        {
            rb.AddForce(new Vector2(ballSpeed, 10));
        }
        else
        {
            rb.AddForce(new Vector2(-ballSpeed, -10));
        }
    }

    public void ResetBall()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        transform.position = new Vector2(0,0);
        StartCoroutine(GoBall(0.5f));
    }

    void Update()
    {
        float xVal = GetComponent<Rigidbody2D>().velocity.x;
        if (xVal < 18 && xVal > -18 && xVal != 0)
        {
            if (xVal > 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(20, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-20, GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }
}
