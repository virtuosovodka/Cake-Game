using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    GameObject currentObject;
    Rigidbody rb;
    public bool beltOn = false;
    public bool batterOn = false;
    public bool ovenOn = false;
    public bool frostingOn = false;

    public float moveSpeed = 2;
    public bool moveX = true;
    public GameObject Belt2;
    public GameObject Belt3;
    bool moveZ = true;
    public GameObject counter;
    bool moveNegX = true;

    public float batterPerFrame;
    float batterAmount;

    float cookTime;
    public float cookTimePerOunce;
    float timeInOven;
    public TextMeshProUGUI text;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentObject = null;
        //text.text = "Button ";
    }

    // Update is called once per frame
    void Update()
    {

        OVRInput.Update();

        if (currentObject.CompareTag("StartBelt")) //Button A?
        {
            Belt();
            text.text = "Button pressed! StartBelt.";
        }


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


    private void OnTriggerEnter(Collider other)
    {
        currentObject = other.gameObject;
        print(currentObject.name);

        if (currentObject.CompareTag("StartBelt"))
        {
            Belt();
            text.text = "Button pressed! StartBelt.";
        }
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

        //press
        //stop oven function
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentObject.CompareTag("OvenOff"))
        {
            OvenOff();
        }


        //press hold and drag
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentObject.CompareTag("FrostingButton")) //&& !frostingOn) //right hand trigger?
        {
            Frosting();
        }
        

    }

    void Belt()
    {

            if (moveX == true)
            {
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            }
            if (gameObject.transform.position.x >= Belt2.transform.position.x & moveZ == true)
            {

                moveX = false;
                transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
            }
            if (gameObject.transform.position.z <= Belt3.transform.position.z & moveNegX == true)
            {

                moveZ = false;
                transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            }
            if (gameObject.transform.position.x <= counter.transform.position.x)
            {
                moveNegX = false;

            }
        

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
}
