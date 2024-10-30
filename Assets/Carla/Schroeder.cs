using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schroeder : Peanuts
{
    // Start is called before the first frame update
    void Start()
    {
        dd = new Dialogue();
        p_dialogueNum=1;
        dd.reg(this, 5);
    }
    public Dialogue dd;
    // Update is called once per frame
    void Update()
    {
        p_dialogueNum=2;
        dd.up();
    }

}
