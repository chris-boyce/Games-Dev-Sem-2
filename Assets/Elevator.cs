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
    public GameObject SummaryImage;
    private float fillAmount;
    private TimerScript ts;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        canvas.SetActive(false);
        bg.SetActive(false);
        SummaryImage.SetActive(false);
        ts = GameObject.Find("Timer").GetComponent<TimerScript>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
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
        if(playerCount >= 4)
        {
            ts.StopTimer();
            player1 = GameObject.FindGameObjectWithTag("Player1");
            player2 = GameObject.FindGameObjectWithTag("Player2");
            rb.AddForce(transform.up * 20);
            StartCoroutine(EndLevel());
            canvas.SetActive(true);

        }
    }
    IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(1f);
        bg.SetActive(true);
        fillAmount = fillAmount + Time.deltaTime;
        bg.GetComponent<Image>().fillAmount = fillAmount;
        if(fillAmount > 1)
        {
            StartCoroutine(Summary());
        }
        
    }
    IEnumerator Summary()
    {
        SummaryImage.SetActive(true);
        yield return new WaitForSeconds(10f);
        
    }

}
