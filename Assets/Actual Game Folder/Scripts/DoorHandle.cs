using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorHandle : MonoBehaviour
{
    //create a batterAmount that increments whenever there is batter is being added
    //add in a boolean that batteramount is no zero
    public Player leftHand;
    public Player rightHand;
    public GameManager gm;
    public GameObject frontHandle;
    public GameObject backHandle;
    public GameObject frontDoorStop;
    public GameObject backDoorStop;
    public TextMeshProUGUI debug;
    bool up = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        gm.debug.text = "" + up;

        if (gm != null)
        {
            if (gm.ovenDoorHit && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
            {
                if (!up)
                {
                    frontHandle.transform.Translate(Time.deltaTime * 25, 0, 0);
                    backHandle.transform.Translate(Time.deltaTime * 25, 0, 0);
                    up = true;
                }
                else if (up)
                {
                    frontHandle.transform.Translate(Time.deltaTime * -25, 0, 0);
                    backHandle.transform.Translate(Time.deltaTime * -25, 0, 0);
                    up = false;
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
