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
    public string batter;
    public float tooMuchBatter;
    public bool createdChocolateBatter = false;
    public GameObject vanillaBatter;
    public GameObject chocolateBatter;
    public GameObject lemonBatter;

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
    }
}
