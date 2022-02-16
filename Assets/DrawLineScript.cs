using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DrawLineScript : MonoBehaviour
{

    public SteamVR_Action_Boolean drawLineAction;
    public SteamVR_Input_Sources handType;

    public LineRenderer lineRenderer;

    public Transform rightHand;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        Debug.Log("??????");

        drawLineAction.AddOnStateDownListener(TriggerDown, handType);
        drawLineAction.AddOnStateUpListener(TriggerUp, handType);

    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is up");
        lineRenderer.enabled = false;
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is down");
        lineRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 start = rightHand.position;
        Vector3 end = rightHand.position + rightHand.forward * 100;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}
