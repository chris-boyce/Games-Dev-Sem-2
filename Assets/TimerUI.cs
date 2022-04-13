using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    private TimerScript ts;
    private void Start()
    {
        ts = GameObject.Find("Timer").GetComponent<TimerScript>();
    }
    private void Update()
    {
        Text textObject = GetComponent<Text>();
        textObject.text = ts.Timer.ToString("F2");
    }

}
