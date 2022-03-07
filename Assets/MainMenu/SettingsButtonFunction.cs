using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButtonFunction : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject SettingsCanvas;
    void Update()
    {
        if (this.gameObject.GetComponent<ButtonHighlight>().isActivated == true)
        {
            canvas.SetActive(false);
            SettingsCanvas.SetActive(true);
            this.gameObject.GetComponent<ButtonHighlight>().isActivated = false;
        }
        
    }
}
