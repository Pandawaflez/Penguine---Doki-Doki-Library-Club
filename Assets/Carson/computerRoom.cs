using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerRoom : Room
{
    public override void loadRoom(){
        Debug.Log("Loading Computer Lab Room: " + name );
    }
}
