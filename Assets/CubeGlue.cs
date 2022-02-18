using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGlue : MonoBehaviour
{
    [SerializeField] Transform cube;

    void Update()
    {
        transform.position = cube.transform.position;
        transform.rotation = cube.transform.rotation;
    }
}
