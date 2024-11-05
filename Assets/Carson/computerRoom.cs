using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerRoom : Room
{
    private GameObject computer;
    public override void loadRoom(){
        Debug.Log("Loading Computer Lab Room: " + name );
        computer.SetActive(true);
    }

    public override void setComputer ( GameObject x ) {
        computer = x;
        Debug.Log("Computer set." );
    }

}
