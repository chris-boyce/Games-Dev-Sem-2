using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    void Update()
    {
        if (this.gameObject.GetComponent<ButtonHighlight>().isActivated == true)
        {
            Application.Quit();
        }
    }
}
