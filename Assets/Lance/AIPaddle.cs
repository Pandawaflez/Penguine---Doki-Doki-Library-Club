using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : Paddle
{
    [SerializeField] Ball ball;
    string input = "AIPaddle";

    void Start() {
        height = transform.localScale.y;
        isPlayerPaddle = false;
    }

    // Update is called once per frame
    private void Update() {
        // get the balls y position
        float ballY = ball.transform.position.y;

        // calculate direction to move 
        float move = ballY - transform.position.y;

        move = Mathf.Clamp(move, -speed * Time.deltaTime, speed * Time.deltaTime);

        // Restrict paddle movement so it doesn't go offscreen
        if (transform.position.y < Pong.bottomLeft.y + height / 2 && move < 0) {
            move = 0;
        } else if (transform.position.y > Pong.topRight.y - height / 2 && move > 0) {
            move = 0;
        }

        // move the paddle
        transform.Translate(move * Vector2.up);
    }
}
