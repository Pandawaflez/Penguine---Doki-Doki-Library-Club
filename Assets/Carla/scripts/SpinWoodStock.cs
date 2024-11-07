using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWoodStock : WoodStock
{
    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("spin");
    }
    public override void Refresh()
    {
        //PATTERN 6. 'pull' information of interest
        Debug.Log("refreshing spin");
        float pts = (float)getSnoopy().getAffectionPoints();
        //pts = (float)(pts/500 +.8);
        pts = (float)(pts/200 +.5);
        sprite.color = new Color(pts, 1, 1, 1);
        Debug.Log(pts.ToString());
    }
}
