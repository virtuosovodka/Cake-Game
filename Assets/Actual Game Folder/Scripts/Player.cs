using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class Player : MonoBehaviour
{
    GameObject currentObject;
    //Rigidbody rb;

    public TextMeshProUGUI debug;

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
    public bool ovenDoorHit;

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

    //level 1 button prompts
    public GameObject StartBeltPrompt;
    public GameObject BatterPrompt;
    public GameObject OvenDoorPrompt;
    public GameObject OvenOnPrompt;
    public GameObject OvenLightPrompt;
    public GameObject OvenOffPrompt;
    public GameObject FrostingPrompt;
    //toppings
    public GameObject SaucePrompt;
    public GameObject SprinklesPrompt;
    public GameObject CherriesPrompt;

    public GameObject vanillaBatter;
    public GameObject cakeTin;

    //TODO: make separate scene for color blind mode
    //TODO: make tags for individual flavors i.e. chocolate batter, vanilla batter, strawberry batter, green frosting etc. (and color blind version)

    /*        //if (other.gameObject.CompareTag("StartBelt"))
        //{
            if (OVRInput.GetDown(OVRInput.RawButton.X))
            {
                text.text = "X pressed!";
            }
            else if (OVRInput.GetDown(OVRInput.RawButton.Y))
            {
                text.text = "Y pressed!";
            }
            else if (OVRInput.GetDown(OVRInput.Button.One))
            {
                text.text = "A pressed!";
            }
            else if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                text.text = "B pressed!";
            }
            else if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
            {
                text.text = "Left Index Trigger Pressed!";
            }
            else if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
            {
                text.text = "Right Index Trigger Pressed!";
            }
            else if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger)) //left hand trigger
            {
                text.text = "Left Hand Trigger Pressed!";
            }
            else if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger)) //right hand trigger
            {
                text.text = "Right Hand Trigger Pressed!";
            }
        //}*/



    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        //delete the material changer in the player inspector
        //materialChanger = GetComponent<MaterialChanger>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentObject = null;

        Light.SetActive(false);

        materialChanger.changeMaterial = false;
        backButtonMesh = backButton.GetComponent<MeshRenderer>();

        playPause.SetActive(false);
        backButton.SetActive(false);
        Ipad ipad = gameObject.GetComponent<Ipad>();

        //button press prompts
        StartBeltPrompt.SetActive(false);
        BatterPrompt.SetActive(false);
        OvenDoorPrompt.SetActive(false);
        OvenOnPrompt.SetActive(false);
        OvenLightPrompt.SetActive(false);
        OvenOffPrompt.SetActive(false);
        FrostingPrompt.SetActive(false);
        SaucePrompt.SetActive(false);
        SprinklesPrompt.SetActive(false);
        CherriesPrompt.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        OVRInput.Update();
        if (currentObject != null)
        {
            debug.text = currentObject.name;
            print(currentObject.name);
        }
        
        
        if (ovenOn)
        {
            timeInOven += Time.deltaTime;

            //debug.text = "time in oven is " + timeInOven;

            if (timeInOven <= cookTime - 1)
            {
                //debug.text = "raw";
                //run not baked animation
            }

            if (timeInOven >= cookTime - 1 && timeInOven <= cookTime + 2)
            {
               // debug.text = "cooked";
                // run cooked animation
            }

            if (timeInOven >= cookTime + 2)
            {
               // debug.text = "overcooked";
                // run overbaked animation
            }

            if (timeInOven >= cookTime + 4)
            {
               // debug.text = "on fire";
                // run fire animation
            }
        }

        //press
        if (OVRInput.GetDown(OVRInput.Button.One) && currentObject.CompareTag("StartBelt"))
        {
            Belt();

            //batter button is on collision && while B or Y button is down
        }

        //TODO: delete?
        //press
        if (OVRInput.GetDown(OVRInput.Button.One) && currentObject.CompareTag("StopBelt"))
        {
            BeltOff();
        }

        //press and hold
        if (OVRInput.Get(OVRInput.Button.One) && currentObject.CompareTag("VanillaBatterButton"))
        {
            VanillaBatter();

            //batter button is on collision && while B or Y button is down
        }

        //TODO @Vedika, you will need to fully implement this, it will not be implemented outside VR.
        //press hold and drag- only in certain dimensions, add in and/or for door in/ door out
        //can open door only when oven is off
        if (Input.GetKey(KeyCode.Mouse0) && currentObject.CompareTag("OvenDoor")) //&& !ovenOn)
        {
            //debug.text = "oven door";
            //hold and drag to reset door position.can't go past certain coordinates
            //door must be closed to turn oven on oven must be off to open door

            //on collision && grab bottom and y/b and hand turned 90
        }

        //press
        //start oven function
        if (OVRInput.GetDown(OVRInput.Button.One) && currentObject.CompareTag("OvenOn"))
        {
            OvenOn();
            // on collision and B or Y

        }


        if (OVRInput.GetDown(OVRInput.Button.One) && currentObject.CompareTag("OvenLight"))
        {
            OvenLight();
            // on collision and B or Y
        }

        //press
        //stop oven function
        if (OVRInput.GetDown(OVRInput.Button.One) && currentObject.CompareTag("OvenOff"))
        {
            OvenOff();
            // on collision and B or Y
        }

        //press hold and drag
        if (OVRInput.Get(OVRInput.Button.One) && currentObject.CompareTag("FrostingButton")) //&& !frostingOn)
        {
            Frosting();
            //on collision and front button to hold/ move both bottoms to get frosting out
        }

        //press hold and drag
        if (OVRInput.Get(OVRInput.Button.One) && currentObject.CompareTag("ToppingButton")) //&& !toppingOn)
        {
            Topping();
            // sauce on collision and front button to hold/ move both bottoms to get topping out same as frosting
            // sprinklies on collision flipped 180, will make a range~ 120-240? and shaken- Y value changes by x or more
            // cherries on collision front button && y/b to pick it up
        }

        //BUTTON INSTRUCTIONS FOR LEVEL 1 *ONLY*
        if (OVRInput.Get(OVRInput.Button.One) && currentObject.gameObject.CompareTag("BatterButton")) //&& in level 1
        {
            BatterPrompt.SetActive(true);
        }

        if (OVRInput.Get(OVRInput.Button.One) && currentObject.gameObject.CompareTag("OvenDoor"))//&& in level 1
        {
            OvenDoorPrompt.SetActive(true);
        }

        if (OVRInput.Get(OVRInput.Button.One) && currentObject.gameObject.CompareTag("OvenOn"))//&& in level 1
        {
            OvenOnPrompt.SetActive(true);
        }

        if (OVRInput.Get(OVRInput.Button.One) && currentObject.gameObject.CompareTag("OvenLight"))//&& in level 1
        {
            OvenLightPrompt.SetActive(true);
        }

        if (OVRInput.Get(OVRInput.Button.One) && currentObject.gameObject.CompareTag("OvenOff"))//&& in level 1
        {
            OvenOffPrompt.SetActive(true);
        }

        if (OVRInput.Get(OVRInput.Button.One) && currentObject.gameObject.CompareTag("FrostingButton"))//&& in level 1
        {
            FrostingPrompt.SetActive(true);
        }

        if (OVRInput.Get(OVRInput.Button.One) && currentObject.gameObject.CompareTag("Sauce"))//&& in level 1
        {
            SaucePrompt.SetActive(true);
        }

        if (OVRInput.Get(OVRInput.Button.One) && currentObject.gameObject.CompareTag("Sprinkles"))//&& in level 1
        {
            SprinklesPrompt.SetActive(true);
        }
        if (OVRInput.Get(OVRInput.Button.One) && currentObject.gameObject.CompareTag("Cherries"))//&& in level 1
        {
            CherriesPrompt.SetActive(true);
        }

        //IPAD MAGIC
        if (OVRInput.Get(OVRInput.Button.One) && currentObject.CompareTag("PlayButton"))
        {
            //write a public function and reference it in the ipad script, use this to say videoPlayer.clip = videoClips[0]; etc.
            //or tag he player "player
            //debug.text = "paused";
            
            ipad.PlayPause(videoClips[0]);
            materialChanger.changeMaterialMovie = true;
            backButton.SetActive(true);
            playPause.SetActive(true);
            playVideo2.SetActive(false);
            playVideo1.SetActive(false);

            //playVideo1.transform.position += new Vector3(0, 0, 2)*Time.deltaTime;
            //playPause.transform.position += new Vector3(0, 0, -2)*Time.deltaTime;
        }

        if (OVRInput.Get(OVRInput.Button.One) && currentObject.CompareTag("PlayButton2"))
        {
            //debug.text = "paused";
            ipad.PlayPause(videoClips[1]);
            materialChanger.changeMaterialMovie = true;
            backButton.SetActive(true);
            playPause.SetActive(true);
            playVideo1.SetActive(false);
            playVideo2.SetActive(false);
            //backButton.transform.position -= new Vector3(0, 0,10);
        }

        if (OVRInput.Get(OVRInput.Button.One) && currentObject.CompareTag("BackButton"))
        {
            //debug.text = "back to home screen";
            
            materialChanger.changeMaterialMovie = false;
            materialChanger.changeMaterial = true;
            playPause.SetActive(false);
            playVideo2.SetActive(true);
            playVideo1.SetActive(true);
            backButton.SetActive(false);
        }

        if (currentObject.CompareTag("playPause"))
        {
            //ipad.PlayPause();
            //work on fixing this next class
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if the player collides with the cherry container then the cherry instatiates and count them too see if yu have the right amount
    }

    private void OnTriggerEnter(Collider other)
    {
        currentObject = other.gameObject;
        ///debug.text = "on " + currentObject.name;
    }

    private void OnTriggerExit(Collider other)
    {
        currentObject = null;
        //debug.text = "off " + currentObject.name;
    }

    void Belt()
    {
        //debug.text = "Belt on";
        beltOn = true;
    }

    void BeltOff()
    {
        print("Belt Off");
        beltOn = false;
    }

    void VanillaBatter()
    {
        debug.text = "batter pouring";
        Instantiate(vanillaBatter, cakeTin.transform.position, cakeTin.transform.rotation);
        batterAmount += batterPerFrame * Time.deltaTime;
        //batter amount = amount per frame* time that button down
        //save batter amount even after function is stopped being called
        //set batter amount= amount per frame*time.delta time
        //saved value

        batterOn = true;
        //debug.text = "you poured " + batterAmount;
    }

    void OvenLight()
    {
        lightOn = !lightOn;
        Light.SetActive(lightOn);
    }

    //make a light button for oven 
    void OvenOn()
    {
        debug.text = "oven on";
        cookTime = cookTimePerOunce * batterAmount;
        //debug.text = "your cook time is " + cookTime;

        ovenOn = true;

        //set cook time based on batter amount
        //on start of function begin baking animation (timer) based on cook time 3 sec before raw, 3 sec after overcooked, 5 sec after on fire
    }

    void OvenOff()
    {
        debug.text = "Oven off";
        ovenOn = false;
    }

    void Frosting()
    {
        //debug.text = "frosting";
        frostingOn = true;
    }

    void Topping()
    {
        if (currentObject.CompareTag("Liquid")) //&& press and hold (just like frosting just more liquidy))
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
