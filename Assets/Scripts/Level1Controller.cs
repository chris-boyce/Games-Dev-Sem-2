using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level1Controller : MonoBehaviour
{
    [Header("Door Objects (Lists : Multiple May be Needed)")]
    [SerializeField] private GameObject[] Doors;
    [Header("End Level Objects (Lists : Must Have TaskFinished)")]
    [SerializeField] private GameObject[] LevelController;

    //Level and Door Checks
    private bool LevelFinished;
    private bool DoorOpened;

    private bool CheckTask() //Runs Through all Level Controls and checks if they are all true
    {
        for (int i = 0; i < LevelController.Length; i++)
        {
            if (LevelController[i].GetComponent<TaskFinished>().TaskCompleted == false)
            {
                return false; //If all are returns true to the script
            }
        }
        return true; 
    }

    private void Update()
    {
        LevelFinished = CheckTask(); //If Level Finish returns true activate open door function
        if(LevelFinished && DoorOpened == false)
        {
            OpenDoors();
        }
        if (!LevelFinished && DoorOpened == true) //Or Close the door if level not completed
        {
            CloseDoor();
        }
    }

    void OpenDoors() //Disable all the door in the list
    {
        DoorOpened = true; //Tells the script the door is opened
        for (int i = 0; i < 2; i++)
        {
            Doors[i].SetActive(false);
        }

    }
    void CloseDoor() //Closes the door if called
    {
        for (int i = 0; i < 2; i++)
        {
            Doors[i].SetActive(true);
        }
        DoorOpened = false;
    }


}
