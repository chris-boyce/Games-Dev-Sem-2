using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LeverSwitch : MonoBehaviour
{
    [Header("When Happens When Pulled / On and Off")]
    public UnityEvent LeverTriggered;
    public UnityEvent LeverOff;

    //Lever Varaibles 
    public List<GameObject> Levers;
    private bool LeverState;

    void Start() //Sets List to the 2 Lever States on or off
    {
        foreach (Transform child in transform)
        {
            Levers.Add(child.gameObject);
        }
        //Turns off on
        Levers[1].SetActive(false);
    }
    public void FlipSwitch()
    {
        LeverState = !LeverState;
        if(LeverState == false) // What happens when off
        {
            //Add UE For When off
            Levers[1].SetActive(false);
            Levers[0].SetActive(true);
            LeverOff.Invoke();

        }
        if (LeverState == true)//Wjat happens when on
        {
            LeverTriggered.Invoke();
            Levers[1].SetActive(true);
            Levers[0].SetActive(false);
        }

    }

    
}
