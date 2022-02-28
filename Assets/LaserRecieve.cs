using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRecieve : MonoBehaviour
{
    [SerializeField] private GameObject ExitLaser;
    private bool beenHit;
    [SerializeField] private bool isEnd;
    public bool finishedTask;
    private void Start()
    {

    }

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
            finishedTask = true;
        }
    }
    public void StopBeening()
    {
        beenHit = false;
    }
}
