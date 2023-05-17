using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OvenStuff : MonoBehaviour
{
    public TextMeshProUGUI debug;
    public GameManager gm;
    public Player player;
    public GameObject testCube;

    // Start is called before the first frame update
    void Start()
    {
        testCube.GetComponent<MeshRenderer>().material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.ovenOn)
        {
            testCube.GetComponent<MeshRenderer>().material.color = Color.red;

            //deciding size of the cake that is being baked
            if (gm.batterAmount < .35)
            {
                //test whether the right cake is being put in oven
                gm.cake = gm.underfilled;
                gm.underfilled.SetActive(true);
                turnOffFirstBatter();
            }
            else if (gm.batterAmount < .9)
            {
                gm.cake = gm.average;
                gm.underfilled.SetActive(true);
                turnOffFirstBatter();
            }
            else
            { 
                gm.cake = gm.overfilled;
                gm.underfilled.SetActive(true);
                turnOffFirstBatter();
            }

            //deciding color of the cake that is being baked depending on what color the batter chosen is
            if (gm.BatterType() == "Chocolate")
            {
                gm.cake.GetComponent<MeshRenderer>().material.color = gm.chocolateBatter.GetComponent<MeshRenderer>().material.color;
            }
            else if (gm.BatterType() == "Vanilla")
            {
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
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(gameObject.GetComponent<MeshRenderer>().material.color, player.caramel.color, Time.deltaTime / 10);
                }
                else if (gm.BatterType() == "Lemon")
                {
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(gameObject.GetComponent<MeshRenderer>().material.color, player.caramel.color, Time.deltaTime / 10);
                }
                else if (gm.BatterType() == "Chocolate")
                {
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(gameObject.GetComponent<MeshRenderer>().material.color, player.darkBrown.color, Time.deltaTime / 10);
                }

            }
            else if (gm.timeInOven >= gm.cookTime + 2)
            {
                // all three cakes become black as time goes on
                gm.debug.text = "overcooked";
                gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(gameObject.GetComponent<MeshRenderer>().material.color, Color.black, Time.deltaTime / 10);
            }
            else if (gm.timeInOven >= gm.cookTime + 4)
            {
                // the cake lights on fire
            }
        }
    }

    public void turnOffFirstBatter()
    {
        gm.vanillaBatter.SetActive(false);
        gm.chocolateBatter.SetActive(false);
        gm.lemonBatter.SetActive(false);
    }
}
