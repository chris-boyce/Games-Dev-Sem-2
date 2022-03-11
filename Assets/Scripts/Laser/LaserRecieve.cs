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
        if(isEnd == true && beenHit == false)
        {
            GetComponent<TaskFinished>().TaskCompleted = true;
            GetComponent<MeshRenderer>().material = Resources.Load("GreenFin", typeof(Material)) as Material;
            LightTriggered.Invoke();
        }
        beenHit = true;
    }
    public void StopBeening()
    {
        if (isEnd == true && beenHit == true)
        {
            Debug.Log("Yes Sir");
            GetComponent<TaskFinished>().TaskCompleted = false;
            GetComponent<MeshRenderer>().material = Resources.Load("RedFin", typeof(Material)) as Material;
            LightTriggeredStop.Invoke();
        }
        beenHit = false;

    }
}
