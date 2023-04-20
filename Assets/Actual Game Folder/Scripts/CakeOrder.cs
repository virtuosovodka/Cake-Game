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
    int rightFrosting;

    // Start is called before the first frame update
    void Start()
    {
        tier2.SetActive(false);

        
        

        bIndex = Random.Range(0, batterList.Count);
        fIndex = Random.Range(0, frostingList.Count);
        tIndex = Random.Range(0, toppingsList.Count);
        sIndex = Random.Range(0, sprinklesList.Count);
        lIndex = Random.Range(0, liquidList.Count);
        tierIndex = Random.Range(1,3);

        fOrder = frostingList[fIndex];
        rightFrosting = Random.Range(1,4);

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
        GameObject.FindGameObjectWithTag("frostingButtons[rightFrosting]").GetComponent<MeshRenderer>().material = fOrder;
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
            GameObject.FindGameObjectWithTag("OrderBatter").GetComponent<MeshRenderer>().material = bOrder;
            GameObject.FindGameObjectWithTag("OrderFrosting").GetComponent<MeshRenderer>().material = fOrder;
            GameObject.FindGameObjectWithTag("OrderTopping").GetComponent<MeshRenderer>().material = tOrder;
            GameObject.FindGameObjectWithTag("OrderSprinkles").GetComponent<MeshRenderer>().material = sOrder;
            GameObject.FindGameObjectWithTag("OrderLiquid").GetComponent<MeshRenderer>().material = lOrder;

        }
        if (tierIndex == 2)
        {
            tier2.SetActive(true);
            GameObject.FindGameObjectWithTag("OrderBatter2").GetComponent<MeshRenderer>().material = bOrder;
            GameObject.FindGameObjectWithTag("OrderFrosting2").GetComponent<MeshRenderer>().material = fOrder;
            GameObject.FindGameObjectWithTag("OrderTopping2").GetComponent<MeshRenderer>().material = tOrder;
            GameObject.FindGameObjectWithTag("OrderSprinkles2").GetComponent<MeshRenderer>().material = sOrder;
            GameObject.FindGameObjectWithTag("OrderLiquid2").GetComponent<MeshRenderer>().material = lOrder;
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

            GameObject.FindGameObjectWithTag("OrderBatter").GetComponent<MeshRenderer>().material = bOrder;
            GameObject.FindGameObjectWithTag("OrderFrosting").GetComponent<MeshRenderer>().material = fOrder;
            GameObject.FindGameObjectWithTag("OrderTopping").GetComponent<MeshRenderer>().material = tOrder;
            GameObject.FindGameObjectWithTag("OrderSprinkles").GetComponent<MeshRenderer>().material = sOrder;
            GameObject.FindGameObjectWithTag("OrderLiquid").GetComponent<MeshRenderer>().material = lOrder;

        }



        //GetComponent<MeshRenderer>().material = Material1

    }
    

}
