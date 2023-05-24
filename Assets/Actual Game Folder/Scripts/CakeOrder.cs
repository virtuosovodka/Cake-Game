using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

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
    public List<Material> rightColors = new List<Material> { };
    public List<Material> colorblindFrosting = new List<Material> { };
    

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
    public Material vanillaBatter;
    public Material chocolateBatter;
    public Material lemonBatter;
    public Material redF;
    public Material orangeF;
    public Material yellowF;
    public Material greenF;
    public Material blueF;
    public Material pinkF;
    public Material whiteF;
    public Material brownF;
    public Material rainbowSprinklesS;
    
    public Material cherriesT;
    public Material rasberryJamL;
    public Material chocolateSyrupL;
    public Material caramelL;
    public Material blank;


    // for colorblind mode
    public Material vanillaMColorblind;
    public Material chocolateMColorblind;
    public Material redFColorblind;
    public Material orangeFColorblind;
    public Material greenFColorblind;
    public Material pinkFColorblind;
    public Material brownFColorblind;
    public Material rainbowSprinklesSColorblind;
    
    public Material cherriesTColorblind;
    public Material rasberryJamLColorblind;
    public Material chocolateSyrupLColorblind;
    public Material caramelLColorblind;
    public bool colorblind;

    public GameObject tier2;
    public GameObject tier2nd;

    // for randomly picking three frostings for the piping bags that appear
    int correctButton;

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
    int sprinkleShakes;
    GameObject playerCake;
    int cherryAmount;
    bool hasCherries;
    int cherriesOnCake;

    public TextMeshProUGUI batterType;

    // Start is called before the first frame update
    void Start()
    {
        CreateOrder();


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
            /*
            if (tOrder.name != "blank")
            {
                cherriesOnCake = 5;
            }*/
            // all possible materials
            batterList = new List<Material> { vanillaBatter, chocolateBatter, lemonBatter };
            frostingList = new List<Material> { redF, orangeF, yellowF, greenF, blueF, pinkF, brownF, whiteF };
            //toppingsList = new List<Material> { cherriesT, blank };
            //sprinklesList = new List<Material> { rainbowSprinklesS,  blank };
            liquidList = new List<Material> { rasberryJamL, chocolateSyrupL, caramelL, blank };

            bOrder = batterList[bIndex];
            fOrder = frostingList[fIndex];
            //tOrder = toppingsList[tIndex];
            //sOrder = sprinklesList[sIndex];
            lOrder = liquidList[lIndex];

            // setting random material to the right thing
            GameObject[] Batters = GameObject.FindGameObjectsWithTag("OrderBatter");
            foreach (GameObject batter in Batters)
            {
                batter.GetComponent<MeshRenderer>().material = bOrder;

                if (bOrder == vanillaBatter)
                {
                    batterType.text = "Vanilla Batter";
                }
                else if(bOrder == chocolateBatter)
                {
                    batterType.text = "Chocolate Batter";
                }
                else if (bOrder == lemonBatter)
                {
                    batterType.text = "Lemon Batter";
                }
            }
            GameObject[] Frostings = GameObject.FindGameObjectsWithTag("OrderFrosting");
            foreach (GameObject frosting in Frostings)
            {
                frosting.GetComponent<MeshRenderer>().material = fOrder;
            }/*
            GameObject[] Toppings = GameObject.FindGameObjectsWithTag("OrderTopping");
            foreach (GameObject topping in Toppings)
            {
                topping.GetComponent<MeshRenderer>().material = tOrder;
            }
            GameObject[] Sprinkles = GameObject.FindGameObjectsWithTag("OrderSprinkles");
            foreach (GameObject sprinkles in Sprinkles)
            {
                sprinkles.GetComponent<MeshRenderer>().material = sOrder;
            }*/
            GameObject[] Liquids = GameObject.FindGameObjectsWithTag("OrderLiquid");
            foreach (GameObject liquid in Liquids)
            {
                liquid.GetComponent<MeshRenderer>().material = lOrder;
            }

            /*
            if (tierIndex == 2)
            {
                if (tOrder.name != "blank")
                {
                    cherriesOnCake = 10;
                }
                tier2.SetActive(true);
                tier2nd.SetActive(true);
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
            }*/
        }
        if (colorblind == true)
        {/*
            if (tOrder.name != "blank")
            {
                cherriesOnCake = 5;
            }*/
            batterList = new List<Material> { vanillaMColorblind, chocolateMColorblind, lemonBatter };
            frostingList = new List<Material> { redFColorblind, orangeFColorblind, yellowF, greenFColorblind, blueF, pinkFColorblind, brownFColorblind, whiteF };
            //toppingsList = new List<Material> { cherriesTColorblind, blank };
            //sprinklesList = new List<Material> { rainbowSprinklesSColorblind,  blank };
            liquidList = new List<Material> { rasberryJamLColorblind, chocolateSyrupLColorblind, caramelLColorblind, blank };

            bOrder = batterList[bIndex];
            fOrder = frostingList[fIndex];
            //tOrder = toppingsList[tIndex];
            //sOrder = sprinklesList[sIndex];
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
            }/*
            GameObject[] Toppings = GameObject.FindGameObjectsWithTag("OrderTopping");
            foreach (GameObject topping in Toppings)
            {
                topping.GetComponent<MeshRenderer>().material = tOrder;
            }
            GameObject[] Sprinkles = GameObject.FindGameObjectsWithTag("OrderSprinkles");
            foreach (GameObject sprinkles in Sprinkles)
            {
                sprinkles.GetComponent<MeshRenderer>().material = sOrder;
            }*/
            GameObject[] Liquids = GameObject.FindGameObjectsWithTag("OrderLiquid");
            foreach (GameObject liquid in Liquids)
            {
                liquid.GetComponent<MeshRenderer>().material = lOrder;
            }
            /*
            if (tierIndex == 2)
            {
                if (tOrder.name != "blank")
                {
                    cherriesOnCake = 10;
                }
                tier2.SetActive(true);
                tier2nd.SetActive(true);
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
            }*/

        }



        //GetComponent<MeshRenderer>().material = Material1

    }
    
    public void ClockOut()
    {
        colorblind = false;
        //all of the things that influence points
        if (gm.BatterType() == bOrder.name)
        {
            points++;
            // add cooked enough and amount of batter
        }
        if (gm.timeInOven < 75)
        {
            points++;
        }

        if (gm.frostingType == fOrder.name)
        {
            points++;
            // amount so do the same calculation for batter but for frosting
        }
        /*
        if (tOrder == cherriesT && gm.cherries || tOrder == blank && !gm.cherries)
        {
            points++;
            // placement and amount
        }
        if (gm.cherryAmount == cherriesOnCake && gm.cherries == true)
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
        if (gm.sprinkles == sOrder.name)
        {
            points++;
            // placement and amount
        }
        if (sprinkleShakes <= 3 && sprinkleShakes >= 5)
        {
            points++;
        }*/
        if (gm.liquid == lOrder.name)
        {
            points++;
        }
        /*
        if ((lOrder == caramelL && gm.carmelSauce) || (tOrder == blank && (!gm.chocolateSauce && !gm.carmelSauce && !gm.raspberryJam)) || (lOrder == rasberryJamL && gm.raspberryJam) || (lOrder == chocolateSyrupL && gm.chocolateSauce))
        {
            points++;
            // placement and amount
        }
        */
        if (points<= 2 )
        {
            fired();
        }
    }

    public void ClockIn()
    {
        gm.ResetBakery();
        CreateOrder();
    }
    /*
     * 
    void ColorBlind()
    {
        if (colorblind == true)
        {
            colorblind = false;
        }
        if (colorblind == false)
        {
            colorblind = true;
        }
        vanillaBatter = vanillaMColorblind;
        chocolateBatter = chocolateMColorblind;
        redF = redFColorblind;
        orangeF = orangeFColorblind;
        greenF = greenFColorblind;
        pinkF = pinkFColorblind;
        brownF = brownFColorblind;
        rainbowSprinklesS = rainbowSprinklesSColorblind;
        chocolateSprinklesS = chocolateSprinklesSColorblind;
        cherriesT = cherriesTColorblind;
        rasberryJamL = rasberryJamLColorblind;
        chocolateSyrupL = chocolateSyrupLColorblind;
        caramelL = caramelLColorblind;

        vanillaMColorblind = vanillaBatter;
        chocolateMColorblind = chocolateBatter;
        redFColorblind = redF;
        orangeFColorblind = orangeF;
        greenFColorblind = greenF;
        pinkFColorblind = pinkF;
        brownFColorblind = brownF;
        rainbowSprinklesSColorblind = rainbowSprinklesS;
        chocolateSprinklesSColorblind = chocolateSprinklesS;
        cherriesTColorblind = cherriesT;
        rasberryJamLColorblind = rasberryJamL;
        chocolateSyrupLColorblind = chocolateSyrupL;
        caramelLColorblind = caramelL;
    }*/
    void fired()
    {

    }

    void CreateOrder()
    {

        if (colorblind == false)
        {
            frostingList = new List<Material> { redF, yellowF, blueF, };
            frostingList2 = new List<Material> { redF, yellowF, blueF, };
            colorblindFrosting = new List<Material> { redFColorblind, orangeFColorblind, yellowF, greenFColorblind, blueF, pinkFColorblind, brownFColorblind, whiteF };

            //tier2.SetActive(false);
            //tier2nd.SetActive(false);

            frostingButtons = new List<GameObject> { frostingButton1, frostingButton2, frostingButton3 };


            bIndex = Random.Range(0, batterList.Count);
            fIndex = Random.Range(0, frostingList.Count);
            //tIndex = Random.Range(0, toppingsList.Count);
            //sIndex = Random.Range(0, sprinklesList.Count);
            lIndex = Random.Range(0, liquidList.Count);
            tierIndex = Random.Range(1, 3);

            correctButton = Random.Range(0, 3);
            fOrder = frostingList[fIndex];

            // randommly generating three frosting colors for the three different piping bags
            frostingButtons[correctButton].GetComponent<MeshRenderer>().material = fOrder;
            frostingButtons.RemoveAt(correctButton);
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
            frostingList = new List<Material> { redFColorblind, yellowF, blueF, };
            frostingList2 = new List<Material> { redFColorblind, yellowF, blueF, };
            tier2.SetActive(false);
            tier2nd.SetActive(false);

            frostingButtons = new List<GameObject> { frostingButton1, frostingButton2, frostingButton3 };


            bIndex = Random.Range(0, batterList.Count);
            fIndex = Random.Range(0, frostingList.Count);
            tIndex = Random.Range(0, toppingsList.Count);
            sIndex = Random.Range(0, sprinklesList.Count);
            lIndex = Random.Range(0, liquidList.Count);
            tierIndex = Random.Range(1, 3);

            correctButton = Random.Range(0, 3);
            fOrder = frostingList[fIndex];

            // randommly generating three frosting colors for the three different piping bags
            frostingButtons[correctButton].GetComponent<MeshRenderer>().material = fOrder;
            frostingButtons.RemoveAt(correctButton);
            frostingList2.RemoveAt(fIndex);
            FIndex = Random.Range(0, frostingList2.Count);
            wrongFrosting = frostingList2[FIndex];
            frostingButtons[0].GetComponent<MeshRenderer>().material = wrongFrosting;
            frostingList2.RemoveAt(FIndex);
            FIndex = Random.Range(0, frostingList2.Count);
            wrongFrosting = frostingList2[FIndex];
            frostingButtons[1].GetComponent<MeshRenderer>().material = wrongFrosting;
        }


    }
        
}
