using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInVR : MonoBehaviour
{
    //parent door hinge to controller and have it go with controller until it reaches 90 degrees rotation and stop it for rotating (use getrotation to work) 

    public Rigidbody rb;

    public GameObject belt2;
    public GameObject beltbutton;
    //public GameObject belt3;
    //public GameObject counter;
    GameObject currentObject;

    public bool beltOn = false;
    //public bool batterOn = false;
    public bool ovenOn = false;
    public bool frostingOn = false;

    //public float moveSpeed = 2;
    //public bool moveX = true;
    //bool moveZ = true;
    //bool moveNegX = true;

    //public float batterPerFrame;
    //float batterAmount;

    float cookTime;
    public float cookTimePerOunce;
    float timeInOven;
    public TextMeshProUGUI text;

    public Vector3 degreesToRotate; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentObject = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (beltOn)
        {
            belt2.transform.Rotate(Time.deltaTime * degreesToRotate);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Belt section
        if (other.gameObject.CompareTag("StartBelt"))
        {
            if (OVRInput.GetDown(OVRInput.RawButton.X)) //X turns on belt
            {
                Belt();
            }

            if (OVRInput.GetUp(OVRInput.RawButton.X))
            {
                BeltOff();
            }
        }

        //Frosting section
        if (other.gameObject.CompareTag("FrostingButton"))
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger)) //Right hand trigger squeezes out frosting
            {
                Frosting();
            }

            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            {
                FrostingOff();
            }
        }

        //Oven section
        if (other.gameObject.CompareTag("OvenOn"))
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                Oven();
            }

            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)) 
            {
                OvenOff();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            BeltOff();
        }
    }

    void Belt()
    {
        
        text.text = "Belt has started! (X Pressed)";
        beltOn = true;
    }

    void BeltOff()
    {
        text.text = "Belt has stopped! (X Released)";
        beltOn = false;
    }

    void Frosting()
    {
        text.text = "Frosting is being used! (Left Hand Trigger Pressed)";
        frostingOn = true;
    }

    void FrostingOff()
    {
        text.text = "Frosting has stopped coming off! (Left Hand Trigger Released)";
        frostingOn = false;
    }

    void Oven()
    {
        text.text = "Oven is on! (Left Index Trigger Pressed)";
        ovenOn = true;
    }

    void OvenOff()
    {
        text.text = "Oven is off! (Left Index Trigger Released)";
        ovenOn = false;
    }
}
