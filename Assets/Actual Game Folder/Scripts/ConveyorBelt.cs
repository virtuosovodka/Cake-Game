using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConveyorBelt : MonoBehaviour
{
    public GameManager gm;
    public Player playerLeft;
    public Player playerRight;

    public float moveSpeed;
    public bool moveX = true;
    public bool moveZ = true;
    public bool moveNegX = true;
    public bool moveNegZ = true;

    public GameObject Belt2;
    public GameObject Belt3;
    public GameObject counter;
    public GameObject cakeBox;

    public bool atBatterStation;
    public bool atOven;
    public bool atFlip;
    public bool atFrosting;
    public bool atTopping;

    //public TextMeshProUGUI debug;


    // Start is called before the first frame update
    void Start()
    {

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
                if (moveX == true)
                {
                    print("start to belt 2");
                    transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
                }
                if (gameObject.transform.position.x >= Belt2.transform.position.x & moveZ == true)
                {
                    print("Belt2 to belt3");
                    moveX = false;
                    transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
                }
                if (gameObject.transform.position.z <= Belt3.transform.position.z & moveNegX == true)
                {
                    print("Belt3 to counter");
                    moveZ = false;
                    transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
                    //blah = true;
                }
                if (gameObject.transform.position.x <= counter.transform.position.x && moveNegZ == true && moveX != true && moveZ != true)
                {
                    print("counter to box");
                    moveNegX = false;
                    transform.Translate(0, 0, moveSpeed * Time.deltaTime);
                }
                if (gameObject.transform.position.z >= cakeBox.transform.position.z && moveX != true && moveZ != true)
                {
                    moveNegZ = false;

                }

            }

        }

        // if (cake has been flipped) child plate
        // notihing tells you to use plate can be found in training videos -> will make conveyor belt smoother


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BatterStop"))
        {
            atBatterStation = true;
            gm.beltOn = false;


            atOven = false;
            atFlip = false;
            atFrosting = false;
            atTopping = false;          
        }

        if (other.gameObject.CompareTag("OvenDoorStop"))
        {
            gm.beltOn = false;
        }

        if (other.gameObject.CompareTag("OvenStop"))
        {
            gm.beltOn = false;

            atBatterStation = false;
            atOven = true;
            atFlip = false;
            atFrosting = false;
            atTopping = false;
        }

        if (other.gameObject.CompareTag("FlipStop"))
        {
            gm.beltOn = false;

            atBatterStation = false;
            atOven = false;
            atFlip = true;
            atFrosting = false;
            atTopping = false; 
        }

        if (other.gameObject.CompareTag("FrostingStop"))
        {
            gm.beltOn = false;

            atBatterStation = false;
            atOven = false;
            atFlip = false;
            atFrosting = true;
            atTopping = false;
        }

        if (other.gameObject.CompareTag("ToppingStop"))
        {
            gm.beltOn = false;

            atBatterStation = false;
            atOven = false;
            atFlip = false;
            atFrosting = false;
            atTopping = true;
        }

        if (other.gameObject.CompareTag("CakeBoxStop"))
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