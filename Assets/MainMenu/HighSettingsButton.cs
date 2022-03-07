using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighSettingsButton : MonoBehaviour
{
    public string[] names;
    private void Start()
    {
        names = QualitySettings.names;
    }
    private void Update()
    {
        
        if (this.gameObject.GetComponent<ButtonHighlight>().isActivated == true)
        {
            QualitySettings.SetQualityLevel(0, true);
            this.gameObject.GetComponent<ButtonHighlight>().isActivated = false;
        }
    }
    
}
