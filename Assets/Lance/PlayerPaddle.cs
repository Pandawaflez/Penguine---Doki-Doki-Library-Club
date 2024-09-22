using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : Paddle
{
    string input = "PlayerPaddle";

    // Update is called once per frame
    private void Update() {
        // GetAxis is a number between -1 to 1 (-1 for down, 1 for up)
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        // restrict paddle movement so it doesn't go offscreen
        if (transform.position.y < Pong.bottomLeft.y + height / 2 && move < 0) {
            move = 0;
        } else if (transform.position.y > Pong.topRight.y - height / 2 && move > 0) {
            move = 0;
        }

        transform.Translate(move * Vector2.up);
    }
}
