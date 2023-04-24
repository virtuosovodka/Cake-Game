using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConveyorBelt : MonoBehaviour
{
    public float moveSpeed = 2;
    public bool moveX = true;
    public GameObject Belt2;
    public GameObject Belt3;
    bool moveZ = true;
    public GameObject counter;
    bool moveNegX = true;
    bool moveNegZ = true;
    bool moveNegY = true;
    public Player player;
    //public TextMeshProUGUI debug;

    public GameObject batterStation;
    public GameObject ovenStation;
    public GameObject flipStation;
    public GameObject frostingStation;
    public GameObject toppingStation;

    public int timesInBatterStation;
    public int timesInOvenStation;
    public int timesInFrostingStation;
    public int timesInToppingStation;
    public int timesInFlipStation;
    public float tolerance;

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

        if (player.beltOn)
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

            /*if (gameObject.transform.position.x <= counter.transform.position.x & moveNegZ == true)
            {
                moveNegX = false;
                //moveNegZ = false;
                //transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
            }*/

            if (gameObject.transform.position.z <= counter.transform.position.z)
            {
                moveNegZ = false;

            }

            /*
            // make two separate if statements for this bit on after the other else if then else
            if (gameObject.transform.position.x <= batterStation.transform.position.x + tolerance && gameObject.transform.position.x >= batterStation.transform.position.x - tolerance) 
            {
                print("in batter station");
                timesInBatterStation++;
                //stop moving
                // bool for first arrival when start pressed again can continue moving
                // if its this position set int to 1 when pressed again ++
                // if odd stop moving on arrival if even keep moving
                //(variable%2)=0 is even else odd

                //on first arrival =1 stop moving

                if ((timesInBatterStation % 2 != 0))
                {
                    player.beltOn = false;
                }
               
            }

            if (gameObject.transform.position.z <= ovenStation.transform.position.z + tolerance && gameObject.transform.position.z >= ovenStation.transform.position.z - tolerance)
            {
                print("in oven station");
                timesInOvenStation++;

                if ((timesInOvenStation % 2 != 0))
                {
                   player.beltOn = false;
                }

            }

            if (gameObject.transform.position.z <= flipStation.transform.position.z + tolerance && gameObject.transform.position.z >= flipStation.transform.position.z - tolerance)
            {
                print("in flip station");
                timesInFlipStation++;

                if ((timesInFlipStation % 2 != 0))
                {
                    player.beltOn = false;
                }

            }

            if (gameObject.transform.position.z <= frostingStation.transform.position.z + tolerance && gameObject.transform.position.z >= frostingStation.transform.position.z - tolerance)
            {
                print("in frosting station");
                timesInFrostingStation++;

                if ((timesInFrostingStation % 2 != 0))
                {
                    player.beltOn = false;
                }

            }

            if (gameObject.transform.position.z <= toppingStation.transform.position.z + tolerance && gameObject.transform.position.z >= toppingStation.transform.position.z - tolerance)
            {
                print("in topping station");
                timesInToppingStation++;

                if ((timesInToppingStation % 2 != 0))
                {
                    player.beltOn = false;
                }

            }*/

            //TODO: add stops at conveyor beelt needs to make an additional turn
        } 
    }



   }