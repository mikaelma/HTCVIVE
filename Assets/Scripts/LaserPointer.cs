using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class LaserPointer : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean teleportAction;
    public SteamVR_Action_Boolean showLaserAction;

    public GameObject laserPrefab; // 1
    private GameObject laser; // 2
    private Transform laserTransform; // 3
    private Vector3 hitPoint; // 4
    private Renderer laserRenderer;

    private bool laserActive;

    // Start is called before the first frame update
    void Start()
    {
        // 1
        laser = Instantiate(laserPrefab);
        // 2
        laserTransform = laser.transform;
        laserRenderer = laser.GetComponent<Renderer>();
        laserActive = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (showLaserAction.GetStateDown(handType))
        {
            laserActive = true;
        }
        else if (showLaserAction.GetStateUp(handType))
        {
            laserActive = false;
        }

        if (laserActive)
        { 
            RaycastHit hit;

            laser.SetActive(true);

            laserTransform.position = controllerPose.transform.position;
            laserTransform.rotation = controllerPose.transform.rotation;

            if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100))
            {
                if (hit.collider.gameObject.tag == "Interactable")
                {
                    laserRenderer.material.color = Color.green;
                    if (teleportAction.GetStateDown(handType))
                    {
                        hit.collider.gameObject.GetComponent<DetectHit>().ChangeColor();
                        hitPoint = hit.point;
                        ShowLaser(hit);
                    }
                }
                else
                {
                    laserRenderer.material.color = Color.red;
                }
            }
            else
            {
                laserRenderer.material.color = Color.red;
                laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y, 100f);
            }
        }else
        {
            laser.SetActive(false);
        }

        
    }
    private void ShowLaser(RaycastHit hit)
    {
     
        // 2
        Debug.Log("Position: " + controllerPose.transform.position);
        laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, .5f);
        // 3
        laserTransform.LookAt(hitPoint);
        // 4
        laserTransform.localScale = new Vector3(laserTransform.localScale.x,
                                                laserTransform.localScale.y,
                                                hit.distance);
    }

}
