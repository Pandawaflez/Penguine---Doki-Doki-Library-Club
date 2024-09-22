using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    protected float speed = 10;
    protected float height;
    protected static Vector2 bottomLeft;
    protected static Vector2 topRight;
    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Debug.Log("Height: " + height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
