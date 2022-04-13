using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elevator : MonoBehaviour
{
    private int playerCount;
    private Rigidbody rb;
    public GameObject player1;
    public GameObject player2;
    public GameObject canvas;
    public GameObject bg;
    private float fillAmount;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Hello");
            playerCount++;
        }

        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerCount--;
        }
            
    }
    private void Update()
    {
        Debug.Log(playerCount);
        if(playerCount >= 4)
        {
            player1 = GameObject.FindGameObjectWithTag("Player1");
            player2 = GameObject.FindGameObjectWithTag("Player2");
            rb.AddForce(transform.up * 20);
            StartCoroutine(EndLevel());

        }
    }
    IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(1f);
        fillAmount = fillAmount + Time.deltaTime;
        canvas.SetActive(true);
        bg.GetComponent<Image>().fillAmount = fillAmount;

    }
}
