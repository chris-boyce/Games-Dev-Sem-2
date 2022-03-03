using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRecieve : MonoBehaviour
{
    [Header("Exit Laser Gameobject")]
    [SerializeField] private GameObject ExitLaser;

    [Header("If End Of Level Obj / Variables Needed")]
    [SerializeField] private GameObject LevelController;
    [SerializeField] private bool isEnd;

    private bool beenHit;
    private bool finishedTask;

    void FixedUpdate()
    {
        if(beenHit && !isEnd)
        {
            ExitLaser.GetComponent<LaserFire>().FireLaser(); // Shoot Laser
        }
        else
        {
            ExitLaser.GetComponent<LaserFire>().StopLaser(); // Shoot Laser
        }
    }
    public void BeenHit()
    {
        beenHit = true;
        if(isEnd == true)
        {
            LevelController.GetComponent<TaskFinished>().TaskCompleted = true;
        }
    }
    public void StopBeening()
    {
        beenHit = false;
    }
}
