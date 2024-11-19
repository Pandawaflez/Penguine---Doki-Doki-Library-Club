using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RoomsDB
{
    private static int currentRoom;

    public static int getCurrentRoom(){
        return currentRoom;
    }

    public static void setCurrentRoom( int x ){
        currentRoom = x;
    }

}