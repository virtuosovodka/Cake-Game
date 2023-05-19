using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OvenStuff : MonoBehaviour
{
    public TextMeshProUGUI debug;
    public GameManager gm;
    public Player player;
   
    Material mat;

    static bool baked;

    // Start is called before the first frame update
    void Start()
    {
        gm.batterAmount = .250f;
        gm.batter.SetActive(true);

        baked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((gm.ovenOn || Input.GetKey(KeyCode.B)) && !baked)
        {
            baked = true;

            //deciding size of the cake that is being baked
            //deciding color of the cake that is being baked depending on what color the batter chosen is

            //mat = gm.batter.GetComponent<Renderer>().material;



            gm.cake = gm.batterAmount < 1 ? gm.underfilled : gm.average;

            Transform[] allChildren = gm.cake.GetComponentsInChildren<Transform>();

            Debug.Log(allChildren.Length);

            for (int i = 1; i < allChildren.Length; i++)
            {
                allChildren[i].gameObject.GetComponent<Renderer>().material = gm.batter.GetComponent<Renderer>().material;
            }

            gm.cake.SetActive(true);
            gm.batter.SetActive(false);


            //part 2
            //deciding level of cookness
            if (gm.timeInOven >= gm.cookTime - 1 && gm.timeInOven <= gm.cookTime + 2)
            {
                //cake becomes darker, the vanilla and lemon cake become caramel colored and the chocolate becomes dark brown

                if (gm.cake.GetComponent<MeshRenderer>().material.name != "Chocolate")
                {
                    //for (int i = 1; i < allChildren.Length; i++)
                    //{
                    //    allChildren[i].gameObject.GetComponent<Renderer>().material = Color.Lerp(allChildren[i].gameObject.GetComponent<MeshRenderer>().material.color, player.caramel.color, Time.deltaTime / 10);
                    //}
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