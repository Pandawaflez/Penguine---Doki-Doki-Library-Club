using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : Paddle
{
    public GameObject ball;

    void Start() {
        height = transform.localScale.y;
        isPlayerPaddle = false;
    }

    void Update() {
        if (MainPlayer.IsBCMode()) {
            // If in BC mode, make the AI paddle purposely lose
            LoseOnPurpose();
        } else {
            // Normal AI paddle behavior
            NormalAIMovement();
        }
    }

    // Make the AI lose on purpose
    void LoseOnPurpose() {
        float ballY = ball.transform.position.y;
        float paddleY = transform.position.y;

        // move the paddle away from the ball's y position
        float moveDirection = paddleY > ballY ? 1 : -1;

        // move in the opposite direction of the ball
        float move = moveDirection * speed * Time.deltaTime;

        // restrict paddle movement to keep it on screen
        if (transform.position.y < Pong.bottomLeft.y + height / 2 && move < 0) {
            move = 0;
        } else if (transform.position.y > Pong.topRight.y - height / 2 && move > 0) {
            move = 0;
        }

        transform.Translate(move * Vector2.up);
    }

    // Function for normal AI paddle movement
    void NormalAIMovement() {
        float ballY = ball.transform.position.y;
        float paddleY = transform.position.y;
        float moveDirection = ballY - paddleY;

        // clamp the move direction to the AI paddle speed
        float move = Mathf.Clamp(moveDirection, -speed * Time.deltaTime, speed * Time.deltaTime);

        // restrict paddle movement so it doesn't go offscreen
        if (transform.position.y < Pong.bottomLeft.y + height / 2 && move < 0) {
            move = 0;
        } else if (transform.position.y > Pong.topRight.y - height / 2 && move > 0) {
            move = 0;
        }

        transform.Translate(move * Vector2.up);
    }
}
