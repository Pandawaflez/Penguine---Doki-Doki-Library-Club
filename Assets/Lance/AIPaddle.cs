using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : Paddle
{
    public GameObject ball;
    string input = "AIPaddle";

    void Start() {
        height = transform.localScale.y;
        isPlayerPaddle = false;
    }

    // Update is called once per frame
    void Update() {
        // get the ball's y position
        float ballY = ball.transform.position.y;

        // get the paddle's current y position
        float paddleY = transform.position.y;

        // move AI paddle towards the ball's y position
        float moveDirection = ballY - paddleY;

        // clamp the move direction to the AI paddle speed
        float move = Mathf.Clamp(moveDirection, -speed * Time.deltaTime, speed * Time.deltaTime);

        // restrict paddle movement so it doesn't go offscreen
        if (transform.position.y < Pong.bottomLeft.y + height / 2 && move < 0) {
            move = 0;
        } else if (transform.position.y > Pong.topRight.y - height / 2 && move > 0) {
            move = 0;
        }

        // move the paddle
        transform.Translate(move * Vector2.up);
    }
}
