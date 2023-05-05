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
    public GameObject TimeCard;
    public GameObject Settings;
    public GameObject ColorBlind;
    public GameObject Mute;
    public GameObject Credits;
    public GameObject LevelSelect;

    //public GameObject playButton;
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
    public GameObject LiquidPrompt;
    public GameObject SprinklesPrompt;
    public GameObject CherriesPrompt;

    public GameObject vanillaBatter;
    public GameObject chocolateBatter;
    public GameObject lemonBatter;
    public GameObject cakeTin;

    public GameObject sprinkles;
    public GameObject liquid;

    bool vanillaBatterInstantiated = false;
    bool chocolateBatterInstantiated = false;
    bool lemonBatterInstantiated = false;

    bool holdingLiquid = false;
    public float timeSqueezingLiquid;

    //TODO: make separate scene for color blind mode
    //TODO: make tags for individual flavors i.e. chocolate batter, vanilla batter, strawberry batter, green frosting etc. (and color blind version)
    //TODO: show up to work one day and someone threw a cake at your face limited vision
    //TODO: tell sydney to make clear film on top of cake box so you can view cake

    //TODO: stack of plates under flip station -> have to grab plate and put on belt to flip cake
    //TODO: child tin to cake empty unchild at cake flip station then cake plate childs to cake then unchilds at end of topping station

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
        gm.currentObject = gameObject;

        Light.SetActive(false);
        lightOn = false;

        //ipad setup
        //ipad = gameObject.GetComponent<Ipad>();
        materialChanger.meshRenderer.material = materialChanger.mats[1];
        backButtonMesh = backButton.GetComponent<MeshRenderer>();
        //playButton.SetActive(false);
        backButton.SetActive(false);
        playVideo0.SetActive(true);
        playVideo1.SetActive(true);
        TimeCard.SetActive(true);
        Settings.SetActive(true);
        ColorBlind.SetActive(false);
        Mute.SetActive(false);
        Credits.SetActive(false);
        LevelSelect.SetActive(false);



        //button press prompts
        StartBeltPrompt.SetActive(false);
        BatterPrompt.SetActive(false);
        OvenDoorPrompt.SetActive(false);
        OvenOnPrompt.SetActive(false);
        OvenLightPrompt.SetActive(false);
        OvenOffPrompt.SetActive(false);
        FrostingPrompt.SetActive(false);
        LiquidPrompt.SetActive(false);
        SprinklesPrompt.SetActive(false);
        CherriesPrompt.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
       

        //OVRInput.Update();
        
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
        

        if (gm.currentObject != null)
        {
            //gm.debug.text = gm.currentObject.name;
            //print(gm.currentObject.name);

            if (gm.currentObject.CompareTag("StartBelt") && OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.RawButton.Y) || Input.GetKeyDown(KeyCode.D)) // || Input.GetKeyDown(KeyCode.K))//OVRInput.GetDown(OVRInput.Button.One) && 
            {
                Belt();
                //start button is on collision &&  B or Y button 
            }

            if (gm.currentObject.CompareTag("VanillaBatterButton") && OVRInput.Get(OVRInput.Button.Two) || OVRInput.Get(OVRInput.RawButton.Y))
            {
                VanillaBatter();
                //batter button is on collision && while B or Y button is down
            }

            if (gm.currentObject.CompareTag("ChocolateBatterButton") && OVRInput.Get(OVRInput.Button.Two) || OVRInput.Get(OVRInput.RawButton.Y))
            {
                ChocolateBatter();
            }

            if (gm.currentObject.CompareTag("LemonBatterButton") && OVRInput.Get(OVRInput.Button.Two) || OVRInput.Get(OVRInput.RawButton.Y))
            {
                LemonBatter();
            }

            //start oven function
            if (gm.currentObject.CompareTag("OvenOn") && OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.RawButton.Y))
            {
                OvenOn();
                // on collision and B or Y

            }

            if (gm.currentObject.CompareTag("OvenLight") && OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.RawButton.Y))
            {
                OvenLight();
                // on collision and B or Y
            }

            //stop oven function
            if (gm.currentObject.CompareTag("OvenOff") && OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.RawButton.Y))
            {
                OvenOff();
                // on collision and B or Y
            }

            //press hold and drag
            if (gm.currentObject.CompareTag("FrostingButton") && OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && OVRInput.Get(OVRInput.RawButton.LHandTrigger) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger) && OVRInput.Get(OVRInput.RawButton.RHandTrigger)) //&& !frostingOn)
            {
                Frosting();
                gm.debug.text = "frosting is ocming out";
                //on collision and front button to hold/ move both bottoms to get frosting out
            }

            //press hold and drag
            if (gm.currentObject.CompareTag("Liquid") && OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && OVRInput.Get(OVRInput.RawButton.LHandTrigger) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger) && OVRInput.Get(OVRInput.RawButton.RHandTrigger)) //&& !toppingOn)
            {
                Liquid();
                // sauce on collision and front button to hold/ move both bottoms to get topping out same as frosting
            }

            if (gm.currentObject.CompareTag("Sprinkles") && OVRInput.Get(OVRInput.RawButton.LHandTrigger) || OVRInput.Get(OVRInput.RawButton.RHandTrigger)) //&& !toppingOn)
            {
                Sprinkles();
                // sprinklies on collision flipped 180, will make a range~ 120-240? and shaken- Y value changes by x or more
            }

            if (gm.currentObject.CompareTag("Cherries") && OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && OVRInput.GetDown(OVRInput.RawButton.Y) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger) && OVRInput.GetDown(OVRInput.Button.Two)) //&& !toppingOn)
            {
                Cherries();
                // cherries on collision front button && y/b to pick it up
            }

            //BUTTON INSTRUCTIONS FOR LEVEL 1 *ONLY*
            if (gm.currentObject.gameObject.CompareTag("StartBeltButton")) //&& in level 1
            {
                StartBeltPrompt.SetActive(true);
            }
            else if (gm.currentObject.gameObject.CompareTag("StartBeltButton")) //&& in level 1
            {
                StartBeltPrompt.SetActive(false);
            }

            if (gm.currentObject.gameObject.CompareTag("BatterButton")) //&& in level 1
            {
                BatterPrompt.SetActive(true);
            }
            else if (gm.currentObject.gameObject.CompareTag("BatterButton")) //&& in level 1
            {
                BatterPrompt.SetActive(false);
            }

            if (gm.currentObject.gameObject.CompareTag("OvenDoor"))//&& in level 1
            {
                OvenDoorPrompt.SetActive(true);
            }
            else if (gm.currentObject.gameObject.CompareTag("OvenDoor")) //&& in level 1
            {
                OvenDoorPrompt.SetActive(false);
            }

            if (gm.currentObject.gameObject.CompareTag("OvenOn"))//&& in level 1
            {
                OvenOnPrompt.SetActive(true);
            }
            else if (gm.currentObject.gameObject.CompareTag("OvenOn")) //&& in level 1
            {
                OvenOnPrompt.SetActive(false);
            }

            if (gm.currentObject.gameObject.CompareTag("OvenLight"))//&& in level 1
            {
                OvenLightPrompt.SetActive(true);
            }
            else if (gm.currentObject.gameObject.CompareTag("OvenLight")) //&& in level 1
            {
                OvenLightPrompt.SetActive(false);
            }

            if (gm.currentObject.gameObject.CompareTag("OvenOff"))//&& in level 1
            {
                OvenOffPrompt.SetActive(true);
            }
            else if (gm.currentObject.gameObject.CompareTag("OvenOff")) //&& in level 1
            {
                OvenOffPrompt.SetActive(false);
            }

            if (gm.currentObject.gameObject.CompareTag("FrostingButton"))//&& in level 1
            {
                FrostingPrompt.SetActive(true);
            }
            else if (gm.currentObject.gameObject.CompareTag("FrostingButton")) //&& in level 1
            {
                FrostingPrompt.SetActive(false);
            }

            if (gm.currentObject.gameObject.CompareTag("Sauce"))//&& in level 1
            {
                LiquidPrompt.SetActive(true);
            }
            else if (gm.currentObject.gameObject.CompareTag("Sauce")) //&& in level 1
            {
                LiquidPrompt.SetActive(false);
            }

            if (gm.currentObject.gameObject.CompareTag("Sprinkles"))//&& in level 1
            {
                SprinklesPrompt.SetActive(true);
            }
            else if (gm.currentObject.gameObject.CompareTag("Sprinkles")) //&& in level 1
            {
                SprinklesPrompt.SetActive(false);
            }

            if (gm.currentObject.gameObject.CompareTag("Cherries"))//&& in level 1
            {
                CherriesPrompt.SetActive(true);
            }
            else if (gm.currentObject.gameObject.CompareTag("Cherries")) //&& in level 1
            {
                CherriesPrompt.SetActive(false);
            }


            //IPAD MAGIC
            if (gm.currentObject.CompareTag("PlayVideo0") || Input.GetKeyDown(KeyCode.A)) //&& OVRInput.Get(OVRInput.Button.One))
            {
                print("ipad play 0");
                //debug.text = "play video zero";
                //ipad.PlayPause(videoClips[0]);
                materialChanger.meshRenderer.material = materialChanger.mats[0];
                backButton.SetActive(true);
                //playButton.SetActive(true);
                playVideo0.SetActive(false);
                playVideo1.SetActive(false);
                TimeCard.SetActive(false);
                Settings.SetActive(false);
                ColorBlind.SetActive(false);
                Mute.SetActive(false);
                Credits.SetActive(false);
                LevelSelect.SetActive(false);
                videoPlayer.clip = videoClips[0];
                videoPlayer.Play();
            }

            if (gm.currentObject.CompareTag("PlayVideo1") || Input.GetKeyDown(KeyCode.S)) //&& OVRInput.Get(OVRInput.Button.One))
            {
                print("ipad play 1");
                //debug.text = "play video one";
                //ipad.PlayPause(videoClips[1]);
                materialChanger.meshRenderer.material = materialChanger.mats[0];
                backButton.SetActive(true);
                //playButton.SetActive(true);
                playVideo1.SetActive(false);
                playVideo0.SetActive(false);
                TimeCard.SetActive(false);
                Settings.SetActive(false);
                ColorBlind.SetActive(false);
                Mute.SetActive(false);
                Credits.SetActive(false);
                LevelSelect.SetActive(false);
                videoPlayer.clip = videoClips[1];
                videoPlayer.Play();
            }

            if (gm.currentObject.CompareTag("BackButton") || Input.GetKeyDown(KeyCode.D))//&& OVRInput.Get(OVRInput.Button.One))
            {
                print("ipad back");
                //debug.text = "back to home screen";
                materialChanger.meshRenderer.material = materialChanger.mats[1];
                //playButton.SetActive(false);
                playVideo0.SetActive(true);
                playVideo1.SetActive(true);
                backButton.SetActive(false);
                TimeCard.SetActive(true);
                Settings.SetActive(true);
                ColorBlind.SetActive(false);
                Mute.SetActive(false);
                Credits.SetActive(false);
                LevelSelect.SetActive(false);
            }

            if (gm.currentObject.CompareTag("Settings") || Input.GetKeyDown(KeyCode.W))//&& OVRInput.Get(OVRInput.Button.One))
            {
                print("settings");
                //debug.text = "back to home screen";
                materialChanger.meshRenderer.material = materialChanger.mats[1];
                //playButton.SetActive(false);
                playVideo0.SetActive(false);
                playVideo1.SetActive(false);
                backButton.SetActive(true);
                TimeCard.SetActive(false);
                Settings.SetActive(false);
                ColorBlind.SetActive(true);
                Mute.SetActive(true);
                Credits.SetActive(true);
                LevelSelect.SetActive(true);
            }

            if (gm.currentObject.CompareTag("PlayButton"))
            {
                //debug.text = "paused";
                //ipad.PlayPause(ipad.CurrentClip());
            }
        }

        if (chocolateBatterInstantiated == true)
        {
            chocolateBatterInstantiated = false;
            //instantiate batter
            Instantiate(chocolateBatter, cakeTin.transform.position, cakeTin.transform.rotation);
        }

        if (holdingLiquid == true)
        {
            timeSqueezingLiquid = Time.deltaTime;
        }
        else
        {
            timeSqueezingLiquid = 0;
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
        gm.debug.text = "chocolate batter pouring";
        gm.batterOn = true;

        chocolateBatterInstantiated = true;
        if (chocolateBatterInstantiated == true)
        {
            gm.batterAmount += gm.batterPerFrame * Time.deltaTime;
            chocolateBatter.transform.position += new Vector3(0, gm.batterAmount, 0);
        }
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
        //instantiate/ run frosting coming out animation
        // if spatula used on cake (swiped over 3+ times) do fully covered animation (individual frosting states for each one)
    }

    void Liquid()//&& press and hold (just like frosting just more liquidy))
    {

        if (liquid.transform.rotation.eulerAngles.y >= 160 && liquid.transform.rotation.eulerAngles.y <= 200)
        {
            gm.debug.text = "pouring liquid";
            holdingLiquid = true;
            // liquid particle machine

            if (timeSqueezingLiquid >= 3)
            {
                //instantiate liquid prefab
            }
           
        }
        //if circular motion and held for 3 sec and flipped upside down
    }

    void Sprinkles()//&& flipped 180 (so open bit is pointed downwards) && shaken up and down)
    {
        if (sprinkles.transform.rotation.eulerAngles.y >= 120 && sprinkles.transform.rotation.eulerAngles.y <= 240)
        {
            gm.debug.text = "sprinkling";
        }
        // when flipped 180, will make a range~ 120-240? x amount of sprinkles come out once
        // shaken- Y value changes by certain amount or more x amount of sprinkles* # of times shaken = amount that comes out?
        // flip x amount out, shake ++ x amount, for n number of shakes n number of sprinkles come out

        // public int # of sprinkles++
    }

    void Cherries()//&& press and hold cherries, when released cherries remain in that spot/ until it hits smth)
    {
        //grabbable 
    }
}