using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScreenShotScript : MonoBehaviour
{
    public void OnScreenShot()
    {
        Debug.Log(gameObject.name);
        Debug.Log("ScreenShot");
        ScreenCapture.CaptureScreenshot("Screenshot.png" , 4);
        
    }
}
