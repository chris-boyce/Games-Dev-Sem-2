using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level1Controller : MonoBehaviour
{
    [SerializeField] private GameObject[] Doors;
    public int LevelCount;
    public void OnLaserHit()
    {
        Debug.Log(LevelCount);
        LevelCount++;
        if(LevelCount == 2)
        {
            OpenDoors();
        }

    }
    public void OnLaserNotHit()
    {
        if (LevelCount == 2)
        {
            CloseDoor();
        }
        LevelCount--;
    }

    void OpenDoors()
    {
        Debug.Log("Door Open");
        for (int i = 0; i < 2; i++)
        {
            Doors[i].SetActive(false);
        }

    }
    void CloseDoor()
    {
        Debug.Log("Close Door");
        for (int i = 0; i < 2; i++)
        {
            Doors[i].SetActive(true);
        }
    }


}
