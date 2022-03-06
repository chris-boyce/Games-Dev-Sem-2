using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserRecieve : MonoBehaviour
{
    [Header("Exit Laser Gameobject")]
    [SerializeField] private GameObject ExitLaser;

    [Header("If End Of Level Obj / Variables Needed")]
    [SerializeField] private GameObject LevelController;
    [SerializeField] private bool isEnd;

    public UnityEvent LightTriggered;
    public UnityEvent LightTriggeredStop;

    private bool beenHit;

    void FixedUpdate()
    {
        if(beenHit && !isEnd)
        {
            ExitLaser.GetComponent<LaserFire>().canFire = true; // Shoot Laser
        }
        else
        {
            ExitLaser.GetComponent<LaserFire>().canFire = false; // Shoot Laser
        }
    }
    public void BeenHit()
    {
        beenHit = true;
        if(isEnd == true)
        {
            GetComponent<TaskFinished>().TaskCompleted = true;
            GetComponent<MeshRenderer>().material = Resources.Load("GreenFin", typeof(Material)) as Material;
            LightTriggered.Invoke();
        }
    }
    public void StopBeening()
    {
        Debug.Log("Yes Sir");
        beenHit = false;
        if (isEnd == true)
        {
            GetComponent<TaskFinished>().TaskCompleted = false;
            GetComponent<MeshRenderer>().material = Resources.Load("RedFin", typeof(Material)) as Material;
            LightTriggeredStop.Invoke();
        }
        
    }
}
