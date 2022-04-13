using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFire : MonoBehaviour
{
    /// <summary>
    /// Need To Add Reset on be hit / been hit running every frame atm
    /// </summary>
    [Header("If this is the Start of the Laser Beam")]
    [SerializeField] private bool MasterOrigin;

    //Line Renderer Making / Variables
    private LineRenderer LaserRenderer;
    private GameObject lineHolder;
    private Material laserMat;
    private GameObject Hidden;
    public bool canFire;

    //Object Hit 
    private GameObject lastObjectHit;

    void Start() //Making Linerenders When the Game Starts (Lots Needed)
    {
        canFire = false;
        lineHolder = new GameObject();
        LaserRenderer = lineHolder.AddComponent<LineRenderer>();
        laserMat = Resources.Load("LaserMaterial", typeof(Material)) as Material;
        LaserRenderer.material = laserMat;
        Hidden = GameObject.Find("Hidden");
    }
    private void OnDisable()
    {
        lineHolder.SetActive(false);
    }

    void FixedUpdate()
    {
        if(canFire || MasterOrigin) //If Red = Canfire or is the Origin Laser
        {
            Ray ray = new Ray(transform.position, transform.forward); //Makes Laser that goes Straight
            LaserRenderer.SetPosition(0, transform.position);
            LaserRenderer.SetPosition(1, ray.GetPoint(20f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit , 20)) // If Hits an object within 20m
            {
                LaserRenderer.SetPosition(1, hit.point); //Make Laser go to where hit
                if(hit.collider.tag == "Reflector") //If the laser hits the a reflector entry (Green)
                {
                    lastObjectHit = hit.collider.gameObject; //Sets Last Object Hit
                    hit.collider.GetComponent<LaserRecieve>().BeenHit(); //Start the process of been hit on the object hit (Green)
                }
                else //If not hitting a green
                {
                    if (lastObjectHit != null) //Last object isnt null
                    {
                        lastObjectHit.GetComponent<LaserRecieve>().StopBeening(); //Stop the last laser firing
                    }
                }
            }
            else //If raycast doesnt hit anything
            {
                if (lastObjectHit != null) //Stop the last laser firing 
                {
                    lastObjectHit.GetComponent<LaserRecieve>().StopBeening();
                }
            }
         
        }
        else //if can fire = false
        {
            LaserRenderer.SetPosition(0, Hidden.transform.position);//hide the lasers
            LaserRenderer.SetPosition(1, Hidden.transform.position);
            if (lastObjectHit != null)
            {
                lastObjectHit.GetComponent<LaserRecieve>().StopBeening(); //Stop the last laser firing
            }
        }
        
    }
}
