using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    [SerializeField] private GameObject SpawnedObject;
    public void SpawnObject()
    {
        Debug.Log("Run");
        Instantiate(SpawnedObject, transform.position, Quaternion.identity);
    }

}
