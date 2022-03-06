using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    //Changes Colors of Lights. Called Through Unity Event System
    private Light Light;

    private void Start()
    {
        Light = GetComponent<Light>();
    }
    public void TurnGreen()
    {
        Light.color = Color.green;
    }
    public void TurnRed()
    {
        Light.color = Color.red;
    }

}
