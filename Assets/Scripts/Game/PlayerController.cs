using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public Slider slider;
    public float minX; 
    public float maxX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newX = Mathf.Lerp(minX, maxX, slider.value);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

    }
}
