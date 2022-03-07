using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScreenShotScript : MonoBehaviour
{
    public RenderTexture renderTexture;
    public void OnScreenShot()
    {
        Debug.Log("ScreenShot");
        ScreenCapture.CaptureScreenshot("Screenshot.png" , 4);
        
    }
}
