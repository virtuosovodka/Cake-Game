using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OvenStuff : MonoBehaviour
{
    public TextMeshProUGUI debug;
    public GameManager gm;
    public Player player;
   
    Material material;
    public Material chocolate;

    // Start is called before the first frame update
    void Start()
    {
       
        gm.batterAmount = .250f;
        gm.batter.SetActive(true);
        //gm.batter.GetComponent<Renderer>().material = chocolate;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.ovenOn)
        {
            //deciding size of the cake that is being baked
            //deciding color of the cake that is being baked depending on what color the batter chosen is

            material = gm.batter.GetComponent<MeshRenderer>().material;

            if (gm.batterAmount < .35)
            {
                //test whether the right cake is being put in oven
                gm.cake = gm.underfilled;
                gm.underfilled.SetActive(true);
                gm.cake.GetComponent<MeshRenderer>().material = material;
            }
            else
            {
                gm.cake = gm.average;
                gm.average.SetActive(true);
                gm.cake.GetComponent<MeshRenderer>().material = material;
            }

            gm.batter.SetActive(false);

            //deciding level of cookness
            if (gm.timeInOven <= gm.cookTime - 1)
            {
                //cake stays the same, no change
            }
            else if (gm.timeInOven >= gm.cookTime - 1 && gm.timeInOven <= gm.cookTime + 2)
            {
                //cake becomes darker, the vanilla and lemon cake become caramel colored and the chocolate becomes dark brown
                if (gm.cake.GetComponent<MeshRenderer>().material.name != "Chocolate")
                {
                    gm.cake.GetComponent<MeshRenderer>().material.color = Color.Lerp(gameObject.GetComponent<MeshRenderer>().material.color, player.caramel.color, Time.deltaTime / 10);
                }
                else 
                {
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(gameObject.GetComponent<MeshRenderer>().material.color, player.darkBrown.color, Time.deltaTime / 10);
                }

            }
            else if (gm.timeInOven >= gm.cookTime + 2)
            {
                // all three cakes become black as time goes on
                gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(gameObject.GetComponent<MeshRenderer>().material.color, Color.black, Time.deltaTime / 10);
            }
            else if (gm.timeInOven >= gm.cookTime + 4)
            {
                // the cake lights on fire
            }
        }
    }
}