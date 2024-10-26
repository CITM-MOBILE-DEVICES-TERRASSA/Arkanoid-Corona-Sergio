using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public Slider slider;
    public float minX;
    public float maxX;
    public GameObject ball;
    public float speed = 10f;
    private bool isAutoPlay = false;
    private bool hasDoubleShot = false;

    void Update()
    {
        if (isAutoPlay)
        {
            AutoPlay();
        }
        else
        {
            ManualControl(); 
        }

        
        if (Input.GetKeyDown(KeyCode.A))
        {
            isAutoPlay = true;
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            isAutoPlay = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && hasDoubleShot)
        {
            Shoot();
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            ActivateDoubleShot();
        }
    }
    void ActivateDoubleShot()
    {
        hasDoubleShot = true;
        StartCoroutine(DeactivateDoubleShotAfterTime(10f));
    }

    private IEnumerator DeactivateDoubleShotAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        hasDoubleShot = false;
    }

    void ManualControl()
    {
        float newX = Mathf.Lerp(minX, maxX, slider.value);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    void AutoPlay()
    {
        if (ball != null)
        {
            Vector3 ballPosition = ball.transform.position;
            Vector3 paddlePosition = transform.position;
            paddlePosition.x = ballPosition.x;

            paddlePosition.x = Mathf.Clamp(paddlePosition.x, minX, maxX);
            transform.position = paddlePosition;
        }
    }
    void Shoot()
    {

    }

}

