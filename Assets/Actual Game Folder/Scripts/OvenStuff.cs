using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OvenStuff : MonoBehaviour
{
    public TextMeshProUGUI debug;
    public GameManager gm;
    public Player player;
    public bool burnt;

    Material mat;

    static bool baked;

    // Start is called before the first frame update
    void Start()
    {
        gm.batterAmount = .250f;
        gm.batter.SetActive(true);

        baked = false;
        burnt = true;

        gm.timeInOven = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((gm.ovenOn || Input.GetKey(KeyCode.B)))
        {
            gm.timeInOven += Time.deltaTime;
            if (!baked)
            {
                baked = true;

                //deciding size of the cake that is being baked
                //deciding color of the cake that is being baked depending on what color the batter chosen is

                //mat = gm.batter.GetComponent<Renderer>().material;



                gm.cake = gm.batterAmount < 1.5 ? gm.underfilled : gm.average;

                Transform[] allChildren = gm.cake.GetComponentsInChildren<Transform>();

                Debug.Log(allChildren.Length);

                for (int i = 1; i < allChildren.Length; i++)
                {
                    allChildren[i].gameObject.GetComponent<Renderer>().material = gm.batter.GetComponent<Renderer>().material;
                }

                gm.cake.SetActive(true);
                gm.cake.AddComponent<Cake>();
                gm.batter.SetActive(false);
            }

            Debug.Log(gm.timeInOven);
            //part 2
            //deciding level of cookness
            if (gm.timeInOven > 35 && gm.timeInOven < 75)
            {
                //cake becomes darker, the vanilla and lemon cake become caramel colored and the chocolate becomes dark brown
                if (gm.cake.transform.GetChild(0).GetComponent<MeshRenderer>().material.name != "chocolate")
                {
                    gm.cake.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.Lerp(gm.cake.transform.GetChild(0).GetComponent<MeshRenderer>().material.color, player.caramel.color, Time.deltaTime / 40); //player.caramel.color
                    gm.cake.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.Lerp(gm.cake.transform.GetChild(1).GetComponent<MeshRenderer>().material.color, player.caramel.color, Time.deltaTime / 40);
                }
                else
                {
                    gm.cake.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.Lerp(gm.cake.transform.GetChild(0).GetComponent<MeshRenderer>().material.color, player.darkBrown.color, Time.deltaTime / 40);
                    gm.cake.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.Lerp(gm.cake.transform.GetChild(1).GetComponent<MeshRenderer>().material.color, player.darkBrown.color, Time.deltaTime / 40);
                }
                burnt = false;
            }

            else if (gm.timeInOven >= 75)
            {
                Debug.Log("burning");
                // all three cakes become black as time goes on
                gm.cake.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.Lerp(gm.cake.transform.GetChild(0).GetComponent<MeshRenderer>().material.color, Color.black, Time.deltaTime / 20);
                gm.cake.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.Lerp(gm.cake.transform.GetChild(1).GetComponent<MeshRenderer>().material.color, Color.black, Time.deltaTime / 20);
                burnt = true;
            }
            else if (gm.timeInOven >= gm.cookTime + 4)
            {
                // the cake lights on fire
            }

        }
    }

    void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.CompareTag("Knife"))
      {
        //gm.cake.GetChild(0).SetActive(false);
      }
    }
}
