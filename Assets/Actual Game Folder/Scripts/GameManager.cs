using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject currentObject;

    //Rigidbody rb;

    public TextMeshProUGUI debug;

    //stations
    public bool beltOn = false;
    public bool batterOn = false;
    public bool ovenOn = false;
    public bool frostingOn = false;

    //batter
    public float batterPerFrame;
    //public float chocolateBatterAmount;
    //public float vanillaBatterAmount;
    //public float lemonBatterAmount;
    

    public float tooMuchBatter;
    public GameObject batter;

    public bool createdChocolateBatter = false;
    public bool createdVanillaBatter = false;
    public bool createdLemonBatter = false;
    //public GameObject vanillaBatter;
    //public GameObject chocolateBatter;
    //public GameObject lemonBatter;
    public float batterAmount;
    public GameObject uncookedBatter;

    //oven
    public float cookTime;
    public float cookTimePerOunce;
    public float timeInOven;
    public bool ovenDoorHit;
    public GameObject underfilled;
    public GameObject average;
    public GameObject overfilled;
    public GameObject cake;

    //frosting
    public float timeSqueezingFrosting;
    public GameObject frostingDollop;
    public GameObject frosting;

    public string frostingType;

    //toppings
    public bool holdingLiquid = false;
    public float timeSqueezingLiquid;
    public GameObject liquidPrefab;

    public bool cherries;
    public int cherryAmount;
    public string sprinkles;

    //liquid
    public string liquid;

    //ipad
    public bool ipadHit;

    public CakeOrder cakeOrder;

    //animator
    [SerializeField]
    Animator[] longConveyerAnim;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(instance);
    }

    private void Start()
    {
        //vanillaBatter.SetActive(false);
        //chocolateBatter.SetActive(false);
        //lemonBatter.SetActive(false);
        uncookedBatter.SetActive(false);
        underfilled.SetActive(false);
        overfilled.SetActive(false);
        average.SetActive(false);
        liquidPrefab.SetActive(false);
    }

    private void Update()
    {
        for (int i = 0; i < longConveyerAnim.Length; i++)
            longConveyerAnim[i].SetBool("Running", beltOn);
    }

    public string BatterType()
    {
        
        return batter.GetComponent<Renderer>().material.name;
    }

}
