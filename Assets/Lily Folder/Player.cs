using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Player : MonoBehaviour
{
    GameObject currentObject;
    Rigidbody rb;

    //stations
    public bool beltOn = false;
    public bool batterOn = false;
    public bool ovenOn = false;
    public bool frostingOn = false;

    //batter
    public float batterPerFrame;
    public float batterAmount;

    //oven
    public float cookTime;
    public float cookTimePerOunce;
    public float timeInOven;

    //light
    public GameObject Light;
    bool lightOn;
    //ipad
    public Ipad ipad;
    public GameObject playVideo1;
    public GameObject playPause;
    public VideoPlayer videoPlayer;
    public VideoClip[] videoClips;
    public MaterialChanger materialChanger;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        //delete the material changer in the player inspector
        materialChanger = GetComponent<MaterialChanger>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentObject = null;

        Light.SetActive(false);

        materialChanger.changeMaterial = false;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: @Vedika, please remove this as well, this is temp for testing without vr
        //this ONLY WORKS with a z value of zero!!!!!!!
        rb.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

        if (ovenOn)
        {
            timeInOven += Time.deltaTime;

            print("time in oven is " + timeInOven);

            if (timeInOven <= cookTime - 1)
            {
                print("raw");
                //run not baked animation
            }

            if (timeInOven >= cookTime - 1 && timeInOven <= cookTime + 2)
            {
                print("cooked");
                // run cooked animation
            }

            if (timeInOven >= cookTime + 2)
            {
                print("overcooked");
                // run overbaked animation
            }

            if (timeInOven >= cookTime + 4)
            {
                print("on fire");
                // run fire animation
            }
        }    
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if the player collides with the cherry container then the cherry instatiates and count them too see if yu have the right amount
    }

    private void OnTriggerEnter(Collider other)
    {
        currentObject = other.gameObject;
        print(currentObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        currentObject = null;
        print(currentObject.name);
    }

    //TODO: @Vedika move this to a vr function, should not appear in final game.
    void OnMouseOver()
    {
        //press
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentObject.CompareTag("StartBelt")) 
        {
            Belt();
        }

        //press
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentObject.CompareTag("StopBelt")) 
        {
            BeltOff();
        }

        //press and hold
        if (Input.GetKey(KeyCode.Mouse0) && currentObject.CompareTag("BatterButton")) 
        {
            Batter();
        }

        //TODO @Vedika, you will need to fully implement this, it will not be implemented outside VR.
        //press hold and drag- only in certain dimensions, add in and/or for door in/ door out
        //can open door only when oven is off
        if (Input.GetKey(KeyCode.Mouse0) && currentObject.CompareTag("OvenDoor")) //&& !ovenOn)
        {
            print("oven door");
            //hold and drag to reset door position.can't go past certain coordinates
            //door must be closed to turn oven on oven must be off to open door
        }

        //press
        //start oven function
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentObject.CompareTag("OvenOn") && !ovenOn)
        {
            OvenOn();
        }

        //make oven light button
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentObject.CompareTag("OvenLight") && !lightOn)
        {
            lightOn = true;
            OvenLight();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && currentObject.CompareTag("OvenLight") && lightOn)
        {
            lightOn = false;
            Light.SetActive(false);
        }

        //press
        //stop oven function
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentObject.CompareTag("OvenOff"))
        {
            OvenOff();
        }

        //press hold and drag
        if (Input.GetKey(KeyCode.Mouse0) && currentObject.CompareTag("FrostingButton")) //&& !frostingOn)
        {
            Frosting();
        }

        //press hold and drag
        if (Input.GetKey(KeyCode.Mouse0) && currentObject.CompareTag("ToppingButton")) //&& !toppingOn)
        {
            Topping();
        }

        if (currentObject.CompareTag("PlayButton"))
        {
            //write a public function and reference it in the ipad script, use this to say videoPlayer.clip = videoClips[0]; etc.
            //or tag he player "player
            //print("paused");
            ipad.PlayPause(videoClips[0]);

            //playVideo1.transform.position += new Vector3(0, 0, 2)*Time.deltaTime;
            //playPause.transform.position += new Vector3(0, 0, -2)*Time.deltaTime;
        }

        if (currentObject.CompareTag("PlayButton2"))
        {
            //print("paused");
            ipad.PlayPause(videoClips[1]);

            //ipad.SwitchingClip();
            //playVideo1.transform.position += new Vector3(0, 0, 2)*Time.deltaTime;
            //playPause.transform.position += new Vector3(0, 0, -2)*Time.deltaTime;
        }
        if (currentObject.CompareTag("BackButton"))
        {
            print("back to home screen");
            materialChanger.changeMaterial = true;

        }

    }

    void Belt()
    {
        print("Belt On");
        beltOn = true;
    }

    void BeltOff()
    {
        print("Belt Off");
        beltOn = false;
    }

    void Batter()
    {
        batterAmount += batterPerFrame * Time.deltaTime;
        //batter amount = amount per frame* time that button down
        //save batter amount even after function is stopped being called
        //set batter amount= amount per frame*time.delta time
        //saved value
        
        batterOn = true;
        print("you poured " + batterAmount);
    }

    void OvenLight()
    {
        Light.SetActive(true);
    }

    //make a light button for oven 
    void OvenOn()
    {
        cookTime = cookTimePerOunce * batterAmount;
        print("your cook time is " + cookTime);

        ovenOn = true;

        //set cook time based on batter amount
        //on start of function begin baking animation (timer) based on cook time 3 sec before raw, 3 sec after overcooked, 5 sec after on fire
    }

    void OvenOff()
    {
        print("Oven off");
        ovenOn = false;
    }

    void Frosting()
    {
        print("frosting");
        frostingOn = true;
    }

    void Topping()
    {
        if(currentObject.CompareTag("Liquid")) //&& press and hold (just like frosting just more liquidy))
        {

        }

        if (currentObject.CompareTag("Sprinkles")) //&& flipped 180 (so open bit is pointed downwards) && shaken up and down)
        {
            //sprinkles come out only when its being shaken
        }

        if (currentObject.CompareTag("Cherries")) //&& press and hold cherries, when released cherries remain in that spot/ until it hits smth)
        {

        }
    }
}