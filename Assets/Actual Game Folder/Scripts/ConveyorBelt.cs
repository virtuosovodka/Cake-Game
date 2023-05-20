using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConveyorBelt : MonoBehaviour
{
    public GameManager gm;
    public DoorHandle dh;

    /*public float moveSpeed;
    public bool moveX = true;
    public bool moveZ = true;
    public bool moveNegX = true;
    public bool moveNegZ = true;*/

    public GameObject Belt2;
    public GameObject Belt3;
    //public GameObject counter;
    public GameObject cakeBox;

    public bool atBatterStation;
    public bool atOven;
    public bool atFlip;
    public bool atFrosting;
    public bool atTopping;

    public bool cakeSwapping;
    public GameObject cakePan;
    public GameObject cakePlate;

    public GameObject frontOvenDoorStop;
    public GameObject backOvenDoorStop;

    //public AudioSource conveyorBelt;
    //public TextMeshProUGUI debug;


    // Start is called before the first frame update
    void Start()
    {
        //conveyorBelt = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //print(timesInBatterStation);
        //debug.text = "" + leftHand.beltOn; 
        if (gm != null)
        {
            if (gm.beltOn)
            {
                //conveyorBelt.Play();
                atBatterStation = false;
                atOven = false;
                atFlip = false;
                atFrosting = false;
                atTopping = false;


                if (gm.moveX == true)
                {
                    //print("start to belt 2");
                    cakePan.transform.Translate(gm.moveSpeed * Time.deltaTime, 0, 0);
                }
                if (cakePan.transform.position.x >= Belt2.transform.position.x & gm.moveZ == true)
                {
                    gm.debug.text = "turning towards oven";
                    //print("Belt2 to belt3");
                    gm.moveX = false;
                    cakePan.transform.Translate(0, 0, -gm.moveSpeed * Time.deltaTime);
                }
                if (cakePan.transform.position.z <= Belt3.transform.position.z & gm.moveNegX == true)
                {
                    //print("Belt3 to counter");
                    gm.moveZ = false;
                    cakePan.transform.Translate(-gm.moveSpeed * Time.deltaTime, 0, 0);
                    //blah = true;
                }
                /*
                if (gameObject.transform.position.x <= counter.transform.position.x && moveNegZ == true && moveX != true && moveZ != true)
                {
                    print("counter to box");
                    moveNegX = false;
                    transform.Translate(0, 0, moveSpeed * Time.deltaTime);
                }*/
                if (cakePan.transform.position.z >= cakeBox.transform.position.z && gm.moveX != true && gm.moveZ != true)
                {
                    gm.moveNegZ = false;

                }

                /* if (gm.cakeSwapping == true)
                 {

                     if (cakePlate.transform.position.x >= Belt2.transform.position.x & gm.moveZ == true)
                     {
                         gm.debug.text = "turning towards oven";
                         //print("Belt2 to belt3");
                         moveX = false;
                         cakePlate.transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
                     }
                     if (cakePlate.transform.position.z <= Belt3.transform.position.z & moveNegX == true)
                     {
                         //print("Belt3 to counter");
                         moveZ = false;
                         cakePlate.transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);

                     }

                     if (cakePlate.transform.position.z >= cakeBox.transform.position.z && moveX != true && moveZ != true)
                     {
                         moveNegZ = false;

                     }
                 }*/

            }

        }
        // if (cake has been flipped) child plate
        // notihing tells you to use plate can be found in training videos -> will make conveyor belt smoother

    }

    void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("BatterStop"))
        {
            //conveyorBelt.Stop();
            Debug.Log("test");
            atBatterStation = true;
            gm.beltOn = false;


            atOven = false;
            atFlip = false;
            atFrosting = false;
            atTopping = false;
        }
        else if (other.gameObject.CompareTag("FrontOvenDoorStop") && dh.ovenDoorUp == false)
        {
            gm.beltOn = false;
        }
        else if (other.gameObject.CompareTag("OvenStop"))
        {
            gm.beltOn = false;

            atBatterStation = false;
            atOven = true;
            atFlip = false;
            atFrosting = false;
            atTopping = false;
        }
        else if (other.gameObject.CompareTag("CakeSwap"))
        {
            cakeSwapping = true;

            Destroy(cakePan);
        }
        else if (other.gameObject.CompareTag("FlipStop"))
        {
            //conveyorBelt.Stop();
            gm.beltOn = false;

            atBatterStation = false;
            atOven = false;
            atFlip = true;
            atFrosting = false;
            atTopping = false;
        }
        else if (other.gameObject.CompareTag("FrostingStop"))
        {
            //conveyorBelt.Stop();
            gm.beltOn = false;

            atBatterStation = false;
            atOven = false;
            atFlip = false;
            atFrosting = true;
            atTopping = false;
        }
        else if (other.gameObject.CompareTag("ToppingStop"))
        {
            //conveyorBelt.Stop();
            gm.beltOn = false;

            atBatterStation = false;
            atOven = false;
            atFlip = false;
            atFrosting = false;
            atTopping = true;
        }
        else if (other.gameObject.CompareTag("CakeBoxStop"))
        {
            //conveyorBelt.Stop();
            gm.beltOn = false;

            atBatterStation = false;
            atOven = false;
            atFlip = false;
            atFrosting = false;
            atTopping = false;
        }
        
    }

}