using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorHandle : MonoBehaviour
{
    public Player leftHand;
    public Player rightHand;
    public GameManager gm;
    public GameObject frontHandle;
    public GameObject backHandle;
    public TextMeshProUGUI debug;
    bool up = false;

    // Start is called before the first frame update
    void Start()
    {
        up = false;
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        if (gm != null)
        {
            if (gm.ovenDoorHit && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
            {
                gm.debug.text = "doorhandle hit";
                if (up)
                {
                    frontHandle.transform.Translate(Time.deltaTime * -25, 0, 0);
                    backHandle.transform.Translate(Time.deltaTime * -25, 0, 0);
                    up = false;
                }

                if (!up)
                {
                    frontHandle.transform.Translate(Time.deltaTime * 25, 0, 0);
                    backHandle.transform.Translate(Time.deltaTime * 25, 0, 0);
                    up = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gm.currentObject.CompareTag("OvenDoorHandle"))
        {
            gm.ovenDoorHit = true;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        gm.ovenDoorHit = false;
    }
}
