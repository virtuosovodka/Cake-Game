using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;

public class PlayerInVR : MonoBehaviour
{
    /*
    //parent door hinge to controller and have it go with controller until it reaches 90 degrees rotation and stop it for rotating (use getrotation to work) 

    GameObject currentObject;
    Rigidbody rb;

    public GameObject belt2;
    public GameObject beltbutton;

    //stations
    public bool beltOn = false;
    public bool batterOn = false;
    public bool ovenOn = false;
    public bool frostingOn = false;

    //oven
    public float cookTime;
    public float cookTimePerOunce;
    public float timeInOven;
    public Vector3 degreesToRotate;

    //batter
    public float batterPerFrame;
    public float batterAmount;

    //light
    public GameObject Light;
    bool lightOn;

    //ipad
    public Ipad ipad;
    public GameObject backButton;
    public GameObject playVideo2;
    public GameObject playVideo1;
    public GameObject playPause;
    public VideoPlayer videoPlayer;
    public VideoClip[] videoClips;
    public MaterialChanger materialChanger;
    MeshRenderer backButtonMesh;

    //tester, not to be there in final version
    public TextMeshProUGUI text;

    void Start()
    { 
        rb = GetComponent<Rigidbody>();

        currentObject = null;

        Light.SetActive(false);

        materialChanger.changeMaterial = false;
        backButtonMesh = backButton.GetComponent<MeshRenderer>();

        playPause.SetActive(false);
        backButton.SetActive(false);
    }

    void Update()
    {
        rb.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        //oven cook time
        if (ovenOn)
        {
            timeInOven += Time.deltaTime;

            if (timeInOven <= cookTime - 1)
            {
                text.text = "raw";
                //run not baked animation
            }

            if (timeInOven >= cookTime - 1 && timeInOven <= cookTime + 2)
            {
                text.text = "cooked";
                // run cooked animation
            }

            if (timeInOven >= cookTime + 2)
            {
                text.text = "overcooked";
                // run overbaked animation
            }

            if (timeInOven >= cookTime + 4)
            {
                text.text = "on fire";
                // run fire animation
            }
        }

        if (beltOn)
        {
            Belt();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        text.text = "i work";
        //batter section
        if (other.gameObject.CompareTag("BatterButton")) //make it so that button goes down
        {
            text.text = "i work";
            BatterOn();
        }

        //belt section
        if (other.gameObject.CompareTag("StartBelt")) //make it so that button goes down
        {
            if (OVRInput.GetDown(OVRInput.RawButton.X)) //X turns on belt
            {
                beltOn = true;
            }

            if (OVRInput.GetUp(OVRInput.RawButton.X))
            {
                BeltOff();
            }
        }

        //frosting section
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

        //oven section
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

        //Door Hinge: moving door with handle start here after spring break so that you can add the stupid parenting part 
        if (other.gameObject.CompareTag("Door") && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            text.text = "Door hit!";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if any button released in game, how to detect which one is released and what function to run
    }

    void Belt()
    {
        text.text = "Belt has started! (X Pressed)";
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
        text.text = timeInOven.ToString();
        ovenOn = false;
    }

    void BatterOn()
    {
        text.text = "batter pouring!";
        batterAmount += batterPerFrame * Time.deltaTime;
        batterOn = true;
    }

    void BatterOff()
    {
        text.text = batterAmount.ToString();
    }

    */
}
