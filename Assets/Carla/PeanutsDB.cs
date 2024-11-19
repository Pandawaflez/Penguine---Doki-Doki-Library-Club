using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public static class PeanutsDB
{
    //these are all c# 'builtin' getter/setter functions for the variables
    public static int CharlieDialogueNum{get; set;}
    public static int CharlieAffectionPts{get; set;}
    public static int CharlieLocked{get; set;}

    //initial values stored in db
    private static int charlieDialogueNum=0;
    private static int charlieAffectionPts=0;
    private static int charlieLocked=0;


    //same for lucy
    public static int LucyDialogueNum{get; set;}
    public static int LucyAffectionPts{get; set;}
    public static int LucyLocked{get; set;}

    private static int lucyDialogueNum=0;
    private static int lucyAffectionPts=0;
    private static int lucyLocked=0;

    //same for snoopy
    public static int SnoopyDialogueNum{get; set;}
    public static int SnoopyAffectionPts{get; set;}
    public static int SnoopyLocked{get; set;}

    private static int snoopyDialogueNum=0;
    private static int snoopyAffectionPts=0;
    private static int snoopyLocked=0;

    //and same for schroeder
    public static int SchroederDialogueNum{get; set;}
    public static int SchroederAffectionPts{get; set;}
    public static int SchroederLocked{get; set;}

    private static int schroederDialogueNum=0;
    private static int schroederAffectionPts=0;    
    private static int schroederLocked=0;
}

