using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyWoodStock : WoodStock
{
    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("fly");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Refresh()
    {
        //PATTERN 6. 'pull' information of interest
        Debug.Log("refreshing fly");
        float pts = (float)getSnoopy().getAffectionPoints();
        pts = (float)(pts/500 +.8);
        sprite.color = new Color(1, pts, 1, 1);
        Debug.Log(pts.ToString());
    }
}
