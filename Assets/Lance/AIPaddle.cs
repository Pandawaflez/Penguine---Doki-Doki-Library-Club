using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : Paddle
{
    public GameObject ball;

    void Start() {
        p_height = transform.localScale.y;
        isPlayerPaddle = false;
    }

    void Update() {
        if (MainPlayer.IsBCMode()) {
            // If in BC mode, make the AI paddle purposely lose
            LoseOnPurpose();
            p_speed = 1;
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
        float move = moveDirection * p_speed * Time.deltaTime;

        // restrict paddle movement to keep it on screen
        if (transform.position.y < Pong.s_bottomLeft.y + p_height / 2 && move < 0) {
            move = 0;
        } else if (transform.position.y > Pong.s_topRight.y - p_height / 2 && move > 0) {
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
        float move = Mathf.Clamp(moveDirection, -p_speed * Time.deltaTime, p_speed * Time.deltaTime);

        // restrict paddle movement so it doesn't go offscreen
        if (transform.position.y < Pong.s_bottomLeft.y + p_height / 2 && move < 0) {
            move = 0;
        } else if (transform.position.y > Pong.s_topRight.y - p_height / 2 && move > 0) {
            move = 0;
        }

        transform.Translate(move * Vector2.up);
    }
}