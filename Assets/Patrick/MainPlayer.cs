using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MainPlayer
{
    private static string _playerName;      //encapsulate player name

    private static bool _BCMode;    //holds BCMode bool

    private static int _minigameStatus = 0;

    public static int GetMiniGameStatus(){
        return _minigameStatus;
    }

    public static void SetMiniGameStatus(int x){
        _minigameStatus = x;
    }

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
