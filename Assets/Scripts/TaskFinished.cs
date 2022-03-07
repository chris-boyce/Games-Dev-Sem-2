using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskFinished : MonoBehaviour
{
    //External Script to check if the Level is Completed
    [Header("Trigger End For Current Level Controller")]
    public bool TaskCompleted = false;


    public void TaskCompleteTrue()
    {
        TaskCompleted = true;
    }


}
