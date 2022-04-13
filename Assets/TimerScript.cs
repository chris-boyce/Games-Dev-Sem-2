using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    private bool isTimer;
    public float Timer;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void StartTimer()
    {
        isTimer = true;
    }
    void StopTimer()
    {
        isTimer = false;
    }
    private void Update()
    {
        if(isTimer)
        {
            Timer = Timer + Time.deltaTime;
        }
    }

}
