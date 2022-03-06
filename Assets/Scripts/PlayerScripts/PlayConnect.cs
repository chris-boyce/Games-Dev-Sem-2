using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayConnect : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject split;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private Transform player1Spawn;
    [SerializeField] private Transform player2Spawn;
    public GameObject[] Players;
    private int Connected;

    private bool inGame = false;

    void Update()
    {
        if (inGame == false)
        {
            if (PlayerCountID.playerID == 1)
            {
                player1.SetActive(true);
            }
            else if (PlayerCountID.playerID == 2)
            {
                player2.SetActive(true);
                StartCoroutine(StartMenu());
            }
        }

    }
    IEnumerator StartMenu()
    {
        yield return new WaitForSeconds(5f);
        background.SetActive(false);
        split.SetActive(true);
        inGame = true;
    }


    public void PlayerJoined()
    {
        Connected++;
        if(Connected == 1)
        {
            Players = GameObject.FindGameObjectsWithTag("Player");
            Players[0].transform.position = player1Spawn.position;
            Players[0].transform.parent.tag = "Player1";
        }

        if(Connected == 2)
        {
            Players = GameObject.FindGameObjectsWithTag("Player");
            Players[1].transform.position = player2Spawn.position;
            Players[1].transform.parent.tag = "Player2";

        }


    }
}
