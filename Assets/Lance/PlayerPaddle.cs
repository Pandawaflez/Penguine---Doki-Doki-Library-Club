using UnityEngine;

public class PlayerPaddle : Paddle
{
    private string input = "PlayerPaddle";
    private bool isMovingUp = false;
    private bool isMovingDown = false;

    void Start() {
        height = transform.localScale.y;
        isPlayerPaddle = true;
    }

    // Update is called once per frame
    private void Update() {
        float move = 0;

        // Use keyboard input for PC
        if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer) {
            move = Input.GetAxis(input) * Time.deltaTime * speed;
        }
        // Use button input for mobile
        else {
            if (isMovingUp) move = 1 * Time.deltaTime * speed;
            else if (isMovingDown) move = -1 * Time.deltaTime * speed;
        }

        // Restrict paddle movement so it doesn't go offscreen
        if (transform.position.y < Pong.bottomLeft.y + height / 2 && move < 0) {
            move = 0;
        } else if (transform.position.y > Pong.topRight.y - height / 2 && move > 0) {
            move = 0;
        }

        transform.Translate(move * Vector2.up);
    }

    // Called by the UI button when pressed
    public void OnPressUp() {
        isMovingUp = true;
    }

    public void OnReleaseUp() {
        isMovingUp = false;
    }

    public void OnPressDown() {
        Debug.Log("on press down pressed");
        isMovingDown = true;
    }

    public void OnReleaseDown() {
        Debug.Log("on press down released");
        isMovingDown = false;
    }
}
