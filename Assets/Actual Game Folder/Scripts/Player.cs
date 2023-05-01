using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class Player : MonoBehaviour
{

    public GameManager gm;
    //light
    public GameObject Light;
    bool lightOn;

    //ipad
    //public Ipad ipad;
    public GameObject backButton;
    public GameObject playVideo0;
    public GameObject playVideo1;

    public GameObject playButton;
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
    public GameObject chocolateBatter;
    public GameObject lemonBatter;
    public GameObject cakeTin;


    //TODO: make separate scene for color blind mode
    //TODO: make tags for individual flavors i.e. chocolate batter, vanilla batter, strawberry batter, green frosting etc. (and color blind version)
    //TODO: show up to work one day and someone threw a cake at your face limited vision
    //TODO: tell sydney to make clear film on top of cake box so you can view cake

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
        //videoPlayer = GetComponent<VideoPlayer>();

        //delete the material changer in the player inspector
        //materialChanger = GetComponent<MaterialChanger>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gm.currentObject = null;

        Light.SetActive(false);

        //ipad setup
        //ipad = gameObject.GetComponent<Ipad>();
        materialChanger.meshRenderer.material = materialChanger.mats[0];
        backButtonMesh = backButton.GetComponent<MeshRenderer>();
        playButton.SetActive(false);
        backButton.SetActive(false);
        playVideo0.SetActive(true);
        playVideo1.SetActive(true);


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

        if (gm.currentObject != null)
        {
            gm.debug.text = gm.currentObject.name;
            print(gm.currentObject.name);
        }

        if (gm.ovenOn)
        {
            gm.timeInOven += Time.deltaTime;

            //debug.text = "time in oven is " + timeInOven;

            if (gm.timeInOven <= gm.cookTime - 1)
            {
                //debug.text = "raw";
                //run not baked animation
            }

            if (gm.timeInOven >= gm.cookTime - 1 && gm.timeInOven <= gm.cookTime + 2)
            {
                // debug.text = "cooked";
                // run cooked animation
            }

            if (gm.timeInOven >= gm.cookTime + 2)
            {
                // debug.text = "overcooked";
                // run overbaked animation
            }

            if (gm.timeInOven >= gm.cookTime + 4)
            {
                // debug.text = "on fire";
                // run fire animationk
            }
        }

        if (gm.currentObject.CompareTag("StartBelt") || Input.GetKeyDown(KeyCode.K))//OVRInput.GetDown(OVRInput.Button.One) && 
        {
            Belt();

            //batter button is on collision && while B or Y button is down
        }

        //TODO: delete?
        if (OVRInput.GetDown(OVRInput.Button.One) && gm.currentObject.CompareTag("StopBelt"))
        {
            BeltOff();
        }

        if (OVRInput.Get(OVRInput.Button.One) && gm.currentObject.CompareTag("VanillaBatterButton"))
        {
            VanillaBatter();

            //batter button is on collision && while B or Y button is down
        }

        if (OVRInput.Get(OVRInput.Button.One) && gm.currentObject.CompareTag("ChocolateBatterButton"))
        {
            ChocolateBatter();

            //batter button is on collision && while B or Y button is down
        }

        if (OVRInput.Get(OVRInput.Button.One) && gm.currentObject.CompareTag("LemonBatterButton"))
        {
            LemonBatter();

            //batter button is on collision && while B or Y button is down
        }

        //TODO @Vedika, you will need to fully implement this, it will not be implemented outside VR.
        //press hold and drag- only in certain dimensions, add in and/or for door in/ door out
        //can open door only when oven is off

        //start oven function
        if (OVRInput.GetDown(OVRInput.Button.One) && gm.currentObject.CompareTag("OvenOn"))
        {
            OvenOn();
            // on collision and B or Y

        }
        else if (OVRInput.GetDown(OVRInput.Button.One) && gm.currentObject.CompareTag("OvenLight"))
        {
            OvenLight();
            // on collision and B or Y
        }

        if (gm.currentObject.CompareTag("OvenDoorHandle"))
        {
            gm.ovenDoorHit = true;
        }

        //stop oven function
        if (OVRInput.GetDown(OVRInput.Button.One) && gm.currentObject.CompareTag("OvenOff"))
        {
            OvenOff();
            // on collision and B or Y
        }

        //press hold and drag
        if (OVRInput.Get(OVRInput.Button.One) && gm.currentObject.CompareTag("FrostingButton")) //&& !frostingOn)
        {
            Frosting();
            //on collision and front button to hold/ move both bottoms to get frosting out
        }

        //press hold and drag
        if (OVRInput.Get(OVRInput.Button.One) && gm.currentObject.CompareTag("ToppingButton")) //&& !toppingOn)
        {
            Topping();
            // sauce on collision and front button to hold/ move both bottoms to get topping out same as frosting
            // sprinklies on collision flipped 180, will make a range~ 120-240? and shaken- Y value changes by x or more
            // cherries on collision front button && y/b to pick it up
        }

        //BUTTON INSTRUCTIONS FOR LEVEL 1 *ONLY*
        if (OVRInput.Get(OVRInput.Button.One) && gm.currentObject.gameObject.CompareTag("BatterButton")) //&& in level 1
        {
            BatterPrompt.SetActive(true);
        }
        else if (OVRInput.Get(OVRInput.Button.One) && gm.currentObject.gameObject.CompareTag("OvenDoor"))//&& in level 1
        {
            OvenDoorPrompt.SetActive(true);
        }
        else if (OVRInput.Get(OVRInput.Button.One) && gm.currentObject.gameObject.CompareTag("OvenOn"))//&& in level 1
        {
            OvenOnPrompt.SetActive(true);
        }
        else if (OVRInput.Get(OVRInput.Button.One) && gm.currentObject.gameObject.CompareTag("OvenLight"))//&& in level 1
        {
            OvenLightPrompt.SetActive(true);
        }
        else if (OVRInput.Get(OVRInput.Button.One) && gm.currentObject.gameObject.CompareTag("OvenOff"))//&& in level 1
        {
            OvenOffPrompt.SetActive(true);
        }
        else if (OVRInput.Get(OVRInput.Button.One) && gm.currentObject.gameObject.CompareTag("FrostingButton"))//&& in level 1
        {
            FrostingPrompt.SetActive(true);
        }
        else if (OVRInput.Get(OVRInput.Button.One) && gm.currentObject.gameObject.CompareTag("Sauce"))//&& in level 1
        {
            SaucePrompt.SetActive(true);
        }
        else if (OVRInput.Get(OVRInput.Button.One) && gm.currentObject.gameObject.CompareTag("Sprinkles"))//&& in level 1
        {
            SprinklesPrompt.SetActive(true);
        }
        else if (OVRInput.Get(OVRInput.Button.One) && gm.currentObject.gameObject.CompareTag("Cherries"))//&& in level 1
        {
            CherriesPrompt.SetActive(true);
        }

        //IPAD MAGIC
        if (gm.currentObject.CompareTag("PlayVideo0") || Input.GetKeyDown(KeyCode.A)) //&& OVRInput.Get(OVRInput.Button.One))
        {
            //debug.text = "play video zero";
            //ipad.PlayPause(videoClips[0]);
            materialChanger.meshRenderer.material = materialChanger.mats[0];
            backButton.SetActive(true);
            //playButton.SetActive(true);
            playVideo0.SetActive(false);
            playVideo1.SetActive(false);
            videoPlayer.clip = videoClips[0];
            videoPlayer.Play();
            
        }

        if (gm.currentObject.CompareTag("PlayVideo1") || Input.GetKeyDown(KeyCode.S)) //&& OVRInput.Get(OVRInput.Button.One))
        {
            //debug.text = "play video one";
            //ipad.PlayPause(videoClips[1]);
            materialChanger.meshRenderer.material = materialChanger.mats[0];
            backButton.SetActive(true);
            //playButton.SetActive(true);
            playVideo1.SetActive(false);
            playVideo0.SetActive(false);
            videoPlayer.clip = videoClips[1];
            videoPlayer.Play();
        }

        if (gm.currentObject.CompareTag("BackButton")|| Input.GetKeyDown(KeyCode.D))//&& OVRInput.Get(OVRInput.Button.One))
        {
            //debug.text = "back to home screen";
            materialChanger.meshRenderer.material = materialChanger.mats[1];
            //playButton.SetActive(false);
            playVideo0.SetActive(true);
            playVideo1.SetActive(true);
            backButton.SetActive(false);
        }

        if (gm.currentObject.CompareTag("PlayButton"))
        {
            //debug.text = "paused";
            //ipad.PlayPause(ipad.CurrentClip());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if the player collides with the cherry container then the cherry instatiates and count them too see if yu have the right amount
    }

    private void OnTriggerEnter(Collider other)
    {
        gm.currentObject = other.gameObject;
        ///debug.text = "on " + currentObject.name;
    }

    private void OnTriggerExit(Collider other)
    {
        gm.currentObject = null;
        //debug.text = "off " + currentObject.name;
    }

    void Belt()
    {
        //debug.text = "Belt on";
        gm.beltOn = true;
    }

    void BeltOff()
    {
        print("Belt Off");
        gm.beltOn = false;
    }

    void VanillaBatter()
    {
        gm.debug.text = "batter pouring";
        Instantiate(vanillaBatter, cakeTin.transform.position, cakeTin.transform.rotation);
        gm.batterAmount += gm.batterPerFrame * Time.deltaTime;
        //batter amount = amount per frame* time that button down
        //save batter amount even after function is stopped being called
        //set batter amount= amount per frame*time.delta time
        //saved value

        gm.batterOn = true;
        //debug.text = "you poured " + batterAmount;
    }

    void ChocolateBatter()
    {
        gm.debug.text = "batter pouring";
        Instantiate(chocolateBatter, cakeTin.transform.position, cakeTin.transform.rotation);
        gm.batterAmount += gm.batterPerFrame * Time.deltaTime;
        gm.batterOn = true;
    }

    void LemonBatter()
    {
        gm.debug.text = "batter pouring";
        Instantiate(lemonBatter, cakeTin.transform.position, cakeTin.transform.rotation);
        gm.batterAmount += gm.batterPerFrame * Time.deltaTime;
        gm.batterOn = true;
    }

    void OvenLight()
    {
        lightOn = !lightOn;
        Light.SetActive(lightOn);
    }

    //make a light button for oven 
    void OvenOn()
    {
        gm.debug.text = "oven on";
        gm.cookTime = gm.cookTimePerOunce * gm.batterAmount;
        //debug.text = "your cook time is " + cookTime;

        gm.ovenOn = true;

        //set cook time based on batter amount
        //on start of function begin baking animation (timer) based on cook time 3 sec before raw, 3 sec after overcooked, 5 sec after on fire
    }

    void OvenOff()
    {
        gm.debug.text = "Oven off";
        gm.ovenOn = false;
    }

    void Frosting()
    {
        //debug.text = "frosting";
        gm.frostingOn = true;
    }

    void Topping()
    {
        if (gm.currentObject.CompareTag("Liquid")) //&& press and hold (just like frosting just more liquidy))
        {

        }

        if (gm.currentObject.CompareTag("Sprinkles")) //&& flipped 180 (so open bit is pointed downwards) && shaken up and down)
        {
            //sprinkles come out only when its being shaken
        }

        if (gm.currentObject.CompareTag("Cherries")) //&& press and hold cherries, when released cherries remain in that spot/ until it hits smth)
        {

        }
    }
}
