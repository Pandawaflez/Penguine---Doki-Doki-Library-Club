using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    protected float p_speed = 10;
    protected float p_height;
    public bool isPlayerPaddle = false; // boolean to tell if it is players paddle or AI paddle. Defaults to AI paddle
    // Start is called before the first frame update
    void Start()
    {
        p_height = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPaddle() {
        Vector2 pos = Vector2.zero;
        if (isPlayerPaddle == true) {
            pos = new Vector2(-7.5f, 0);            
        } else {
            pos = new Vector2(7.5f, 0);
        }

        transform.position = pos;
    }

    public float GetSpeed() {
        return p_speed;
    }
}