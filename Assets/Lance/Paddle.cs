using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    protected float speed = 10;
    protected float height;
    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
        Debug.Log("Height: " + height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
