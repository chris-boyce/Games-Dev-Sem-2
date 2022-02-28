using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserOrigin : MonoBehaviour
{
    /*
    //[SerializeField] private Transform laserPos;
    private LineRenderer thisLR;
    private GameObject Hidden;
    private GameObject lastLaser;
    private GameObject lastCube;
    public bool canShoot = false;
    private GameObject lineHolder;
    private Material laserMat;

    private void Awake()
    {
       

    }
    void Update()
    {
        if (canShoot) // Checking If Allowed to be active
        {
            Ray ray = new Ray(transform.position, transform.forward); //Make Laser and sets it to shoot forward from origin
            thisLR.SetPosition(0, transform.position);
            thisLR.SetPosition(1, ray.GetPoint(20f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) //If Raycast Hits Something
            {
                thisLR.SetPosition(1, hit.point); // Set the LR to the point to collision
                if (hit.collider.tag == "Reflector") //If it is a reflector activate the exits laser
                {
                    lastLaser = hit.collider.gameObject;
                    hit.collider.GetComponent<HitByLaser>().beenHit = true;
                }
                else if(hit.collider.tag == "LaserEnd")
                {
                    hit.collider.GetComponent<LaserEnd>().CubeActivate();
                    lastCube = hit.collider.gameObject;
                }
                else if (hit.collider.tag != "LaserEnd")
                {
                    if (lastCube != null)
                    {
                        lastCube.GetComponent<LaserEnd>().CubeDeactivate();
                    }
                }
                else if (hit.collider.tag != "Reflector") // If its not the reflector set the laser last hit to turn off
                {
                    if (lastLaser != null)
                    {
                        lastLaser.GetComponent<HitByLaser>().beenHit = false;
                    }
                }
            }
            else // If not hitting anything turn the last laser hit off
            {
                if (lastLaser != null)
                {
                    lastLaser.GetComponent<HitByLaser>().beenHit = false;
                }
                
            }

            
        }
        else //If not shooting turn the last laser hit off
        {
            if (lastLaser != null)
            {
                lastLaser.GetComponent<HitByLaser>().beenHit = false;
            }
            thisLR.SetPosition(0, Hidden.transform.position);
            thisLR.SetPosition(1, Hidden.transform.position);
        }

    }
     */
}
