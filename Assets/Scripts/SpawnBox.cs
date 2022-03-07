using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    [Header("What Object to Spawn in")]
    [SerializeField] public GameObject SpawnedObject;
    [Header("Number of Cubes to spawn before replacing them")]
    [SerializeField] private int NumberOfCubes;

    //Need to Check Player Hands When deleted
    private GameObject player;
    private GameObject player2;

    //Stores all the cubes in a array
    private GameObject[] currentCube;

    //Counts the cube to know which one to delete and what order they spawned in :)
    private int counter = 0;

    private void Start()
    {
        //Makes array the length of the amount of cubes need
        currentCube = new GameObject[NumberOfCubes];
        
    }
    public void SpawnObject()
    {
        if (currentCube[counter] != null) //If the cube beening spawn is taking the place of a cube on the list
        {
            player = GameObject.FindGameObjectWithTag("Player1"); //Finds Players
            player2 = GameObject.FindGameObjectWithTag("Player2");
            if (currentCube[counter] == player.GetComponent<InteractWithObject>().CheckHand()) // Checks had and destroys the cube they are holding to make sure no errors
            {
                    player.GetComponent<InteractWithObject>().DestroyCube();

            }
            if (player2 != null)
            {
                if (player2.GetComponent<InteractWithObject>().CheckHand() != null) // Added Code so when debugging with 1 player there are no errors
                {
                    if (currentCube[counter] == player2.GetComponent<InteractWithObject>().CheckHand())
                    {
                        player2.GetComponent<InteractWithObject>().DestroyCube();

                    }
                }
            }
        }
        Destroy(currentCube[counter]); //Emptys the spot on the list
        currentCube[counter] = Instantiate(SpawnedObject, transform.position, Quaternion.identity); // Makes new cube
        counter++; //Goes to next option on list
        if(counter == NumberOfCubes)//Resets it when it gets to bettom of list
        {
            counter = 0;
        }


    }

}
