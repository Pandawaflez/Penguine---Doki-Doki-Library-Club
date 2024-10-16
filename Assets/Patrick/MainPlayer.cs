using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MainPlayer
{
    private static string _playerName;      //encapsulate player name

    public static string getPlayerName(){
        return _playerName;
    }

    public static void setPlayerName(string pName){
        _playerName = pName;
    }
}
