using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActionsTest : MonoBehaviour
{
    public SteamVR_Input_Sources handType; // 1
    public SteamVR_Action_Boolean teleportAction; // 2
    public SteamVR_Action_Boolean grabAction; // 3
    public SteamVR_Action_Boolean showLaserAction;

    // Update is called once per frame
    void Update()
    {
        if (GetTeleport())
        {
            print("Teleport " + handType);
        }
       
        if (GetGrab())
        {
            print("Grab " + handType);
        }

        if (GetLaserActivate())
        {
            print("Laser activated " + handType);
        }
        if (GetLaserDeactivate())
        {
            print("Laser deactivated " + handType);
        }


    }

    public bool GetTeleport() // 1
    {
        return teleportAction.GetStateDown(handType);
    }
    
    public bool GetGrab() // 2
    {
        return grabAction.GetState(handType);
    }

    public bool GetLaserActivate()
    {
        return showLaserAction.GetStateDown(handType);
    }
    public bool GetLaserDeactivate()
    {
        return showLaserAction.GetStateUp(handType);
    }

}
