using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeFlip : MonoBehaviour
{

    public GameManager gm;
    public DoorHandle dh;
    public ConveyorBelt cb;

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

    public GameObject frontOvenDoorStop;
    public GameObject backOvenDoorStop;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gm.cakeSwapping == true)
        {
     
                if (gm.beltOn)
                {
                       

                    if (gm.moveX == true)
                    {
                        //print("start to belt 2");
                        transform.Translate(gm.moveSpeed * Time.deltaTime, 0, 0);
                    }
                    if (gameObject.transform.position.x >= Belt2.transform.position.x & gm.moveZ == true)
                    {
                        gm.debug.text = "turning towards oven";
                        //print("Belt2 to belt3");
                        gm.moveX = false;
                        transform.Translate(0, 0, -gm.moveSpeed * Time.deltaTime);
                    }
                    if (gameObject.transform.position.z <= Belt3.transform.position.z & gm.moveNegX == true)
                    {
                        //print("Belt3 to counter");
                        gm.moveZ = false;
                        transform.Translate(-gm.moveSpeed * Time.deltaTime, 0, 0);
                        //blah = true;
                    }

                    if (gameObject.transform.position.z >= cakeBox.transform.position.z && gm.moveX != true && gm.moveZ != true)
                    {
                        gm.moveNegZ = false;

                    }

                }
            

        

        }
    }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("CakePan"))
            {
                gm.cakeSwapping = true;
            gm.moveX = false;
            gm.moveZ = true;
        }
        }

        void OnTriggerEnter(Collider other)
        {
        if (other.gameObject.CompareTag("BatterStop"))
        {
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

        else if (other.gameObject.CompareTag("FlipStop"))
        {
            gm.beltOn = false;

            atBatterStation = false;
            atOven = false;
            atFlip = true;
            atFrosting = false;
            atTopping = false;
        }
        else if (other.gameObject.CompareTag("FrostingStop"))
        {
            gm.beltOn = false;

            atBatterStation = false;
            atOven = false;
            atFlip = false;
            atFrosting = true;
            atTopping = false;
        }
        else if (other.gameObject.CompareTag("ToppingStop"))
        {
            gm.beltOn = false;

            atBatterStation = false;
            atOven = false;
            atFlip = false;
            atFrosting = false;
            atTopping = true;
        }
        else if (other.gameObject.CompareTag("CakeBoxStop"))
        {
            gm.beltOn = false;

            atBatterStation = false;
            atOven = false;
            atFlip = false;
            atFrosting = false;
            atTopping = false;
        }

            }

        }

