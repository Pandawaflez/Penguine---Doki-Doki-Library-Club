using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MainPlayer
{
    private static string _playerName;      //encapsulate player name

    private static bool _BCMode;    //holds BCMode bool

    public static string GetPlayerName(){
        return _playerName;
    }

    public static void SetPlayerName(string pName){
        _playerName = pName;
    }

    public static void SetBCMode(bool BCMode){
        _BCMode = BCMode;
    }

    public static bool IsBCMode(){
        return _BCMode;
    }
}
