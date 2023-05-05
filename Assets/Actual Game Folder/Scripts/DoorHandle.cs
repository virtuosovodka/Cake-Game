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
    public int speed;
    bool up = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        if (gm != null)
        {
            if (up == false && gm.ovenDoorHit && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger)) 
            {
                frontHandle.transform.Translate(Time.deltaTime * 25, 0, 0);
                backHandle.transform.Translate(Time.deltaTime * 25, 0, 0);
                up = true;
            }
            else if (up == true && gm.ovenDoorHit && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
            {
                frontHandle.transform.Translate(Time.deltaTime * -25, 0, 0);
                backHandle.transform.Translate(Time.deltaTime * -25, 0, 0);
                up = false;
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
