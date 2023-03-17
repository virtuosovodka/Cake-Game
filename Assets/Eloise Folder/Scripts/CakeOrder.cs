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
    List<int> tiers = new List<int> {1,2,3};
    //public List<Material> patternList = new List<Material> { };
    int bIndex;
    int fIndex;
    int tIndex;
    int sIndex;
    int lIndex;
    int tierIndex;
    //int pIndex;
    Material bOrder;
    Material fOrder;
    Material tOrder;
    Material sOrder;
    Material lOrder;
    public Material confettiM;
    public Material chocolateM;
    public Material lemonM;
    public Material redF;
    public Material orangeF;
    public Material yellowF;
    public Material greenF;
    public Material blueF;
    public Material purpleF;
    public Material pinkF;
    public Material whiteF;
    public Material brownF;
    public Material rainbowSprinklesS;
    public Material chocolateSprinklesS;
    public Material cherriesT;
    public Material rasberryJamL;
    public Material chocolateSyrupL;
    public Material caramelL;
    /*public Material curtainsP;
    public Material swirlyStarsP;
    public Material curlyBorderP;
    public Material seaShellsP;
    */

    public GameObject tier2;
    public GameObject tier3;
    
    // Start is called before the first frame update
    void Start()
    {
        tier2.SetActive(false);
        tier3.SetActive(false);

        batterList = new List<Material> {confettiM,chocolateM,lemonM};
        frostingList = new List<Material> { redF, orangeF, yellowF,greenF,blueF,purpleF,pinkF,brownF,whiteF };
        toppingsList = new List<Material> {cherriesT};
        sprinklesList = new List<Material> { rainbowSprinklesS, chocolateSprinklesS };
        liquidList = new List<Material> { rasberryJamL, chocolateSyrupL, caramelL };


        bIndex = Random.Range(0, batterList.Count);
        fIndex = Random.Range(0, frostingList.Count);
        tIndex = Random.Range(0, toppingsList.Count);
        sIndex = Random.Range(0, sprinklesList.Count);
        lIndex = Random.Range(0, liquidList.Count);
        tierIndex = Random.Range(0, tiers.Count);
        //pIndex = Random.Range(0, patternList.Count);


    }
    /* batter - chcolate, lemon, confetti
     * frosting - red, orange, yellow, green, blue, purple, pink, white, brown
     * toppings - rainbow sprinkles, chocolate sprinkles, cherries, rasberry jam, chocolate syryp, caramel
     * layers - 3
     * teirs later - 1, 2, 3
     * frosting pattern?
     */
    // Update is called once per frame
    void Update()
    {

        bOrder = batterList[bIndex];
        fOrder = frostingList[fIndex];
        tOrder = toppingsList[tIndex];
        sOrder = sprinklesList[sIndex];
        lOrder = liquidList[lIndex];
        //pOrder = patternList[pIndex];

        if (tierIndex == 1)
        { 
            GameObject.FindGameObjectWithTag("OrderBatter").GetComponent<MeshRenderer>().material = bOrder;
            GameObject.FindGameObjectWithTag("OrderFrosting").GetComponent<MeshRenderer>().material = fOrder;
            GameObject.FindGameObjectWithTag("OrderTopping").GetComponent<MeshRenderer>().material = tOrder;
            GameObject.FindGameObjectWithTag("OrderSprinkles").GetComponent<MeshRenderer>().material = sOrder;
            GameObject.FindGameObjectWithTag("OrderLiquid").GetComponent<MeshRenderer>().material = lOrder;


            if (tierIndex == 2)
            {
                tier2.SetActive(true);
                bIndex = Random.Range(0, batterList.Count);
                fIndex = Random.Range(0, frostingList.Count);
                tIndex = Random.Range(0, toppingsList.Count);
                sIndex = Random.Range(0, sprinklesList.Count);
                lIndex = Random.Range(0, liquidList.Count);
                bOrder = batterList[bIndex];
                fOrder = frostingList[fIndex];
                tOrder = toppingsList[tIndex];
                sOrder = sprinklesList[sIndex];
                lOrder = liquidList[lIndex];
                GameObject.FindGameObjectWithTag("OrderBatter2").GetComponent<MeshRenderer>().material = bOrder;
                GameObject.FindGameObjectWithTag("OrderFrosting2").GetComponent<MeshRenderer>().material = fOrder;
                GameObject.FindGameObjectWithTag("OrderTopping2").GetComponent<MeshRenderer>().material = tOrder;
                GameObject.FindGameObjectWithTag("OrderSprinkles2").GetComponent<MeshRenderer>().material = sOrder;
                GameObject.FindGameObjectWithTag("OrderLiquid2").GetComponent<MeshRenderer>().material = lOrder;


                if (tierIndex == 3)
                {
                    tier3.SetActive(true);
                    bIndex = Random.Range(0, batterList.Count);
                    fIndex = Random.Range(0, frostingList.Count);
                    tIndex = Random.Range(0, toppingsList.Count);
                    sIndex = Random.Range(0, sprinklesList.Count);
                    lIndex = Random.Range(0, liquidList.Count);
                    bOrder = batterList[bIndex];
                    fOrder = frostingList[fIndex];
                    tOrder = toppingsList[tIndex];
                    sOrder = sprinklesList[sIndex];
                    lOrder = liquidList[lIndex];
                    GameObject.FindGameObjectWithTag("OrderBatter3").GetComponent<MeshRenderer>().material = bOrder;
                    GameObject.FindGameObjectWithTag("OrderFrosting3").GetComponent<MeshRenderer>().material = fOrder;
                    GameObject.FindGameObjectWithTag("OrderTopping3").GetComponent<MeshRenderer>().material = tOrder;
                    GameObject.FindGameObjectWithTag("OrderSprinkles3").GetComponent<MeshRenderer>().material = sOrder;
                    GameObject.FindGameObjectWithTag("OrderLiquid3").GetComponent<MeshRenderer>().material = lOrder;
                }
            }
        }
        //GetComponent<MeshRenderer>().material = Material1




    }
    }
