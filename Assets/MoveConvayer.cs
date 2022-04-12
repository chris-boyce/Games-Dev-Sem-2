using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveConvayer : MonoBehaviour
{
    public Transform EndPos;
    public bool isOn;
    private void OnCollisionStay(Collision collision)
    {
        if (isOn)
        {
            if (collision.gameObject.tag == "Interactable")
            {
                collision.gameObject.transform.position = Vector3.MoveTowards(collision.gameObject.transform.position, EndPos.position, Time.deltaTime);
            }
        }
    }
    public void toggleActivation()
    {
        isOn = !isOn;
    }

}
