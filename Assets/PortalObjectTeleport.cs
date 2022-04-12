using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObjectTeleport : MonoBehaviour
{
    public GameObject ExitPortal;
    private void OnCollisionEnter(Collision collision)
    {


            if (collision.gameObject.tag == "Interactable")
            {
                collision.transform.position = ExitPortal.transform.position;

            }

    }

}
