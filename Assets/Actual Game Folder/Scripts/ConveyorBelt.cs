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
    bool moveX = true;
    bool moveZ = true;
    bool moveNegX = true;
    bool moveNegZ = true;

    public GameObject Belt2;
    public GameObject Belt3;
    public GameObject counter;
    public GameObject cakeBox;

    //public TextMeshProUGUI debug;

    public GameObject batterStation;
    public GameObject ovenStation;
    public GameObject flipStation;
    public GameObject frostingStation;
    public GameObject toppingStation;


    // Start is called before the first frame update
    void Start()
    {
        //leftHand = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //print(timesInBatterStation);
        //debug.text = "" + leftHand.beltOn; 

        if (gm.beltOn)
        {
            if (moveX == true)
            {
                print("start to belt 2");
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            }
            if (gameObject.transform.position.x >= Belt2.transform.position.x & moveZ == true)
            {
                print("Belt2 2 to belt3");
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
            if ( gameObject.transform.position.x <= counter.transform.position.x && moveNegZ == true && moveX !=true && moveZ !=true)
            {
                
                print("counter to box");
                moveNegX = false;
                transform.Translate (0,0, moveSpeed * Time.deltaTime);
            }
            if (gameObject.transform.position.z>= cakeBox.transform.position.z && moveX != true && moveZ != true)
            {
                moveNegZ = false;
                
            }

        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BatterStop"))
        {
            gm.beltOn = false;
        }

        if (other.gameObject.CompareTag("OvenStop"))
        {
            gm.beltOn = false;
        }

        if (other.gameObject.CompareTag("FlipStop"))
        {
            gm.beltOn = false;
        }

        if (other.gameObject.CompareTag("FrostingStop"))
        {
            gm.beltOn = false;
        }

        if (other.gameObject.CompareTag("ToppingStop"))
        {
            gm.beltOn = false;
        }

    }



}
