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

    public float chocolateBatterAmount;

    public float vanillaBatterAmount;

    public float lemonBatterAmount;



    public float tooMuchBatter;

    public bool createdChocolateBatter = false;

    public bool createdVanillaBatter = false;

    public bool createdLemonBatter = false;

    public GameObject vanillaBatter;

    public GameObject chocolateBatter;

    public GameObject lemonBatter;

    public float batterAmount;

    public GameObject uncookedBatter;



    //oven

    public float cookTime;

    public float cookTimePerOunce;

    public float timeInOven;

    public bool ovenDoorHit;



    //toppings

    public bool holdingLiquid = false;

    public float timeSqueezingLiquid;





    //ipad

    public bool ipadHit;



    public CakeOrder cakeOrder;



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

        vanillaBatter.SetActive(false);

        chocolateBatter.SetActive(false);

        lemonBatter.SetActive(false);

        uncookedBatter.SetActive(false);

    }



    public string BatterType()

    {

        string _batterType;

        if (chocolateBatterAmount > vanillaBatterAmount && chocolateBatterAmount > lemonBatterAmount)

        {

            batterAmount = chocolateBatterAmount;

            _batterType = "Chocolate";

        }

        else if (lemonBatterAmount > vanillaBatterAmount && lemonBatterAmount > chocolateBatterAmount)

        {

            batterAmount = lemonBatterAmount;

            _batterType = "Lemon";

        }

        else

        {

            batterAmount = vanillaBatterAmount;

            _batterType = "Vanilla";

        }

        return _batterType;

    }



}