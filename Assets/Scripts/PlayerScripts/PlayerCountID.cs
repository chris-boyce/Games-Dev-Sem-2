using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCountID : MonoBehaviour
{

    public static int playerID  = 0 ;


    static public int getPlayerID()
    {
        
        playerID = playerID + 1;
        return playerID;
        
    }

}
