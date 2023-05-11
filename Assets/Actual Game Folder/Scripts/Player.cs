using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class Player : MonoBehaviour
{
    public GameManager gm;
    public ConveyorBelt cake;

    //light
    public GameObject Light;
    bool lightOn;

    //ipad
    //public Ipad ipad;
    public GameObject backButton;
    public GameObject playVideo0;
    public GameObject playVideo1;
    public GameObject clockIn;
    public GameObject clockOut;
    public GameObject Settings;
    public GameObject ColorBlind;
    public GameObject Mute;
    public GameObject Credits;
    public GameObject LevelSelect;
    public GameObject TextCredits;
    public GameObject closeCredits;
    public GameObject soundOn;
    public GameObject colorOn;
    public GameObject fired;


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

    //parent batter to cake tin and plate
    public Transform Parent;
    public GameObject parentObject;

    //oven
    public GameObject underFilled;
    public GameObject overFilled;
    public GameObject rightSized;

    //batter
    
    public GameObject cakeTin;

    public GameObject sprinkles;
    public GameObject liquid;
    float buttonCooldownTimer = 0;
    

    //TODO: make separate scene for color blind mode
    //TODO: make tags for individual flavors i.e. chocolate batter, vanilla batter, strawberry batter, green frosting etc. (and color blind version)
    //TODO: show up to work one day and someone threw a cake at your face limited vision
    //TODO: tell sydney to make clear film on top of cake box so you can view cake

    //TODO: stack of plates under flip station -> have to grab plate and put on belt to flip cake
    //TODO: child tin to cake empty unchild at cake flip station then cake plate childs to cake then unchilds at end of topping station


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
        clockIn.SetActive(false);
        clockOut.SetActive(true);
        Settings.SetActive(true);
        ColorBlind.SetActive(false);
        Mute.SetActive(false);
        Credits.SetActive(false);
        LevelSelect.SetActive(false);
        TextCredits.SetActive(false);
        closeCredits.SetActive(false);
        colorOn.SetActive(false);
        soundOn.SetActive(false);
        fired.SetActive(false);

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

        // oven set false
        underFilled.SetActive(false);
        overFilled.SetActive(false);
        rightSized.SetActive(false);

       
        
    }

    // Update is called once per frame
    void Update()
    {
        gm.debug.text = " " +cake.atBatterStation;

        OVRInput.Update();
        buttonCooldownTimer += Time.deltaTime;

        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            gm.debug.text = "button b";
        }

        //gm.debug.text = "batter amount" + gm.chocolateBatterAmount;
        
        if (gm.ovenOn)
        {
            gm.timeInOven += Time.deltaTime;

            //debug.text = "time in oven is " + timeInOven;

            if (gm.timeInOven <= gm.cookTime - 1)
            {
                //debug.text = "raw";
                //run not baked animation
                gm.debug.text = "raw";
                overFilled.SetActive(false);
                rightSized.SetActive(false);
                underFilled.SetActive(true);
            }
            else if (gm.timeInOven >= gm.cookTime - 1 && gm.timeInOven <= gm.cookTime + 2)
            {
                // debug.text = "cooked";
                // run cooked animation
                gm.debug.text = "right";
                overFilled.SetActive(false);
                underFilled.SetActive(false);
                rightSized.SetActive(true);
            }
            else if (gm.timeInOven >= gm.cookTime + 2)
            {
                // debug.text = "overcooked";
                // run overbaked animation
                gm.debug.text = "overcooked";
                underFilled.SetActive(false);
                rightSized.SetActive(false);
                overFilled.SetActive(true);
            }
            else if (gm.timeInOven >= gm.cookTime + 4)
            {
                // debug.text = "on fire";
                // run fire animationk
            }
        }


        if (gm.currentObject != null)
        {
            //gm.debug.text = gm.currentObject.name;
            //print(gm.currentObject.name);

            if (gm.currentObject.CompareTag("StartBelt"))// && OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.RawButton.Y) || Input.GetKeyDown(KeyCode.D)) // || Input.GetKeyDown(KeyCode.K))//OVRInput.GetDown(OVRInput.Button.One) && 
            {
                Belt();
                //start button is on collision &&  B or Y button 
            }

            if (gm.currentObject.CompareTag("VanillaBatterButton"))// && OVRInput.Get(OVRInput.Button.Two) || OVRInput.Get(OVRInput.RawButton.Y))
            {
                VanillaBatter();
                //batter button is on collision && while B or Y button is down
            }

            if (gm.currentObject.CompareTag("ChocolateBatterButton"))// && OVRInput.Get(OVRInput.Button.Two) || OVRInput.Get(OVRInput.RawButton.Y))
            {
                ChocolateBatter();
            }


            if (gm.currentObject.CompareTag("LemonBatterButton"))// && OVRInput.Get(OVRInput.Button.Two) || OVRInput.Get(OVRInput.RawButton.Y))
            {
                LemonBatter();
            }

            //start oven function
            if (gm.currentObject.CompareTag("OvenOn"))// && OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.RawButton.Y))
            {
                OvenOn();
                // on collision and B or Y

            }


            if (gm.currentObject.CompareTag("OvenLight") && buttonCooldownTimer > .5f)// && OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.RawButton.Y))
            {

                buttonCooldownTimer = 0;
                OvenLight();
                // on collision and B or Y
            }


            //stop oven function
            if (gm.currentObject.CompareTag("OvenOff"))// && OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.RawButton.Y))
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
                clockOut.SetActive(false);
                clockIn.SetActive(false);
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
                clockOut.SetActive(false);
                clockIn.SetActive(false);
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
                clockOut.SetActive(true);
                clockIn.SetActive(false);
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
                clockOut.SetActive(false);
                clockIn.SetActive(false);
                Settings.SetActive(false);
                ColorBlind.SetActive(true);
                Mute.SetActive(true);
                Credits.SetActive(true);
                LevelSelect.SetActive(true);
            }



            if ((gm.currentObject.CompareTag("ClockOut") && buttonCooldownTimer > .5f) || Input.GetKeyDown(KeyCode.G))
            {
                clockOut.SetActive(false);
                clockIn.SetActive(true);
                buttonCooldownTimer = 0;
            }

            if ((gm.currentObject.CompareTag("ClockIn") && buttonCooldownTimer > .5f) || Input.GetKeyDown(KeyCode.G))
            {
                clockOut.SetActive(true);
                clockIn.SetActive(false);
                buttonCooldownTimer = 0;
            }

            if (gm.currentObject.CompareTag("PlayButton"))
            {
                //debug.text = "paused";
                //ipad.PlayPause(ipad.CurrentClip());
            }

            if (gm.currentObject.CompareTag("Credits") || Input.GetKeyDown(KeyCode.P))
            {
                TextCredits.gameObject.SetActive(true);
                closeCredits.gameObject.SetActive(true);

            }

            if (gm.currentObject.CompareTag("closeCredits") || Input.GetKeyDown(KeyCode.J))
            {
                TextCredits.gameObject.SetActive(false);
                closeCredits.gameObject.SetActive(false);
            }


            if (gm.currentObject.CompareTag("Mute") || Input.GetKeyDown(KeyCode.K))
            {
                //turn off the sound on the game
                soundOn.SetActive(true);
                Mute.SetActive(false);
            }
            if (gm.currentObject.CompareTag("soundOn") || Input.GetKeyDown(KeyCode.H))
            {
                //turn on the sound on the game
                soundOn.SetActive(false);
                Mute.SetActive(true);
            }

            if (gm.currentObject.CompareTag("ColorBlind") || Input.GetKeyDown(KeyCode.L))
            {
                //ColorBlindMode.SetActive
                colorOn.SetActive(true);
                ColorBlind.SetActive(false);
            }

            if (gm.currentObject.CompareTag("colorOn") || Input.GetKeyDown(KeyCode.G))
            {
                //ColorBlindMode turn off, color is back on
                colorOn.SetActive(false);
                ColorBlind.SetActive(true);
            }

            if (gm.currentObject.CompareTag("Level1") || Input.GetKeyDown(KeyCode.G))
            {
                //Level One Set Active
                //Anmation highlight the level selected maybe
            }

            if (gm.currentObject.CompareTag("Level2") || Input.GetKeyDown(KeyCode.F))
            {
                //Level Two Set Active
                //Anmation highlight the level selected maybe
            }

            if (gm.currentObject.CompareTag("Level3") || Input.GetKeyDown(KeyCode.G))
            {
                //Level Three Set Active
                //Anmation highlight the level selected maybe
            }

            if (gm.currentObject.CompareTag("review") || Input.GetKeyDown(KeyCode.Y))
            {
                //stars appear on page

            }

            //if (Input.GetKeyDown(KeyCode.Y (if fired is true) 
            // {
            //    fired.SetActive(true);
            //    backButton.SetActive(true);
            //    playVideo0.SetActive(false);
            //    playVideo1.SetActive(false);
            //    clockIn.SetActive(false);
            //    clockOut.SetActive(false);
            //    Settings.SetActive(false);
            //    ColorBlind.SetActive(false);
            //    Mute.SetActive(false);
            //    Credits.SetActive(false);
            //    LevelSelect.SetActive(false);
            //    TextCredits.SetActive(false);
            //    closeCredits.SetActive(false);
            //    colorOn.SetActive(false);
            //    soundOn.SetActive(false);

            //}
        }

        /* if (gm.chocolateBatterInstantiated == true)
         {

             //instantiate batter
             Instantiate(chocolateBatter, cakeTin.transform.position, cakeTin.transform.rotation);
             chocolateBatter.transform.SetParent(Parent);
             chocolateBatter.transform.position += new Vector3(0, gm.batterAmount, 0);

             gm.debug.text = " batter instantiated";
             gm.chocolateBatterInstantiated = false;


         }*/

        if (gm.holdingLiquid == true)
        {
            gm.timeSqueezingLiquid = Time.deltaTime;
        }
        else
        {
            gm.timeSqueezingLiquid = 0;
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
        if (cake.atBatterStation == true)
        {
            gm.vanillaBatter.SetActive(true);
            if (gm.vanillaBatterAmount < gm.tooMuchBatter)
            {
                gm.vanillaBatterAmount += gm.batterPerFrame * Time.deltaTime;
                gm.vanillaBatter.transform.position += new Vector3(0, gm.vanillaBatterAmount * .001f, 0);
            }
        }
    }

    void ChocolateBatter()
    {
        if (cake.atBatterStation == true)
        {
            gm.chocolateBatter.SetActive(true);
            if (gm.chocolateBatterAmount < gm.tooMuchBatter)
            {
                gm.chocolateBatterAmount += gm.batterPerFrame * Time.deltaTime;
                gm.chocolateBatter.transform.position += new Vector3(0, gm.chocolateBatterAmount * .001f, 0);
            }
        }
    }

    void LemonBatter()
    {
        if (cake.atBatterStation == true)
        {
            gm.lemonBatter.SetActive(true);
            if (gm.lemonBatterAmount < gm.tooMuchBatter)
            {
                gm.lemonBatterAmount += gm.batterPerFrame * Time.deltaTime;
                gm.lemonBatter.transform.position += new Vector3(0, gm.lemonBatterAmount * .001f, 0);
            }
        }

    }

    void OvenLight()
    {
        if (cake.atOven)
        {
            lightOn = !lightOn;
            Light.SetActive(lightOn);
        }

    }

    //make a light button for oven 
    void OvenOn()
    {
        if (cake.atOven)
        {
            gm.debug.text = "oven on";
            gm.cookTime = gm.cookTimePerOunce * gm.chocolateBatterAmount;
            //debug.text = "your cook time is " + cookTime;

            gm.ovenOn = true;

            //set cook time based on batter amount
            //on start of function begin baking animation (timer) based on cook time 3 sec before raw, 3 sec after overcooked, 5 sec after on fire
        }
    }

    void OvenOff()
    {
        if (cake.atOven)
        {
            gm.debug.text = "Oven off";
            gm.ovenOn = false;
        }

    }

    void Frosting()
    {
        if (cake.atFrosting)
        {
            //debug.text = "frosting";
            gm.frostingOn = true;
            //instantiate/ run frosting coming out animation
            // if spatula used on cake (swiped over 3+ times) do fully covered animation (individual frosting states for each one) }
        }
    }

    void Liquid()//&& press and hold (just like frosting just more liquidy))
    {
        if (cake.atTopping)
        {
            if (liquid.transform.rotation.eulerAngles.y >= 160 && liquid.transform.rotation.eulerAngles.y <= 200)
            {
                gm.debug.text = "pouring liquid";
                gm.holdingLiquid = true;
                // liquid particle machine

                if (gm.timeSqueezingLiquid >= 3)
                {
                    //instantiate liquid prefab
                }

            }
            //if circular motion and held for 3 sec and flipped upside down
        }

    }

    void Sprinkles()//&& flipped 180 (so open bit is pointed downwards) && shaken up and down)
    {
        if (cake.atTopping)
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

    }

    void Cherries()//&& press and hold cherries, when released cherries remain in that spot/ until it hits smth)
    {
        if (cake.atTopping)
        {
            //grabbable 
        }

    }
}