using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FramerateCounter : MonoBehaviour
{
    public int FrameRate;
    public Text FrameRateText;
    public int TargetFrameRate;

    private void Start()
    {
        Application.targetFrameRate = TargetFrameRate;
    }
    void Update()
    {
        FrameRate = (int)(1f / Time.unscaledDeltaTime);
        FrameRateText.text = FrameRate.ToString();


    }
}
