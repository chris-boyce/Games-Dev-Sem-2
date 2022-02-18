using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadScript : MonoBehaviour
{
    private Camera playerCam;
    public Transform player1ScreenPos;
    public Transform player2ScreenPos;
    public GameObject page;
    private bool player1Open;
    private bool player2Open;
    public void objectInteract(GameObject player , int m_PlayerID)
    {
           if (m_PlayerID == 1)
           {
              page.transform.position = player1ScreenPos.position;
           }
           if (m_PlayerID == 2)
           {
                page.transform.position = player2ScreenPos.position;
  
           }
        page.SetActive(!page.activeInHierarchy);

    }

}
