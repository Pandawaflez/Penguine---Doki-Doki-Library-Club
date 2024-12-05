/*using System.Collections.Generic;
using UnityEngine;

public class RedHeart : MonoBehaviour
{


    public void Start()
    {
        BringToFront();
        OnMouseDownUpdatePoints();
    }

    public void OnMouseDownUpdatePoints()
    {

        // Update affection points for Sonic characters
        affectionManager.ChangeSonicAffectionPoints(5);
        affectionManager.ChangeShadowAffectionPoints(5);

        Debug.Log("Heart Pressed");

        // Destroy the red heart to make it disappear and prevent further clicks
        Destroy(gameObject);
    }

    void BringToFront()
    {
        // Setting the Z-position higher (e.g., 1) will make it appear in front
        transform.position = new Vector3(transform.position.x, transform.position.y, 1f);
    }
}*/
