using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayFunction : MonoBehaviour
{
    void Update()
    {
        if(this.gameObject.GetComponent<ButtonHighlight>().isActivated == true)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
