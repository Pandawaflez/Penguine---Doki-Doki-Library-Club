using UnityEngine;

public class PlayerPaddle : Paddle
{
    private string _input = "PlayerPaddle";
    private bool _isMovingUp = false;
    private bool _isMovingDown = false;

    void Start() {
        p_height = transform.localScale.y;
        isPlayerPaddle = true;
    }

    // Update is called once per frame
    private void Update() {
        float move = 0;

        // Use keyboard input for PC
        if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer) {
            move = Input.GetAxis(_input) * Time.deltaTime * p_speed;
        }
        // Use button input for mobile
        else {
            if (_isMovingUp) move = 1 * Time.deltaTime * p_speed;
            else if (_isMovingDown) move = -1 * Time.deltaTime * p_speed;
        }

        // Restrict paddle movement so it doesn't go offscreen
        if (transform.position.y < Pong.s_bottomLeft.y + p_height / 2 && move < 0) {
            move = 0;
        } else if (transform.position.y > Pong.s_topRight.y - p_height / 2 && move > 0) {
            move = 0;
        }

        transform.Translate(move * Vector2.up);
    }

    // Called by the UI button when pressed
    public void OnPressUp() {
        _isMovingUp = true;
    }

    public void OnReleaseUp() {
        _isMovingUp = false;
    }

    public void OnPressDown() {
        Debug.Log("on press down pressed");
        _isMovingDown = true;
    }

    public void OnReleaseDown() {
        Debug.Log("on press down released");
        _isMovingDown = false;
    }
}
