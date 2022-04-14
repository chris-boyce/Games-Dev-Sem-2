using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadScript : MonoBehaviour
{
    //private Camera playerCam;
    public Transform player1ScreenPos;
    public Transform player2ScreenPos;
    public GameObject page;
    public Transform CurrentPlayer;
    //private bool player1Open;
   // private bool player2Open;
    private bool isOpen;
    private float PageAnim;
    private void Start()
    {
        isOpen = false;
        page.GetComponent<Image>().fillAmount = 0;
    }
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
        CurrentPlayer = player.transform.GetChild(0);
        isOpen = !isOpen;

    }
    private void Update()
    {
        if(isOpen && Vector3.Distance(CurrentPlayer.position, transform.position) > 3f)
        {
            Debug.Log(CurrentPlayer.gameObject.name);
            isOpen = false;
        }

        PageAnim = Mathf.Clamp(PageAnim, 0, 1);
        if(isOpen)
        {
            if (PageAnim <= 1f) 
            {
                PageAnim = PageAnim + Time.deltaTime * 3;
            }

            page.GetComponent<Image>().fillAmount = PageAnim;
            page.SetActive(true);

        }
        else
        {
            if (PageAnim >= 0f)
            {
                PageAnim = PageAnim - Time.deltaTime * 3;
            }
            page.GetComponent<Image>().fillAmount = PageAnim;
            if(PageAnim < 0)
            {
                page.SetActive(false);
            }
        }
        
    }

}
