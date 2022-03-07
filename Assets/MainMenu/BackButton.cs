using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject SettingsCanvas;
    void Update()
    {
        if (this.gameObject.GetComponent<ButtonHighlight>().isActivated == true)
        {
            canvas.SetActive(true);
            SettingsCanvas.SetActive(false);
            this.gameObject.GetComponent<ButtonHighlight>().isActivated = false;
        }

    }
}
