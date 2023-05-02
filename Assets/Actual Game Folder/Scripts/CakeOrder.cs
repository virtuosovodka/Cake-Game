using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class CakeOrder : MonoBehaviour
{
    public List<Material> batterList = new List<Material> { };
    public List<Material> frostingList = new List<Material> { };
    public List<Material> toppingsList = new List<Material> { };
    public List<Material> sprinklesList = new List<Material> { };
    public List<Material> liquidList = new List<Material> { };


    public List<GameObject> frostingButtons = new List<GameObject> { };
    public GameObject frostingButton1;
    public GameObject frostingButton2;
    public GameObject frostingButton3;
    int FIndex;
    public Material wrongFrosting;
    public List<Material> frostingList2 = new List<Material> { };

    int bIndex;
    int fIndex;
    int tIndex;
    int sIndex;
    int lIndex;
    int tierIndex;

    public Material bOrder;
    public Material fOrder;
    public Material tOrder;
    public Material sOrder;
    public Material lOrder;
    public Material confettiM;
    public Material chocolateM;
    public Material lemonM;
    public Material redF;
    public Material orangeF;
    public Material yellowF;
    public Material greenF;
    public Material blueF;
    public Material pinkF;
    public Material whiteF;
    public Material brownF;
    public Material rainbowSprinklesS;
    public Material chocolateSprinklesS;
    public Material cherriesT;
    public Material rasberryJamL;
    public Material chocolateSyrupL;
    public Material caramelL;
    public Material blank;


    // for colorblind mode
    public Material confettiMColorblind;
    public Material chocolateMColorblind;
    public Material redFColorblind;
    public Material orangeFColorblind;
    public Material greenFColorblind;
    public Material pinkFColorblind;
    public Material brownFColorblind;
    public Material rainbowSprinklesSColorblind;
    public Material chocolateSprinklesSColorblind;
    public Material cherriesTColorblind;
    public Material rasberryJamLColorblind;
    public Material chocolateSyrupLColorblind;
    public Material caramelLColorblind;
    public bool colorblind;

    public GameObject tier2;

    // for randomly picking three frostings for the piping bags that appear
    int rightButton;

    //point counting variables
    int points;
    int totalPoints;
    float timer = 0;
    float timerEnd;
    public GameManager gm;
    Material playerBatter;
    Material playerFrosting;
    Material playerTopping;
    Material playerSprinkles;
    Material playerLiquid;
    public GameObject cherry;
    public GameObject playerCherry;
    // Start is called before the first frame update
    void Start()
    {
        if (colorblind == false)
        {
            frostingList = new List<Material> { redF, orangeF, yellowF, greenF, blueF, pinkF, brownF, whiteF };
            frostingList2 = new List<Material> { redF, orangeF, yellowF, greenF, blueF, pinkF, brownF, whiteF };
            tier2.SetActive(false);

            frostingButtons = new List<GameObject> { frostingButton1, frostingButton2, frostingButton3 };


            bIndex = Random.Range(0, batterList.Count);
            fIndex = Random.Range(0, frostingList.Count);
            tIndex = Random.Range(0, toppingsList.Count);
            sIndex = Random.Range(0, sprinklesList.Count);
            lIndex = Random.Range(0, liquidList.Count);
            tierIndex = Random.Range(1, 3);

            rightButton = Random.Range(0, 3);
            fOrder = frostingList[fIndex];

            // randommly generating three frosting colors for the three different piping bags
            frostingButtons[rightButton].GetComponent<MeshRenderer>().material = fOrder;
            frostingButtons.RemoveAt(rightButton);
            frostingList2.RemoveAt(fIndex);
            FIndex = Random.Range(0, frostingList2.Count);
            wrongFrosting = frostingList2[FIndex];
            frostingButtons[0].GetComponent<MeshRenderer>().material = wrongFrosting;
            frostingList2.RemoveAt(FIndex);
            FIndex = Random.Range(0, frostingList2.Count);
            wrongFrosting = frostingList2[FIndex];
            frostingButtons[1].GetComponent<MeshRenderer>().material = wrongFrosting;
        }
        if (colorblind == true)
        {
            frostingList = new List<Material> { redFColorblind, orangeFColorblind, yellowF, greenFColorblind, blueF, pinkFColorblind, brownFColorblind, whiteF };
            frostingList2 = new List<Material> { redFColorblind, orangeFColorblind, yellowF, greenFColorblind, blueF, pinkFColorblind, brownFColorblind, whiteF };
            tier2.SetActive(false);

            frostingButtons = new List<GameObject> { frostingButton1, frostingButton2, frostingButton3 };


            bIndex = Random.Range(0, batterList.Count);
            fIndex = Random.Range(0, frostingList.Count);
            tIndex = Random.Range(0, toppingsList.Count);
            sIndex = Random.Range(0, sprinklesList.Count);
            lIndex = Random.Range(0, liquidList.Count);
            tierIndex = Random.Range(1, 3);

            rightButton = Random.Range(0, 3);
            fOrder = frostingList[fIndex];

            // randommly generating three frosting colors for the three different piping bags
            frostingButtons[rightButton].GetComponent<MeshRenderer>().material = fOrder;
            frostingButtons.RemoveAt(rightButton);
            frostingList2.RemoveAt(fIndex);
            FIndex = Random.Range(0, frostingList2.Count);
            wrongFrosting = frostingList2[FIndex];
            frostingButtons[0].GetComponent<MeshRenderer>().material = wrongFrosting;
            frostingList2.RemoveAt(FIndex);
            FIndex = Random.Range(0, frostingList2.Count);
            wrongFrosting = frostingList2[FIndex];
            frostingButtons[1].GetComponent<MeshRenderer>().material = wrongFrosting;
        }


        //pOrder = patternList[pIndex];
    }
    /* batter - chcolate, lemon, confetti
     * frosting - red, orange, yellow, green, blue, purple, pink, white, brown
     * toppings - rainbow sprinkles, chocolate sprinkles, cherries, rasberry jam, chocolate syryp, caramel
     * layers - 3
     * teirs later - 1, 2, 3
     * frosting pattern?
     */

    /*for next time
     * can we change just the shader? 
     *--texture?
     * */



    // Update is called once per frame
    void Update()
    {


        if (colorblind == false)
        {
            // all possible materials
            batterList = new List<Material> { confettiM, chocolateM, lemonM };
            frostingList = new List<Material> { redF, orangeF, yellowF, greenF, blueF, pinkF, brownF, whiteF };
            toppingsList = new List<Material> { cherriesT, blank };
            sprinklesList = new List<Material> { rainbowSprinklesS, chocolateSprinklesS, blank };
            liquidList = new List<Material> { rasberryJamL, chocolateSyrupL, caramelL, blank };

            bOrder = batterList[bIndex];
            fOrder = frostingList[fIndex];
            tOrder = toppingsList[tIndex];
            sOrder = sprinklesList[sIndex];
            lOrder = liquidList[lIndex];

            // setting random material to the right thing
            GameObject[] Batters = GameObject.FindGameObjectsWithTag("OrderBatter");
            foreach (GameObject batter in Batters)
            {
                batter.GetComponent<MeshRenderer>().material = bOrder;

            }
            GameObject[] Frostings = GameObject.FindGameObjectsWithTag("OrderFrosting");
            foreach (GameObject frosting in Frostings)
            {
                frosting.GetComponent<MeshRenderer>().material = fOrder;
            }
            GameObject[] Toppings = GameObject.FindGameObjectsWithTag("OrderTopping");
            foreach (GameObject topping in Toppings)
            {
                topping.GetComponent<MeshRenderer>().material = tOrder;
            }
            GameObject[] Sprinkles = GameObject.FindGameObjectsWithTag("OrderSprinkles");
            foreach (GameObject sprinkles in Sprinkles)
            {
                sprinkles.GetComponent<MeshRenderer>().material = sOrder;
            }
            GameObject[] Liquids = GameObject.FindGameObjectsWithTag("OrderLiquid");
            foreach (GameObject liquid in Liquids)
            {
                liquid.GetComponent<MeshRenderer>().material = lOrder;
            }


            if (tierIndex == 2)
            {
                tier2.SetActive(true);
                GameObject[] Batters2 = GameObject.FindGameObjectsWithTag("OrderBatter2");
                foreach (GameObject batter in Batters2)
                {
                    batter.GetComponent<MeshRenderer>().material = bOrder;

                }
                GameObject[] Frostings2 = GameObject.FindGameObjectsWithTag("OrderFrosting2");
                foreach (GameObject frosting in Frostings2)
                {
                    frosting.GetComponent<MeshRenderer>().material = fOrder;
                }
                GameObject[] Toppings2 = GameObject.FindGameObjectsWithTag("OrderTopping2");
                foreach (GameObject topping in Toppings2)
                {
                    topping.GetComponent<MeshRenderer>().material = tOrder;
                }
                GameObject[] Sprinkles2 = GameObject.FindGameObjectsWithTag("OrderSprinkles2");
                foreach (GameObject sprinkles in Sprinkles2)
                {
                    sprinkles.GetComponent<MeshRenderer>().material = sOrder;
                }
                GameObject[] Liquids2 = GameObject.FindGameObjectsWithTag("OrderLiquid2");
                foreach (GameObject liquid in Liquids2)
                {
                    liquid.GetComponent<MeshRenderer>().material = lOrder;
                }
            }
        }
        if (colorblind == true)
        {
            batterList = new List<Material> { confettiMColorblind, chocolateMColorblind, lemonM };
            frostingList = new List<Material> { redFColorblind, orangeFColorblind, yellowF, greenFColorblind, blueF, pinkFColorblind, brownFColorblind, whiteF };
            toppingsList = new List<Material> { cherriesTColorblind, blank };
            sprinklesList = new List<Material> { rainbowSprinklesSColorblind, chocolateSprinklesSColorblind, blank };
            liquidList = new List<Material> { rasberryJamLColorblind, chocolateSyrupLColorblind, caramelLColorblind, blank };

            bOrder = batterList[bIndex];
            fOrder = frostingList[fIndex];
            tOrder = toppingsList[tIndex];
            sOrder = sprinklesList[sIndex];
            lOrder = liquidList[lIndex];

            GameObject[] Batters = GameObject.FindGameObjectsWithTag("OrderBatter");
            foreach (GameObject batter in Batters)
            {
                batter.GetComponent<MeshRenderer>().material = bOrder;

            }
            GameObject[] Frostings = GameObject.FindGameObjectsWithTag("OrderFrosting");
            foreach (GameObject frosting in Frostings)
            {
                frosting.GetComponent<MeshRenderer>().material = fOrder;
            }
            GameObject[] Toppings = GameObject.FindGameObjectsWithTag("OrderTopping");
            foreach (GameObject topping in Toppings)
            {
                topping.GetComponent<MeshRenderer>().material = tOrder;
            }
            GameObject[] Sprinkles = GameObject.FindGameObjectsWithTag("OrderSprinkles");
            foreach (GameObject sprinkles in Sprinkles)
            {
                sprinkles.GetComponent<MeshRenderer>().material = sOrder;
            }
            GameObject[] Liquids = GameObject.FindGameObjectsWithTag("OrderLiquid");
            foreach (GameObject liquid in Liquids)
            {
                liquid.GetComponent<MeshRenderer>().material = lOrder;
            }

            if (tierIndex == 2)
            {
                tier2.SetActive(true);
                GameObject[] Batters2 = GameObject.FindGameObjectsWithTag("OrderBatter2");
                foreach (GameObject batter in Batters2)
                {
                    batter.GetComponent<MeshRenderer>().material = bOrder;

                }
                GameObject[] Frostings2 = GameObject.FindGameObjectsWithTag("OrderFrosting2");
                foreach (GameObject frosting in Frostings2)
                {
                    frosting.GetComponent<MeshRenderer>().material = fOrder;
                }
                GameObject[] Toppings2 = GameObject.FindGameObjectsWithTag("OrderTopping2");
                foreach (GameObject topping in Toppings2)
                {
                    topping.GetComponent<MeshRenderer>().material = tOrder;
                }
                GameObject[] Sprinkles2 = GameObject.FindGameObjectsWithTag("OrderSprinkles2");
                foreach (GameObject sprinkles in Sprinkles2)
                {
                    sprinkles.GetComponent<MeshRenderer>().material = sOrder;
                }
                GameObject[] Liquids2 = GameObject.FindGameObjectsWithTag("OrderLiquid2");
                foreach (GameObject liquid in Liquids2)
                {
                    liquid.GetComponent<MeshRenderer>().material = lOrder;
                }
            }

        }



        //GetComponent<MeshRenderer>().material = Material1

    }
    /*
    void ClockOut()
    {
        //all of the things that influence points
        timerEnd = timer;
        if (timerEnd >= 10)
        {
            points++;
        }

        if (playerBatter == bOrder)
        {
            points++;
            // add cooked enough and amount of batter
        }
        if (gm.timeInOven >= gm.cookTime - 1 && gm.timeInOven <= gm.cookTime + 2)
        {
            points++;
        }
        if (gm.cookTime >= && gm.cookTime <= )
        {
            points++;
        }
        if (playerFrosting == fOrder)
        {
            points++;
            // amount so do the same calculation for batter but for frosting
        }
        if (playerTopping == tOrder)
        {
            points++;
            // placement and amount
        }
        if (cherryAmount == )
        {
            points++;
        }
        if (cherry.transform.position.x >= ((playerCake.transform.position.x/2) - (playerCherry.transform.position.x/2)) -.1 && cherry.transform.position.x <= ((playerCake.transform.position.x / 2) + (cherry.transform.position.x/2)) + .1)
        {
            points++;
        }
        if (cherry.transform.position.z >= ((playerCake.transform.position.z / 2) - (playerCherry.transform.position.z / 2)) - .1 && cherry.transform.position.z <= ((playerCake.transform.position.z / 2) + (cherry.transform.position.z / 2)) + .1)
        {
            points++;
        }
        if (playerSprinkles == sOrder)
        {
            points++;
            // placement and amount
        }
        if (sprinkleShakes == )
        {
            points++;
        }
        if (playerLiquid == lOrder)
        {
            points++;
            // placement and amount
        }

        totalPoints = (points/15) * 100;
    }*/
}
