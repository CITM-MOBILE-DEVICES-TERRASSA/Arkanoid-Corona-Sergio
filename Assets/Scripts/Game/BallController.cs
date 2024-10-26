using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float initialSpeed = 10f;
    public float speedIncrement = 0.5f;
    public int reboundsToIncrement = 5;
    public float maxSpeed = 20f;
    public float minSpeed = 5f;
    private int reboundCount = 0;

    private Rigidbody2D rb;
    private bool onPlatform = true;
    public Transform platform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    void Update()
    {

        if (onPlatform)
        {
            transform.position = new Vector3(platform.position.x, platform.position.y + 0.5f, 0f);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                LaunchBall();
            }
        }


        if (!onPlatform && rb.velocity.magnitude < minSpeed)
        {
            rb.velocity = rb.velocity.normalized * minSpeed;
        }
    }

    void LaunchBall()
    {
        rb.isKinematic = false;

        rb.velocity = new Vector2(0f, initialSpeed);
        onPlatform = false;
        reboundCount = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        SoundEffectManager.Instance.PlayBallBounceSound();

        if (rb.velocity.magnitude > minSpeed)
        {
            reboundCount++;

            if (reboundCount >= reboundsToIncrement)
            {
                rb.velocity *= (1 + speedIncrement);


                if (rb.velocity.magnitude > maxSpeed)
                {
                    rb.velocity = rb.velocity.normalized * maxSpeed;
                }

                reboundCount = 0;
            }
        }
    }
    public void ResetBall()
    {

        rb.isKinematic = true;
        transform.position = new Vector3(platform.position.x, platform.position.y + 0.5f, 0f);
        onPlatform = true;
        Debug.Log("Ball position reset to platform.");

    }
}
