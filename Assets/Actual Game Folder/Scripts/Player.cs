using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    #region "initialize variables"
    public GameManager gm;

    //oven light instantiation
    public GameObject Light;
    bool lightOn;

    //ipad instantiation
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
    public GameObject soundOn;
    public GameObject colorOn;
    public GameObject fired;

    //public GameObject playButton;
    public VideoPlayer videoPlayer;
    public VideoClip[] videoClips;
    public MaterialChanger materialChanger;
    //MeshRenderer backButtonMesh;

    //batter
    //parent batter to cake tin and plate
    public Transform Parent;
    public GameObject parentObject;
    public GameObject cakePan;
    

    //oven
    public Material caramel;
    public Material darkBrown;
    public DoorHandle handle;

    //flip station
    public bool cakeFlipped;

    //frosting and decorations
    Spatula spatula;
    public bool holdingKnife;
    public bool holdingSpatula;
    public bool frostingPileInstantiated;
    public GameObject sprinkles;
    public GameObject liquidBottle;
    float buttonCooldownTimer = 0;
    public GameObject dollop;
    public GameObject frosting;

    [SerializeField]
    ParticleSystem batterParticle;
    [SerializeField]
    ParticleSystemRenderer batterParticleRenderer;

    [SerializeField]
    Material vanillaMat;
    [SerializeField]
    Material lemonMat;
    [SerializeField]
    Material chocolateMat;

    [SerializeField]
    ConveyorBelt cakePanConveyorScript;

    private float batterFillSpeed = 0.05f;

    bool batterInstantiated = false;
    #endregion

    #region "TODO"
    //TODO: plates are located under the conveyor belt, knife is down there too -> is you don't use the plate the cake will crumble/ layers wil separate when its supposed to slide into cake box, spreader for frositng is in topping station before liquids

    //TODO: make separate scene for color blind mode
    //TODO: make tags for individual flavors i.e. chocolate batter, vanilla batter, strawberry batter, green frosting etc. (and color blind version)
    //TODO: show up to work one day and someone threw a cake at your face limited vision
    //TODO: tell sydney to make clear film on top of cake box so you can view cake

    //TODO: stack of plates under flip station -> have to grab plate and put on belt to flip cake
    //TODO: child tin to cake empty unchild at cake flip station then cake plate childs to cake then unchilds at end of topping station
    #endregion

    #region "vr button guide"
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

    /*bool IsDragging = false;
    public Transform Parent;
    public GameObject Block;
    public GameObject parentObject;
    if (Input.GetKeyDown(KeyCode.O))
    {
        Block.transform.Translate(.1f, 0, 0);

        Transform childToRemove = parentObject.transform.Find("Push Block");
        childToRemove.parent = null;

        //transform.DetachChildren();
        //how to detahc specific child not include camera
    }


    if (collision.gameObject.CompareTag("Push Block"))
    {
        if (IsDragging == false)
        {
            collision.transform.SetParent(Parent);
            IsDragging = true;

        }
    }

*/


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        gm.currentObject = gameObject;

        //light is not on yet and all ipad buttons that are meant to be ready are on and those that aren't are off
        Light.SetActive(false);
        lightOn = false;

        #region "ipad buttons"
        //ipad setup
        //ipad = gameObject.GetComponent<Ipad>();
        materialChanger.meshRenderer.material = materialChanger.mats[1];
        //backButtonMesh = backButton.GetComponent<MeshRenderer>();
        //playButton.SetActive(false);
        backButton.SetActive(true);
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

        colorOn.SetActive(false);
        soundOn.SetActive(false);
        //fired.SetActive(false);
        #endregion

        // per ounce, the cook time is set to 1
        gm.cookTimePerOunce = 1;

        batterParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        #region "vr debug and settings"
        OVRInput.Update();
        buttonCooldownTimer += Time.deltaTime;

        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            gm.debug.text = "button b";
        }

        #endregion

        //NOT TO BE INCLUDED IN FINAL GAME (NO DEBUG)
        gm.debug.text = "" + gm.batterAmount;

        #region "Cooking the cake"
        /*
        if (gm.ovenOn)
        {
            //deciding size of the cake that is being baked
            if (gm.batterAmount < .35)
            {
              //test whether the right cake is being put in oven
                gm.cake = gm.underfilled;
            }
            else if (gm.batterAmount < .9)
            {
                gm.cake = gm.average;
            }
            else
            {
                gm.cake = gm.overfilled;
            }

            //deciding color of the cake that is being baked depending on what color the batter chosen is
            if (gm.BatterType() == "Chocolate")
            {
                gm.cake.GetComponent<MeshRenderer>().material.color = gm.chocolateBatter.GetComponent<MeshRenderer>().material.color;
            }
            else if (gm.BatterType() == "Vanilla"){
                gm.cake.GetComponent<MeshRenderer>().material.color = gm.vanillaBatter.GetComponent<MeshRenderer>().material.color;
            }
            else if (gm.BatterType() == "Vanilla")
            {
                gm.cake.GetComponent<MeshRenderer>().material.color = gm.lemonBatter.GetComponent<MeshRenderer>().material.color;
            }

            //deciding level of cookness
            if (gm.timeInOven <= gm.cookTime - 1)
            {
                //cake stays the same, no change
                gm.debug.text = "raw";
            }
            else if (gm.timeInOven >= gm.cookTime - 1 && gm.timeInOven <= gm.cookTime + 2)
            {
                //cake becomes darker, the vanilla and lemon cake become caramel colored and the chocolate becomes dark brown
                if (gm.BatterType() == "Vanilla")
                {
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(gameObject.GetComponent<MeshRenderer>().material.color, caramel.color, Time.deltaTime / 50);
                }
                else if(gm.BatterType() == "Lemon")
                {
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(gameObject.GetComponent<MeshRenderer>().material.color, caramel.color, Time.deltaTime / 50);
                }
                else if (gm.BatterType() == "Chocolate")
                {
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(gameObject.GetComponent<MeshRenderer>().material.color, darkBrown.color, Time.deltaTime / 50);
                }

            }
            else if (gm.timeInOven >= gm.cookTime + 2)
            {
                // all three cakes become black as time goes on
                gm.debug.text = "overcooked";
                gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(gameObject.GetComponent<MeshRenderer>().material.color, Color.black, Time.deltaTime / 100);
            }
            else if (gm.timeInOven >= gm.cookTime + 4)
            {
                // the cake lights on fire
            }
        }*/
        #endregion

        #region "Buttons"
        
        if (gm.currentObject != null)
        {
            //gm.debug.text = gm.currentObject.name;
            // print(gm.currentObject.name);


            if (gm.currentObject.CompareTag("StartBelt") || Input.GetKeyDown(KeyCode.O))
            {
                //when green button is pressed, the belt turns on
                Belt();
            }

            if (cakePanConveyorScript.atBatterStation)
            {
                if (gm.currentObject.CompareTag("BatterButton") || Input.GetKeyDown(KeyCode.Comma))
                {
                    FillBatter(gm.currentObject);
                }
                    
            }

            //start oven function
            if (gm.currentObject.CompareTag("OvenOn") && handle.up == false)
            {
                //when the green button on the oven is pressed, the oven turns on if the handles are down meaning doors are closed
                OvenOn();
            }

            if (gm.currentObject.CompareTag("OvenLight") && buttonCooldownTimer > .5f)// && OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.RawButton.Y))
            {
                //when the yellow button on the oven is pressed, the oven light turns on
                buttonCooldownTimer = 0;
                OvenLight();
            }

            //stop oven function
            if (gm.currentObject.CompareTag("OvenOff"))// && OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.RawButton.Y))
            {
                //when the red button on the oven is pressed, the oven turns off but doors and everything stays as is
                OvenOff();
            }

            if (gm.currentObject.CompareTag("CakePan") && OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && OVRInput.Get(OVRInput.RawButton.LHandTrigger) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger) && OVRInput.Get(OVRInput.RawButton.RHandTrigger))
            {
                Flip();
            }

            //press hold and drag
            if (gm.currentObject.CompareTag("FrostingButton") && OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && OVRInput.Get(OVRInput.RawButton.LHandTrigger) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger) && OVRInput.Get(OVRInput.RawButton.RHandTrigger)) //&& !frostingOn)
            {
                Frosting();
                gm.debug.text = "frosting is coming out";
                //on collision and front button to hold/ move both bottoms to get frosting out
            }

            if (gm.currentObject.CompareTag("Knife") && OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && OVRInput.Get(OVRInput.RawButton.LHandTrigger) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger) && OVRInput.Get(OVRInput.RawButton.RHandTrigger))
            {
                Knife();
            }
            else
            {
                holdingKnife = false;
            }

            if (gm.currentObject.CompareTag("Spatula") && OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && OVRInput.Get(OVRInput.RawButton.LHandTrigger) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger) && OVRInput.Get(OVRInput.RawButton.RHandTrigger))
            {
                spatula = gm.currentObject.GetComponent<Spatula>();
                Spatula();
            }
            else
            {
                holdingSpatula = false;
            }

            //press hold and drag
            if (gm.currentObject.CompareTag("ChocolateLiquid") && OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && OVRInput.Get(OVRInput.RawButton.LHandTrigger) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger) && OVRInput.Get(OVRInput.RawButton.RHandTrigger)) //&& !toppingOn)
            {
                Liquid(gm.currentObject);
                // sauce on collision and front button to hold/ move both bottoms to get topping out same as frosting
            }

            if (gm.currentObject.CompareTag("CaramelLiquid") && OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && OVRInput.Get(OVRInput.RawButton.LHandTrigger) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger) && OVRInput.Get(OVRInput.RawButton.RHandTrigger)) //&& !toppingOn)
            {
                Liquid(gm.currentObject);
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

            #endregion

            #region "iPad"
            if (gm.currentObject.CompareTag("PlayVideo0") || Input.GetKeyDown(KeyCode.A)) //&& OVRInput.Get(OVRInput.Button.One))
            {
                materialChanger.meshRenderer.material = materialChanger.mats[0];
                //backButton.SetActive(true);
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
                materialChanger.meshRenderer.material = materialChanger.mats[0];
                //backButton.SetActive(true);
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
                materialChanger.meshRenderer.material = materialChanger.mats[1];
                //playButton.SetActive(false);
                playVideo0.SetActive(true);
                playVideo1.SetActive(true);
                //backButton.SetActive(false);
                clockOut.SetActive(true);
                clockIn.SetActive(false);
                Settings.SetActive(true);
                ColorBlind.SetActive(false);
                Mute.SetActive(false);
                Credits.SetActive(false);
                TextCredits.SetActive(false);
                LevelSelect.SetActive(false);
            }

            if (gm.currentObject.CompareTag("Settings") || Input.GetKeyDown(KeyCode.W))//&& OVRInput.Get(OVRInput.Button.One))
            {
                materialChanger.meshRenderer.material = materialChanger.mats[1];
                //playButton.SetActive(false);
                playVideo0.SetActive(false);
                playVideo1.SetActive(false);
                //backButton.SetActive(true);
                clockOut.SetActive(false);
                clockIn.SetActive(false);
                Settings.SetActive(false);
                ColorBlind.SetActive(true);
                Mute.SetActive(true);
                Credits.SetActive(true);
                LevelSelect.SetActive(true);
            }

            if ((gm.currentObject.CompareTag("ClockOut") && buttonCooldownTimer > .5f) || Input.GetKeyDown(KeyCode.M))
            {
                clockIn.SetActive(true);
                clockOut.SetActive(false);
                print("clocked in");
                buttonCooldownTimer = 0;
                ClockOut();
            }

            if ((gm.currentObject.CompareTag("ClockIn") && buttonCooldownTimer > .5f) || Input.GetKeyDown(KeyCode.N))
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
                //closeCredits.gameObject.SetActive(true);
            }

            if ((gm.currentObject.CompareTag("Mute") && buttonCooldownTimer > .5f) || Input.GetKeyDown(KeyCode.K))
            {
                //turn off the sound on the game
                soundOn.SetActive(true);
                TextCredits.gameObject.SetActive(false);

                Mute.SetActive(false);
                buttonCooldownTimer = 0;
            }
            if ((gm.currentObject.CompareTag("SoundOn") && buttonCooldownTimer > .5f )|| Input.GetKeyDown(KeyCode.H))
            {
                Mute.SetActive(true);
                //turn on the sound on the game
                TextCredits.gameObject.SetActive(false);
                soundOn.SetActive(false);

                buttonCooldownTimer = 0;
            }

            if ((gm.currentObject.CompareTag("ColorBlind") && buttonCooldownTimer > .5f) || Input.GetKeyDown(KeyCode.L))
            {
                //ColorBlindMode.SetActive
                colorOn.SetActive(true);
                TextCredits.gameObject.SetActive(false);

                ColorBlind.SetActive(false);
                buttonCooldownTimer = 0;
            }

            if ((gm.currentObject.CompareTag("ColorOn") && buttonCooldownTimer > .5f)|| Input.GetKeyDown(KeyCode.G))
            {
                ColorBlind.SetActive(true);
                //ColorBlindMode turn off, color is back on
                TextCredits.gameObject.SetActive(false);
                colorOn.SetActive(false);

                buttonCooldownTimer = 0;
            }

            if (gm.currentObject.CompareTag("Level 1") || Input.GetKeyDown(KeyCode.G))
            {
                TextCredits.gameObject.SetActive(false);
                //Level One Set Active
                //Anmation highlight the level selected maybe
            }

            if (gm.currentObject.CompareTag("Level 2") || Input.GetKeyDown(KeyCode.F))
            {
                TextCredits.gameObject.SetActive(false);
                //Level Two Set Active
                //Anmation highlight the level selected maybe
            }

            if (gm.currentObject.CompareTag("Level 3") || Input.GetKeyDown(KeyCode.G))
            {
                TextCredits.gameObject.SetActive(false);
                //Level Three Set Active
                //Anmation highlight the level selected maybe
            }

            /*
            if (gm.currentObject.CompareTag("review") || Input.GetKeyDown(KeyCode.Y))
            {
                //stars appear on page

            }
            */
            //if (if fired is true) make public bool that if percent<= 30 (or whatever number) then fired=true
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
        } else if (batterParticle.isPlaying)
        {
            batterParticle.Stop();
        }
        #endregion

        if (gm.frostingOn == true)
        {
            gm.timeSqueezingFrosting = Time.deltaTime;
        }
        else
        {
            gm.timeSqueezingFrosting = 0;
        }


        if (gm.holdingLiquid == true)
        {
            gm.timeSqueezingLiquid = Time.deltaTime;
        }
        else
        {
            gm.timeSqueezingLiquid = 0;
        }

    }

    #region "triggers and collisions"
    private void OnCollisionEnter(Collision collision)
    {
        // if the player collides with the cherry container then the cherry instatiates and count them too see if yu have the right amount
    }

    private void OnTriggerEnter(Collider other)
    {
        //when an object is hit and has a trigger, the current game object is the gameobject
        gm.currentObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        //when the object that was previously hit is left, then the current game object is null
        gm.currentObject = null;
    }

    #endregion

    #region "functions"

    void ClockOut()
    {
        gm.batterPerFrame = 0;
        
        gm.beltOn = false;
        gm.batterOn = false;
        gm.ovenOn = false;
        gm.frostingOn = false;
        gm.batterAmount = 0;
        
        
        gm.batter.SetActive(false);
        //gm.uncookedBatter.SetActive(false);
        gm.cookTime = 0;
        gm.cookTimePerOunce = 1;
        gm.timeInOven = 0;
        gm.ovenDoorHit = false;
        gm.cake.SetActive(false);
        gm.underfilled.SetActive(false);
        gm.overfilled.SetActive(false);
        gm.average.SetActive(false);
        gm.holdingLiquid = false;
        gm.timeSqueezingLiquid = 0;
        gm.ipadHit = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Belt()
    {
        //debug.text = "Belt on";
        gm.beltOn = true;
    }

    void FillBatter(GameObject _currentObject)
    {
        
        if (!batterInstantiated)
        {

            gm.batter.SetActive(true);
            gm.batter.GetComponent<Renderer>().material = _currentObject.GetComponent<Renderer>().material;

           
            batterInstantiated = true;

        }

        if (gm.batterAmount < gm.tooMuchBatter)
        {
            if (batterParticle.isStopped)
            {
                batterParticleRenderer.material = _currentObject.GetComponent<Renderer>().material;
                batterParticle.Play();
            }

            gm.batter.transform.position += new Vector3(0, gm.batterAmount * 0.0004f * batterFillSpeed, 0);
            gm.batterAmount += gm.batterPerFrame * Time.deltaTime * batterFillSpeed;
        }

        
    }

    void OvenLight()
    {

        lightOn = !lightOn;
        Light.SetActive(lightOn);
    }

    //make a light button for oven
    void OvenOn()
    {

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

    void Flip()
    {
        if (cakePan.transform.rotation.eulerAngles.y >= 160 && cakePan.transform.rotation.eulerAngles.y <= 200)
        {

            cakeFlipped = true;
            //get component rigid body?
        }
    }


    void Knife ()
    {
        holdingKnife = true;
    }


    void Frosting()
    {
        gm.debug.text = "frosting";
        gm.frostingOn = true;

        if (gm.timeSqueezingFrosting >= 5)
        {
           // gm.frostingPilePrefab.SetActive(true);
            frostingPileInstantiated = true;
            gm.frostingDollop = Instantiate(gm.frostingDollop, gm.cake.transform.GetChild(0).position, gm.cake.transform.GetChild(0).rotation);
            //get correct material (corresponds to frosting bag material that you are holding)
        }
        //instantiate/ run frosting coming out animation
        // if spatula used on cake (swiped over 3+ times) do fully covered animation (individual frosting states for each one)
    }

    void Spatula()
    {
        if (frostingPileInstantiated == true)
        {

            holdingSpatula = true;
        }

    }

    void Liquid(GameObject flavor)//&& press and hold (just like frosting just more liquidy))
    {

        if (flavor.transform.rotation.eulerAngles.y >= 160 && flavor.transform.rotation.eulerAngles.y <= 200)
        {
            gm.debug.text = "pouring liquid";
            gm.holdingLiquid = true;
            // liquid particle machine

            if (gm.timeSqueezingLiquid >= 3 && gm.cake != null)
            {
                //flavor.GetComponent<Liquid>().liquidPrefab.SetActive(true);
                //get correct material chocolate or caramel
                //child liquid to cake
                //instantiate liquid prefab
                //Instantiate(flavor.GetComponent<Liquid>().liquidPrefab, gm.cake.transform.GetChild(0));
                Instantiate(flavor.GetComponent<Liquid>().liquidPrefab, gm.cake.transform);
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
    #endregion
}
