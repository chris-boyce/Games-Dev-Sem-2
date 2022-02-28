using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level1Controller : MonoBehaviour
{
    [SerializeField] private GameObject[] Doors;
    [SerializeField] private GameObject[] TaskComplete;
    public bool LevelFinished;

    private bool CheckTask()
    {
        for (int i = 0; i < TaskComplete.Length; i++)
        {
            if (TaskComplete[i].GetComponent<LaserRecieve>().finishedTask == true)
            {
                return true;
            }
        }
        return false;
    }

    private void Update()
    {
        LevelFinished = CheckTask();
        if(LevelFinished)
        {
            OpenDoors();
        }
        else
        {
            CloseDoor();
        }
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
